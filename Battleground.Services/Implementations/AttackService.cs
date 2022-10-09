using Battleground.Models.Dtos;
using Battleground.Models.InputModels;
using Battleground.Repositories.Interfaces;
using Battleground.Services.Interfaces;
using GraphQL;

namespace Battleground.Services.Implementations;

public class AttackService : IAttackService
{
    private HttpClient _httpClient;
    private readonly IAttackRepository _attackRepository;
    private readonly IPokemonService _pokemonService;
    private IBattleService _battleService;
    private IPlayerRepository _playerRepository;
    public AttackService(HttpClient httpClient, IAttackRepository attackRepository, IPokemonService pokemonService, IBattleService battleService, IPlayerRepository playerRepository)
    {
        _attackRepository = attackRepository;
        _httpClient = httpClient;
        _pokemonService = pokemonService;
        _battleService = battleService;
        _playerRepository = playerRepository;
    }
    public async Task<AttackDto> CreateAttack(AttackInputModel attack)
    {
        // Check if battle exists
        // Throws exception if not found
        var battle = await _battleService.GetBattleById(attack.BattleId);

        // Check if battle is finished
        if (battle.Status == Models.Enums.BattleStatus.FINISHED)
            throw new ExecutionError($"Battle with id '{battle.Id}' has finished, no further attacks are allowed");


        // Checks if pokemon is valid
        var pokemon = await _pokemonService.GetPokemonByName(attack.Attacker);

        // Check if pokemon is in the battle
        bool pokemonIsInBattle = false;
        foreach (var pokemonInBattle in battle.BattlePokemons)
        {
            if (pokemonInBattle.PokemonIdentifier == pokemon.Name)
            {
                pokemonIsInBattle = true;
                break;
            }
        }
        if (pokemonIsInBattle == false)
            throw new ExecutionError($"The pokemon '{pokemon.Name}' is not participating in battle '{battle.Id}'");

        var attackResult = _attackRepository.CreateAttack(attack, pokemon);

        var battleAfterAttack = await _battleService.GetBattleById(attack.BattleId);

        // If the first attack was made, set game status to started

        if (battleAfterAttack.Attacks.Count() == 1)
        {
            _battleService.StartBattle(battleAfterAttack.Id);
        }

        // Determine if game should end


        var opponentName = battleAfterAttack.BattlePokemons.Where(x => x.PokemonIdentifier != attack.Attacker).FirstOrDefault().PokemonIdentifier;
        var opponent = await _pokemonService.GetPokemonByName(opponentName);

        var totalDamageDealtByAttacker = battleAfterAttack.Attacks.Where(a => a.BattlePokemons.PokemonIdentifier == attack.Attacker).Sum(x => x.DamageDealt);

        // If total damage dealt is more or equal to their health, set status as finished

        if (totalDamageDealtByAttacker >= opponent.HealthPoints)
        {
            // Finish game and crown a winner

            var attackerOwner = _playerRepository.GetPokemonOwners(attack.Attacker).FirstOrDefault();
            _battleService.FinishBattleAndCrownWinner(battle.Id, attackerOwner.Id);
        }

        return attackResult;
    }
}

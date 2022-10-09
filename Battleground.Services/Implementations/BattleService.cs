using System.Net.Http.Json;
using Battleground.Models.Dtos;
using Battleground.Models.Enums;
using Battleground.Models.InputModels;
using Battleground.Repositories.Interfaces;
using Battleground.Services.Interfaces;
using GraphQL;

namespace Battleground.Services.Implementations;

public class BattleService : IBattleService
{
    private HttpClient _httpClient;
    private IBattleRepository _battleRepository;
    private IPlayerService _playerService;
    private IPokemonService _pokemonService;

    public BattleService(HttpClient httpClient, IBattleRepository battleRepository, IPlayerService playerService, IPokemonService pokemonService)
    {
        _httpClient = httpClient;
        _battleRepository = battleRepository;
        _playerService = playerService;
        _pokemonService = pokemonService;
    }

    public async Task<IEnumerable<BattleDto>> GetAllBattles(BattleStatus status) =>
        await _battleRepository.GetAllBattles(status);

    public async Task<BattleDto> GetBattleById(int Id) =>
        await _battleRepository.GetBattleById(Id);

    public async Task<BattleDto> CreateBattle(BattleInputModel battle)
    {

        // Are there two players?
        if (battle.PlayerIds.Count() != 2)
            throw new ExecutionError("There must be two players in a match");
        // Are the players valid?
        foreach (var playerId in battle.PlayerIds)
        {
            // Throws exception if player is not found
            _playerService.GetPlayerById(playerId);
        }

        // Are there two pokemons?
        if (battle.PokemonIds.Count() != 2)
            throw new ExecutionError("There must be two pokemons in a match");

        // Are the pokemons valid?
        foreach (var pokemonName in battle.PokemonIds)
        {
            // Throws exception if pokemon does not exist
            await _pokemonService.GetPokemonByName(pokemonName);
        }

        // Check if the pokemons are actually owned by the players competing
        foreach (var playerId in battle.PlayerIds)
        {
            // For each player, check the pokemons
            bool pokemonIsOwnedByPlayer = false;
            foreach (var pokemonName in battle.PokemonIds)
            {
                var pokemon = await _pokemonService.GetPokemonByName(pokemonName);
                if (_pokemonService.PokemonIsOwnedBy(pokemon, playerId))
                {
                    pokemonIsOwnedByPlayer = true;
                    break;
                }
            }
            if (pokemonIsOwnedByPlayer != true)
            {
                throw new ExecutionError($"Player with id '{playerId}' does not own either pokemons provided");
            }
        }

        foreach (var playerId in battle.PlayerIds)
        {
            if (_battleRepository.IsPlayerInBattle(playerId))
                throw new ExecutionError($"Player with id '{playerId}' is already in another battle");
        }


        return await _battleRepository.CreateBattle(battle);
    }

    public void FinishBattleAndCrownWinner(int battleId, int winnerId)
    {
        _battleRepository.FinishBattleAndCrownWinner(battleId, winnerId);
    }

    public void StartBattle(int battleId)
    {
        _battleRepository.StartBattle(battleId);
    }
}
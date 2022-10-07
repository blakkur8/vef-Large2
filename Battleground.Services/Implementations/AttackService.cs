using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Battleground.Models.Dtos;
using Battleground.Models.InputModels;
using Battleground.Repositories.Entities;
using Battleground.Repositories.Interfaces;
using Battleground.Services.Interfaces;

namespace Battleground.Services.Implementations;

public class AttackService : IAttackService
{
    private HttpClient _httpClient;
    private readonly IAttackRepository _attackRepository;
    private readonly IPokemonService _pokemonService;
    public AttackService(HttpClient httpClient, IAttackRepository attackRepository, IPokemonService pokemonService)
    {
        _attackRepository = attackRepository;
        _httpClient = httpClient;
        _pokemonService = pokemonService;
    }
    public async Task<AttackDto> CreateAttack(AttackInputModel attack)
    {
        var pokemon = await _pokemonService.GetPokemonByName(attack.Attacker);
        return _attackRepository.CreateAttack(attack, pokemon);
    }
}

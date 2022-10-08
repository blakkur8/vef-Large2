using System.Net.Http.Json;
using Battleground.Models.Dtos;
using Battleground.Repositories.Interfaces;
using Battleground.Services.Interfaces;
using GraphQL;

namespace Battleground.Services.Implementations;

public class PokemonService : IPokemonService
{
    private HttpClient _httpClient;
    private IPlayerRepository _playerRepository;


    public PokemonService(HttpClient httpClient, IPlayerRepository playerRepository)
    {
        _httpClient = httpClient;
        _playerRepository = playerRepository;
    }

    public async Task<IEnumerable<PokemonDto>> GetAllPokemons() =>
        await _httpClient.GetFromJsonAsync<IEnumerable<PokemonDto>>("pokemons");

    public async Task<PokemonDto> GetPokemonByName(string name)
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<PokemonDto>($"pokemons/{name}");

        }
        catch (Exception e)
        {
            throw new ExecutionError($"Error resolving pokemon with id: '{name}'\n{e.Message}");

        }

    }

    public IEnumerable<PlayerDto> GetPokemonOwners(string pokemonIdentifier)
    {
        return _playerRepository.GetPokemonOwners(pokemonIdentifier);
    }

    public bool PokemonHasOwner(PokemonDto pokemon)
    {
        var owners = GetPokemonOwners(pokemon.Name);
        if (owners.Count() == 0) return false;
        return true;
    }

    public bool PokemonIsOwnedBy(PokemonDto pokemon, int playerId)
    {
        var owners = GetPokemonOwners(pokemon.Name);
        foreach (var owner in owners)
        {
            if (owner.Id == playerId) return true;
        }
        return false;
    }
}
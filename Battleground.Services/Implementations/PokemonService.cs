using System.Net.Http.Json;
using Battleground.Models.Dtos;
using Battleground.Repositories.Interfaces;
using Battleground.Services.Interfaces;

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

    public async Task<IEnumerable<PokemonDto>?> GetAllPokemons() =>
        await _httpClient.GetFromJsonAsync<IEnumerable<PokemonDto>>("pokemons");

    public async Task<PokemonDto> GetPokemonByName(string name) =>
        await _httpClient.GetFromJsonAsync<PokemonDto>($"pokemons/{name}");


    public IEnumerable<PlayerDto> GetPokemonOwners(string pokemonIdentifier)
    {
        return _playerRepository.GetPokemonOwners(pokemonIdentifier);
    }
}
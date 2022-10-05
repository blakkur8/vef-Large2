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

    public async Task<IEnumerable<PokemonDto>?> getAllPokemons() =>
        await _httpClient.GetFromJsonAsync<IEnumerable<PokemonDto>>("pokemons");

    public async Task<PokemonDto> getPokemonByName(string name) =>
        await _httpClient.GetFromJsonAsync<PokemonDto>($"pokemons/{name}");


    public IEnumerable<PlayerDto> getPokemonOwners(string pokemonIdentifier)
    {
        return _playerRepository.getPokemonOwners(pokemonIdentifier);
    }
}
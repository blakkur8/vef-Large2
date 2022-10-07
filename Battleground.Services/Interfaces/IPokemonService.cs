using Battleground.Models.Dtos;

namespace Battleground.Services.Interfaces;

public interface IPokemonService
{
    public Task<IEnumerable<PokemonDto>> GetAllPokemons();
    public Task<PokemonDto> GetPokemonByName(string name);
    public IEnumerable<PlayerDto> GetPokemonOwners(string pokemonIdentifier);

}
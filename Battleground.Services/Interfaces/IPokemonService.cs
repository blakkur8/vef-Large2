using Battleground.Models.Dtos;

namespace Battleground.Services.Interfaces;

public interface IPokemonService
{
    public Task<IEnumerable<PokemonDto>> getAllPokemons();
    public Task<PokemonDto> getPokemonByName(string name);
    public IEnumerable<PlayerDto> GetPokemonOwners(string pokemonIdentifier);

}
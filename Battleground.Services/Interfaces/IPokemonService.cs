using Battleground.Models.Dtos;

namespace Battleground.Services.Interfaces;

public interface IPokemonService
{
    public Task<IEnumerable<PokemonDto>> getAllPokemons();
}
using Battleground.Models.Dtos;
using Battleground.Repositories.Entities;

namespace Battleground.Repositories.Interfaces
{
    public interface IPlayerRepository
    {
        public IEnumerable<PlayerDto> GetAllPlayers();

        public PlayerDto GetPlayerById(int Id);

        public PlayerDto CreatePlayer(Players playerModel);

        public bool RemovePlayer(int id);
        public IEnumerable<PlayerDto> GetPokemonOwners(string pokemonIdentifier);
    }
}
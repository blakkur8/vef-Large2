using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Battleground.Models.Dtos;

namespace Battleground.Repositories.Interfaces
{
    public interface IPlayerRepository
    {
        public IEnumerable<PlayerDto> getAllPlayers();

        public PlayerDto getPlayerById(int Id);

        public IEnumerable<PlayerDto> getPokemonOwners(string pokemonIdentifier);

    }
}
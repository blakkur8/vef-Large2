using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Battleground.Models.Dtos;
using Battleground.Models.InputModels;
using Battleground.Repositories.Entities;

namespace Battleground.Repositories.Interfaces
{
    public interface IPlayerRepository
    {
        public IEnumerable<PlayerDto> getAllPlayers();

        public PlayerDto getPlayerById(int Id);

        public PlayerDto createPlayer(Players playerModel);

        public PlayerDto removePlayer(int id);
        public IEnumerable<PlayerDto> GetPokemonOwners(string pokemonIdentifier);
    }
}
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
        public IEnumerable<PlayerDto> GetAllPlayers();

        public PlayerDto GetPlayerById(int Id);

        public PlayerDto CreatePlayer(Players playerModel);

        public PlayerDto RemovePlayer(int id);
        public IEnumerable<PlayerDto> GetPokemonOwners(string pokemonIdentifier);
    }
}
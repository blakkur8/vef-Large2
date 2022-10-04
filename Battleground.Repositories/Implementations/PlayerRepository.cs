using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Battleground.Repositories.Interfaces;
using Battleground.Models.Dtos;

namespace Battleground.Repositories.Implementations
{
    public class PlayerRepository : IPlayerRepository
    {
        public IEnumerable<PlayerDto> getAllPlayers()
        {
            throw new NotImplementedException();
        }

        public PlayerDto getPlayerById()
        {
            throw new NotImplementedException();
        }

    }
}
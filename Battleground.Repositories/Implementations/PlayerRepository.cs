using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Battleground.Repositories.Interfaces;
using Battleground.Repositories.Contexts;
using Battleground.Models.Dtos;
using Battleground.Repositories.Entities;
using AutoMapper;
using Battleground.Models.InputModels;
using Microsoft.EntityFrameworkCore;

namespace Battleground.Repositories.Implementations
{
    public class PlayerRepository : IPlayerRepository
    {
        private BattlegroundDbContext _dbContext;
        private readonly IMapper _mapper;
        public PlayerRepository(BattlegroundDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public IEnumerable<PlayerDto> getAllPlayers()
        {
            var players = _mapper.Map<IEnumerable<PlayerDto>>(_dbContext.Players);
            return players;
        }

        public PlayerDto getPlayerById(int Id)
        {
            var player = _mapper.Map<PlayerDto>(_dbContext.Players.FirstOrDefault(p => p.Id == Id));
            return player;
        }

        public PlayerDto createPlayer(Players player)
        {

            _dbContext.Add(player);
            _dbContext.SaveChanges();

            // virkar kanski ekki :(
            return _mapper.Map<PlayerDto>(player);
        }

        public PlayerDto removePlayer(int id)
        {
            var player = _dbContext.Players.FirstOrDefault(p => p.Id == id);
            if (player != null)
            {
                _dbContext.Remove(player);
                _dbContext.SaveChanges();
                return _mapper.Map<PlayerDto>(player);
            }
            else
            {
                throw new DllNotFoundException();
            }


        }

        public IEnumerable<PlayerDto> getPokemonOwners(string pokemonIdentifier)
        {
            var owners = _dbContext
                    .PlayerInventories
                    .Include(x => x.Player)
                    .Where(x => x.PokemonIdentifier == pokemonIdentifier)
                    .Select(x => x.Player)
                    .AsEnumerable();

            var results = _mapper.Map<IEnumerable<PlayerDto>>(owners);
            return results;
        }
    }
}
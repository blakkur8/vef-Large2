using Battleground.Repositories.Interfaces;
using Battleground.Repositories.Contexts;
using Battleground.Models.Dtos;
using Battleground.Repositories.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using GraphQL;

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
        public IEnumerable<PlayerDto> GetAllPlayers()
        {
            var players = _mapper.Map<IEnumerable<PlayerDto>>(_dbContext.Players.Include(p => p.PlayerInventories).Where(p => p.Deleted != true));
            return players;
        }

        public PlayerDto GetPlayerById(int Id)
        {
            var player = _mapper.Map<PlayerDto>(_dbContext.Players.Include(p => p.PlayerInventories).Where(p => p.Deleted != true).FirstOrDefault(p => p.Id == Id));
            if (player == null)
                throw new ExecutionError($"Player with id '{Id}' was not found");
            return player;
        }

        public PlayerDto CreatePlayer(Players player)
        {

            _dbContext.Add(player);
            _dbContext.SaveChanges();

            return _mapper.Map<PlayerDto>(player);
        }

        public bool RemovePlayer(int id)
        {
            var player = _dbContext.Players.Where(p => p.Deleted != true).FirstOrDefault(p => p.Id == id);
            if (player == null)
                throw new ExecutionError($"Player with id '{id}' was not found");

            player.Deleted = true;
            //_dbContext.Remove(player);
            _dbContext.SaveChanges();
            return true;



        }

        public IEnumerable<PlayerDto> GetPokemonOwners(string pokemonIdentifier)
        {
            var owners = _dbContext
                    .PlayerInventories
                    .Include(x => x.Player)
                    .Where(p => p.PokemonIdentifier == pokemonIdentifier && p.Player.Deleted != true)
                    .Select(p => p.Player)
                    .AsEnumerable();

            var results = _mapper.Map<IEnumerable<PlayerDto>>(owners);
            return results;
        }
    }
}
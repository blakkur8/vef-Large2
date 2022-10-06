using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Battleground.Repositories.Interfaces;
using Battleground.Repositories.Contexts;
using Battleground.Models.Dtos;
using Battleground.Repositories.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Battleground.Repositories.Implementations
{
    public class BattleRepository : IBattleRepository
    {
        private BattlegroundDbContext _dbContext;
        private readonly IMapper _mapper;
        private IBattleRepository _battleRepositoryImplementation;

        public BattleRepository(BattlegroundDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public IEnumerable<BattleDto> getAllBattles()
        {
            var battles = _mapper.Map<IEnumerable<BattleDto>>(_dbContext.Battles);
            return battles;
        }

        public async Task<BattleDto> GetBattleById(int Id)
        {
            // var battle = await _dbContext
            //                     .Battles
            //                     .Include(b => b.Status)
            //                     .Include(b => b.Winner)
            //                     .Include(b => b.PlayersInMatch)
            //                         .ThenInclude(b => b.PlayerInMatch)
            //                     .Include(b => b.BattlePokemons)
            //                         .ThenInclude(b => b.Attacks)
            //                     .FirstOrDefaultAsync(b => b.Id == Id);


            var battle = await _dbContext
                                .Battles
                                .Include(b => b.Status)
                                .Include(b => b.Winner)
                                .Include(b => b.PlayersInMatch)
                                .Include(b => b.BattlePokemons)
                                    .ThenInclude(b => b.Attacks)
                                .Select(b => new BattleDto
                                {
                                    Id = b.Id,
                                    // Status = WHUT,
                                    Winner = b.Winner.Id != null ? new PlayerDto
                                    {
                                        Id = b.Winner.Id,
                                        Name = b.Winner.Name
                                    } : null,
                                    PlayersInMatch = b.PlayersInMatch.Select(p => new PlayerDto
                                    {
                                        Id = p.PlayerInMatch.Id,
                                        Name = p.PlayerInMatch.Name
                                    }),
                                    BattlePokemons = b.BattlePokemons.Select(bp => new BattlePokemonsDto
                                    {
                                        PokemonIdentifier = bp.PokemonIdentifier,
                                        BattleId = bp.BattleId
                                    })


                                    // Attacks = b.BattlePokemons.Select(bp => bp.Attacks.Select(a => new AttackDto
                                    // {
                                    //     DamageDealt = a.Damage,
                                    //     CriticalHit = a.CriticalHit,
                                    //     SuccessfulHit = a.Success
                                    // }).FirstOrDefault())
                                }).FirstOrDefaultAsync(x => x.Id == Id);
            //                     .FirstOrDefaultAsync(x => x.Id == Id);


            // System.Console.WriteLine("Battle id:");
            // System.Console.WriteLine(battle.Id);
            // var results = _mapper.Map<BattleDto>(battle);
            return battle;

            // public int Id { get; set; }
            // public BattleStatus Status { get; set; }
            // public PlayerDto Winner { get; set; }
            // public IEnumerable<PlayerDto> PlayersInMatch { get; set; }
            // public IEnumerable<AttackDto> Attacks { get; set; }

            // var results = _mapper.Map<BattleDto>(battle);
            // return battle;

            //     Field(x => x.Id).Description("The id of the battle");
            //     Field(x => x.Status).Description("The status of the battle");
            //     Field(x => x.Winner).Description("The winner of the battle");
            //     Field(x => x.BattlePokemons).Description("The pokemons fighting in the battle");
            //     Field(x => x.PlayersInMatch).Description("The players in the battle");
            //     Field(x => x.Attacks).Description("The attacks that occured during the battle");

        }
    }
}
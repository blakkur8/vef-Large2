using Battleground.Repositories.Interfaces;
using Battleground.Repositories.Contexts;
using Battleground.Models.Dtos;
using Battleground.Repositories.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Battleground.Models.InputModels;
using GraphQL;

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
        public async Task<IEnumerable<BattleDto>> GetAllBattles(Battleground.Models.Enums.BattleStatus status)
        {
            var battles = await _dbContext
                                .Battles
                                .AsNoTracking()
                                .Include(b => b.Status)
                                .Include(b => b.Winner)
                                .Include(b => b.PlayersInMatch)
                                .Include(b => b.BattlePokemons)
                                    .ThenInclude(b => b.Attacks)
                                .Where(b => b.Status.Name == status.ToString())
                                .Select(b => new BattleDto
                                {
                                    Id = b.Id,
                                    Status =
                                        b.Status.Name == Battleground.Models.Enums.BattleStatus.NOT_STARTED.ToString()
                                            ? Battleground.Models.Enums.BattleStatus.NOT_STARTED
                                            : b.Status.Name == Battleground.Models.Enums.BattleStatus.STARTED.ToString()
                                            ? Battleground.Models.Enums.BattleStatus.STARTED
                                            : b.Status.Name == Battleground.Models.Enums.BattleStatus.FINISHED.ToString()
                                            ? Battleground.Models.Enums.BattleStatus.FINISHED
                                            : Battleground.Models.Enums.BattleStatus.FINISHED,

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
                                    }),
                                    Attacks = b.BattlePokemons.Select(bp => bp.Attacks.Select(a => new AttackDto
                                    {
                                        DamageDealt = a.Damage,
                                        SuccessfulHit = a.Success,
                                        CriticalHit = a.CriticalHit,
                                        BattlePokemons = new BattlePokemonsDto
                                        {
                                            PokemonIdentifier = a.Battle.PokemonIdentifier,
                                            BattleId = a.Battle.BattleId
                                        }
                                    })).SelectMany(r => r)
                                }).ToListAsync();
            return battles;
        }

        public async Task<BattleDto> GetBattleById(int Id)
        {

            var battle_ = await _dbContext
                                .Battles
                                .FirstOrDefaultAsync(b => b.Id == Id);

            if (battle_ == null)
                throw new ExecutionError($"Battle with id '{Id}' does not exist");

            var attacks = await _dbContext
                                .Attacks
                                .Include(a => a.Battle)
                                .Where(a => a.Battle.BattleId == Id)
                                .Select(a => new AttackDto
                                {
                                    DamageDealt = a.Damage,
                                    SuccessfulHit = a.Success,
                                    CriticalHit = a.CriticalHit,
                                    BattlePokemons = new BattlePokemonsDto
                                    {
                                        PokemonIdentifier = a.Battle.PokemonIdentifier,
                                        BattleId = a.Battle.BattleId
                                    }
                                })
                                .ToListAsync();

            var battle = await _dbContext
                                .Battles
                                .AsNoTracking()
                                .Include(b => b.Status)
                                .Include(b => b.Winner)
                                .Include(b => b.PlayersInMatch)
                                .Include(b => b.BattlePokemons)
                                    .ThenInclude(b => b.Attacks)
                                .Select(b => new BattleDto
                                {
                                    Id = b.Id,
                                    Status =
                                        b.Status.Name == Battleground.Models.Enums.BattleStatus.NOT_STARTED.ToString()
                                            ? Battleground.Models.Enums.BattleStatus.NOT_STARTED
                                            : b.Status.Name == Battleground.Models.Enums.BattleStatus.STARTED.ToString()
                                            ? Battleground.Models.Enums.BattleStatus.STARTED
                                            : b.Status.Name == Battleground.Models.Enums.BattleStatus.FINISHED.ToString()
                                            ? Battleground.Models.Enums.BattleStatus.FINISHED
                                            : Battleground.Models.Enums.BattleStatus.FINISHED,

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
                                    }),
                                    Attacks = attacks
                                }).FirstOrDefaultAsync(x => x.Id == Id);





            return battle;
        }

        public async Task<BattleDto> CreateBattle(BattleInputModel battle)
        {
            // Create empty battle
            var battles = _dbContext.Battles;

            var battleStatusNotStarted = await _dbContext.BattleStatus.FirstOrDefaultAsync(b => b.Name == "NOT_STARTED");

            var newBattle = new Battles
            {
                Status = battleStatusNotStarted,
            };

            await battles.AddAsync(newBattle);
            await _dbContext.SaveChangesAsync();
            var newBattleId = newBattle.Id;

            // Add players to match

            foreach (var playerId in battle.PlayerIds)
            {
                // var player = await _dbContext.Players.FirstOrDefaultAsync(p => p.Id == playerId);
                var battlePlayer = new BattlePlayer
                {
                    PlayerInMatchId = playerId,
                    BattleId = newBattleId
                };
                var bruh = await _dbContext.Battles.Include(b => b.PlayersInMatch).FirstOrDefaultAsync(b => b.Id == newBattleId);
                bruh.PlayersInMatch.Add(battlePlayer);

            }
            await _dbContext.SaveChangesAsync();



            // Add pokemons to match

            foreach (var pokemonId in battle.PokemonIds)
            {
                var battlePokemon = new BattlePokemons
                {
                    PokemonIdentifier = pokemonId,
                    BattleId = newBattleId
                };

                var bruh = await _dbContext.Battles.Include(b => b.BattlePokemons).FirstOrDefaultAsync(b => b.Id == newBattleId);
                bruh.BattlePokemons.Add(battlePokemon);
            }

            _dbContext.SaveChanges();


            return await GetBattleById(newBattleId);
        }

        public bool IsPlayerInBattle(int playerId)
        {
            var battles = _dbContext
                            .Battles
                            .Include(b => b.PlayersInMatch)
                            .Include(b => b.Status)
                            .Where(b => b.PlayersInMatch.Any(pm => pm.PlayerInMatchId == playerId) && b.Status.Name != Battleground.Models.Enums.BattleStatus.FINISHED.ToString())
                            .AsEnumerable();

            if (battles.Count() > 0)
            {
                return true;
            }
            return false;


        }

        public void FinishBattleAndCrownWinner(int battleId, int winnerId)
        {
            var battle = _dbContext.Battles.FirstOrDefault(b => b.Id == battleId);

            var battleStatusFinished = _dbContext.BattleStatus.FirstOrDefault(x => x.Name == "FINISHED");

            var winner = _dbContext.Players.FirstOrDefault(x => x.Id == winnerId);

            battle.Status = battleStatusFinished;
            battle.Winner = winner;
            _dbContext.SaveChanges();

        }

        public void StartBattle(int battleId)
        {
            var battle = _dbContext.Battles.FirstOrDefault(b => b.Id == battleId);
            var startedStatus = _dbContext.BattleStatus.FirstOrDefault(s => s.Name == "STARTED");

            battle.Status = startedStatus;
            _dbContext.SaveChanges();
        }
    }
}
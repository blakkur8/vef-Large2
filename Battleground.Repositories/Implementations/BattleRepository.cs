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

        public BattleDto GetBattleById(int Id)
        {
            var battle = _mapper.Map<BattleDto>(_dbContext.Battles.FirstOrDefault(x => x.Id == Id));
            return battle;
        }
    }
}
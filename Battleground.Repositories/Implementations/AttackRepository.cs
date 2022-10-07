using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Battleground.Models.Dtos;
using Battleground.Models.InputModels;
using Battleground.Repositories.Contexts;
using Battleground.Repositories.Entities;
using Battleground.Repositories.Interfaces;

namespace Battleground.Repositories.Implementations
{
    public class AttackRepository : IAttackRepository
    {
        private HttpClient _httpClient;
        private BattlegroundDbContext _dbContext;
        private readonly IMapper _mapper;
        public AttackRepository(IMapper mapper, BattlegroundDbContext dbContext, HttpClient httpClient)
        {
            _mapper = mapper;
            _dbContext = dbContext;
            _httpClient = httpClient;

        }
        public AttackDto CreateAttack(AttackInputModel attack, PokemonDto pokemon)
        {
            // need pokemon base attack
            // calculate for critical and not hitting 
            // var pokemon = _dbContext.BattlePokemons.FirstOrDefault(bp => bp.PokemonIdentifier == attack.Attacker);
            Random rnd = new Random();
            int hit = rnd.Next(0, 100);
            int crit = rnd.Next(0, 100);


            var battlePokemon = _dbContext.BattlePokemons.FirstOrDefault(bp => bp.BattleId == attack.BattleId && bp.PokemonIdentifier == attack.Attacker);

            if (pokemon == null)
            {
                throw new KeyNotFoundException();
            }

            var new_attack = new Attacks();
            new_attack.Damage = pokemon.BaseAttack;
            new_attack.Battle = battlePokemon;

            if (hit >= 15)
            {
                new_attack.Success = true;
                if (crit <= 30)
                {
                    new_attack.CriticalHit = true;
                    new_attack.Damage = Convert.ToInt32(new_attack.Damage * 1.4);
                }
                else
                {
                    new_attack.CriticalHit = false;
                }
            }
            else
            {
                new_attack.Success = false;
                new_attack.Damage = 0;
            }

            var last_attack = _dbContext.Attacks.Include(a => a.Battle).Where(a => a.Battle.BattleId == attack.BattleId).ToList().Last();
            // var last_attack = b

            if (last_attack.Battle.PokemonIdentifier == attack.Attacker)
            {
                throw new NotImplementedException();
            }
            _dbContext.Attacks.Add(new_attack);
            _dbContext.SaveChanges();
            var ret_val = _mapper.Map<AttackDto>(new_attack);
            return ret_val;

        }

    }
}
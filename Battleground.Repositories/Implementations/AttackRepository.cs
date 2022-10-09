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
            Random rnd = new Random();
            int hit = rnd.Next(0, 100);
            int crit = rnd.Next(0, 100);


            var battlePokemon = _dbContext.BattlePokemons.FirstOrDefault(bp => bp.BattleId == attack.BattleId && bp.PokemonIdentifier == attack.Attacker);
            System.Console.WriteLine("DEBUG 1!:");
            System.Console.WriteLine(battlePokemon.PokemonIdentifier);

            var new_attack = new Attacks();
            new_attack.CriticalHit = false;
            new_attack.Success = false;
            new_attack.Damage = 0;
            new_attack.Battle = battlePokemon;

            // If hit was successful (15% chance of a miss)
            if (hit >= 15)
            {
                new_attack.Success = true;
                // If hit was a critical hit (30% chance of a critical hit)
                if (crit <= 30)
                {
                    new_attack.CriticalHit = true;
                    new_attack.Damage = Convert.ToInt32(pokemon.BaseAttack * 1.4);
                }
                else
                {
                    new_attack.Damage = pokemon.BaseAttack;
                }
            }

            _dbContext.Attacks.Add(new_attack);
            _dbContext.SaveChanges();

            // var ret_val = _mapper.Map<AttackDto>(new_attack);
            var ret_val = new AttackDto
            {
                DamageDealt = new_attack.Damage,
                CriticalHit = new_attack.CriticalHit,
                SuccessfulHit = new_attack.Success,
                BattlePokemons = new BattlePokemonsDto
                {
                    BattleId = attack.BattleId,
                    PokemonIdentifier = attack.Attacker
                }
            };
            return ret_val;

        }

    }
}
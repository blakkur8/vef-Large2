using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Battleground.Models.Dtos;
using Battleground.Models.InputModels;
using Battleground.Repositories.Entities;

namespace Battleground.Repositories.Interfaces
{
    public interface IAttackRepository
    {
        public AttackDto CreateAttack(AttackInputModel attack, PokemonDto pokemon);
    }
}
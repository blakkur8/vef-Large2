using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Battleground.Models.Dtos;
using Battleground.Models.InputModels;
using Battleground.Repositories.Entities;

namespace Battleground.Services.Interfaces;

public interface IAttackService
{
    public Task<AttackDto> createAttack(AttackInputModel attack);
}

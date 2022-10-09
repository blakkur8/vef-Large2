using Battleground.Models.Dtos;
using Battleground.Models.InputModels;

namespace Battleground.Services.Interfaces;

public interface IAttackService
{
    public Task<AttackDto> CreateAttack(AttackInputModel attack);
}

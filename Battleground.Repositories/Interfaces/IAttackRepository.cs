using Battleground.Models.Dtos;
using Battleground.Models.InputModels;

namespace Battleground.Repositories.Interfaces
{
    public interface IAttackRepository
    {
        public AttackDto CreateAttack(AttackInputModel attack, PokemonDto pokemon);
    }
}
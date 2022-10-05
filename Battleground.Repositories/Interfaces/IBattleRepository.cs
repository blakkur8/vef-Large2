using Battleground.Models.Dtos;
namespace Battleground.Repositories.Interfaces;

public interface IBattleRepository
{
    public IEnumerable<BattleDto> getAllBattles();
    public BattleDto GetBattleById(int Id);

}
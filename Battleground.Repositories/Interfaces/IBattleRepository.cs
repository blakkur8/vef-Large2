using Battleground.Models.Dtos;
namespace Battleground.Repositories.Interfaces;

public interface IBattleRepository
{
    public Task<IEnumerable<BattleDto>> GetAllBattles();
    public Task<BattleDto> GetBattleById(int Id);

}
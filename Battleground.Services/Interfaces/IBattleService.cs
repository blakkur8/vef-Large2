using Battleground.Models.Dtos;
namespace Battleground.Services.Interfaces;

public interface IBattleService
{
    public Task<IEnumerable<BattleDto>> getAllBattles();
    public Task<BattleDto> GetBattleById(int Id);
}
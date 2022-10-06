using Battleground.Models.Dtos;
namespace Battleground.Services.Interfaces;

public interface IBattleService
{
    public Task<IEnumerable<BattleDto>> GetAllBattles();
    public Task<BattleDto> GetBattleById(int Id);
}
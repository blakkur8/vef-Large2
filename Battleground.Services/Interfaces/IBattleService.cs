using Battleground.Models.Dtos;
using Battleground.Models.InputModels;

namespace Battleground.Services.Interfaces;

public interface IBattleService
{
    public Task<IEnumerable<BattleDto>> GetAllBattles();
    public Task<BattleDto> GetBattleById(int Id);
    public Task<BattleDto> CreateBattle(BattleInputModel battle);
}
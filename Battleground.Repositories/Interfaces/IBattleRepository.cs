using Battleground.Models.Dtos;
using Battleground.Models.InputModels;

namespace Battleground.Repositories.Interfaces;

public interface IBattleRepository
{
    public Task<IEnumerable<BattleDto>> GetAllBattles();
    public Task<BattleDto> GetBattleById(int Id);
    public Task<BattleDto> CreateBattle(BattleInputModel battle);

}
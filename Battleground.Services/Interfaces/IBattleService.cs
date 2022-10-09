using Battleground.Models.Dtos;
using Battleground.Models.Enums;
using Battleground.Models.InputModels;

namespace Battleground.Services.Interfaces;

public interface IBattleService
{
    public Task<IEnumerable<BattleDto>> GetAllBattles(BattleStatus status);
    public Task<BattleDto> GetBattleById(int Id);
    public Task<BattleDto> CreateBattle(BattleInputModel battle);
    public void FinishBattleAndCrownWinner(int battleId, int winnerId);
    public void StartBattle(int battleId);


}
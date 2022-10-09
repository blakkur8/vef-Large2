using Battleground.Models.Dtos;
using Battleground.Models.Enums;
using Battleground.Models.InputModels;

namespace Battleground.Repositories.Interfaces;

public interface IBattleRepository
{
    public Task<IEnumerable<BattleDto>> GetAllBattles(BattleStatus status);
    public Task<BattleDto> GetBattleById(int Id);
    public Task<BattleDto> CreateBattle(BattleInputModel battle);
    public bool IsPlayerInBattle(int playerId);
    public void FinishBattleAndCrownWinner(int battleId, int winnerId);
    public void StartBattle(int battleId);

}
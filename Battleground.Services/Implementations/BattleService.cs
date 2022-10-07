using System.Net.Http.Json;
using Battleground.Models.Dtos;
using Battleground.Models.InputModels;
using Battleground.Repositories.Interfaces;
using Battleground.Services.Interfaces;

namespace Battleground.Services.Implementations;

public class BattleService : IBattleService
{
    private HttpClient _httpClient;
    private IBattleRepository _battleRepository;

    public BattleService(HttpClient httpClient, IBattleRepository battleRepository)
    {
        _httpClient = httpClient;
        _battleRepository = battleRepository;
    }

    public async Task<IEnumerable<BattleDto>> GetAllBattles() =>
        await _battleRepository.GetAllBattles();

    public async Task<BattleDto> GetBattleById(int Id) =>
        await _battleRepository.GetBattleById(Id);

    public async Task<BattleDto> CreateBattle(BattleInputModel battle) =>
        await _battleRepository.CreateBattle(battle);
}
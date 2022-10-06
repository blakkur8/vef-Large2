using System.Net.Http.Json;
using Battleground.Models.Dtos;
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
    public async Task<IEnumerable<BattleDto>?> getAllBattles() =>
        await _httpClient.GetFromJsonAsync<IEnumerable<BattleDto>>("battles");

    public async Task<BattleDto> GetBattleById(int Id) =>
        await _battleRepository.GetBattleById(Id);
    // await _httpClient.GetFromJsonAsync<BattleDto>($"battles/{Id}");
}
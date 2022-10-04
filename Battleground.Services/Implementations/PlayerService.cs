using System.Net.Http.Json;
using Battleground.Models.Dtos;
//using Battleground.Repositories.Contexts;
using Battleground.Services.Interfaces;

namespace Battleground.Services.Implementations;

public class PlayerService : IPlayerService
{
    private HttpClient _httpClient;
    //private BattlegroundDbContext _dbcontext;
    public PlayerService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public IEnumerable<PlayerDto> getAllPlayers()
    {
        throw new NotImplementedException();
    }

    public PlayerDto getPlayerById()
    {
        throw new NotImplementedException();
    }


}
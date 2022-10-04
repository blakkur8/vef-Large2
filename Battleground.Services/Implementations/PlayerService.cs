using System.Net.Http.Json;
using Battleground.Models.Dtos;
using Battleground.Repositories.Interfaces;
using Battleground.Services.Interfaces;

namespace Battleground.Services.Implementations;

public class PlayerService : IPlayerService
{
    private readonly IPlayerRepository _playerRepository;
    private HttpClient _httpClient;
    public PlayerService(HttpClient httpClient, IPlayerRepository playerRepository)
    {
        _httpClient = httpClient;
        _playerRepository = playerRepository;
    }

    public IEnumerable<PlayerDto> getAllPlayers()
    {
        throw new NotImplementedException();
    }

    public PlayerDto getPlayerById(int Id)
    {
        return _playerRepository.getPlayerById(Id);
    }


}
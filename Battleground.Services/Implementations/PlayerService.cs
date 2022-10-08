using System.Net.Http.Json;
using Battleground.Models.Dtos;
using Battleground.Models.InputModels;
using Battleground.Repositories.Interfaces;
using Battleground.Services.Interfaces;
using AutoMapper;
using Battleground.Repositories.Entities;
using GraphQL;

namespace Battleground.Services.Implementations;

public class PlayerService : IPlayerService
{
    private readonly IPlayerRepository _playerRepository;
    private HttpClient _httpClient;
    private readonly IMapper _mapper;
    public PlayerService(HttpClient httpClient, IPlayerRepository playerRepository, IMapper mapper)
    {
        _httpClient = httpClient;
        _playerRepository = playerRepository;
        _mapper = mapper;
    }

    public IEnumerable<PlayerDto> GetAllPlayers()
    {
        return _playerRepository.GetAllPlayers();
    }

    public PlayerDto GetPlayerById(int Id)
    {
        var player = _playerRepository.GetPlayerById(Id);
        if (player == null)
            throw new ExecutionError($"Player with id '{Id}' was not found");
        return player;
    }

    public PlayerDto CreatePlayer(PlayerInputModel playerModel)
    {
        var player = _mapper.Map<Players>(playerModel);
        return _playerRepository.CreatePlayer(player);
    }

    public PlayerDto RemovePlayer(int id)
    {
        return _playerRepository.RemovePlayer(id);
    }
}
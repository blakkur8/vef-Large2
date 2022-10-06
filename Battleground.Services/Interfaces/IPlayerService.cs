using Battleground.Models.Dtos;
using Battleground.Models.InputModels;
//using Battleground.Api.Schema.InputTypes;

namespace Battleground.Services.Interfaces;

public interface IPlayerService
{
    public IEnumerable<PlayerDto> getAllPlayers();

    public PlayerDto getPlayerById(int Id);

    public PlayerDto createPlayer(PlayerInputModel playerModel);

    public PlayerDto removePlayer(int id);
}
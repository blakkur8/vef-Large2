using Battleground.Models.Dtos;

namespace Battleground.Services.Interfaces;

public interface IPlayerService
{
    public IEnumerable<PlayerDto> getAllPlayers();

    public PlayerDto getPlayerById();
}
using Battleground.Models.Dtos;
using Battleground.Models.InputModels;

namespace Battleground.Services.Interfaces;

public interface IPlayerService
{
    public IEnumerable<PlayerDto> GetAllPlayers();

    public PlayerDto GetPlayerById(int Id);

    public PlayerDto CreatePlayer(PlayerInputModel playerModel);

    public bool RemovePlayer(int id);
}
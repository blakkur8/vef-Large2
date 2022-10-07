using Battleground.Models.Dtos;
using Battleground.Models.InputModels;
//using Battleground.Api.Schema.InputTypes;

namespace Battleground.Services.Interfaces;

public interface IPlayerService
{
    public IEnumerable<PlayerDto> GetAllPlayers();

    public PlayerDto GetPlayerById(int Id);

    public PlayerDto CreatePlayer(PlayerInputModel playerModel);

    public PlayerDto RemovePlayer(int id);
}
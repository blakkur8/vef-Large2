using Battleground.Models.Dtos;
using Battleground.Models.InputModels;

namespace Battleground.Services.Interfaces;

public interface IInventoryService
{
    public Task<bool> AddPokemonToInventory(InventoryInputModel inputModel);
    public Task<bool> RemovePokemonFromInventory(InventoryInputModel inputModel);
    public IEnumerable<PlayerInventoriesDto> GetPlayerInventory(int playerId);
}
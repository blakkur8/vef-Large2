using Battleground.Models.Dtos;
using Battleground.Models.InputModels;

namespace Battleground.Services.Interfaces;

public interface IInventoryService
{
    public bool AddPokemonToInventory(InventoryInputModel inputModel);
    public bool RemovePokemonToInventory(InventoryInputModel inputModel);
    public IEnumerable<PlayerInventoriesDto> GetPlayerInventory(int playerId);
}
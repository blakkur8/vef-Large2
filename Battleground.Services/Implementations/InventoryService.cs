using Battleground.Models.Dtos;
using Battleground.Models.Exceptions;
using Battleground.Models.InputModels;
using Battleground.Repositories.Interfaces;
using Battleground.Services.Interfaces;

namespace Battleground.Services.Implementations;

public class InventoryService : IInventoryService
{
    private IInventoryRepository _inventoryRepository;

    public InventoryService(IInventoryRepository inventoryRepository)
    {
        _inventoryRepository = inventoryRepository;
    }

    public bool AddPokemonToInventory(InventoryInputModel inputModel) =>
        _inventoryRepository.AddPokemonToInventory(inputModel);


    public bool RemovePokemonToInventory(InventoryInputModel inputModel) =>
        _inventoryRepository.RemovePokemonToInventory(inputModel);
    public IEnumerable<PlayerInventoriesDto> GetPlayerInventory(int playerId) =>
        _inventoryRepository.GetPlayerInventory(playerId);
}
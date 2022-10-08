using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Battleground.Models.Dtos;
using Battleground.Models.InputModels;

namespace Battleground.Repositories.Interfaces;

public interface IInventoryRepository
{
    public void AddPokemonToInventory(InventoryInputModel inputModel);
    public bool RemovePokemonFromInventory(InventoryInputModel inputModel);
    public IEnumerable<PlayerInventoriesDto> GetPlayerInventory(int playerId);
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Battleground.Models.Dtos;
using Battleground.Models.InputModels;
using Battleground.Repositories.Contexts;
using Battleground.Repositories.Entities;
using Battleground.Repositories.Interfaces;

namespace Battleground.Repositories.Implementations;

public class InventoryRepository : IInventoryRepository
{
    private BattlegroundDbContext _dbContext;
    private readonly IMapper _mapper;


    public InventoryRepository(BattlegroundDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public void AddPokemonToInventory(InventoryInputModel inputModel)
    {
        var playerInventory = new PlayerInventories
        {
            PlayerId = inputModel.PlayerId,
            PokemonIdentifier = inputModel.PokemonIdentifier,
            AcquiredDate = DateTime.Now
        };

        _dbContext.Add(playerInventory);
        _dbContext.SaveChanges();
    }


    public bool RemovePokemonFromInventory(InventoryInputModel inputModel)
    {
        var playerInventory = _dbContext.PlayerInventories.FirstOrDefault(x => x.PlayerId == inputModel.PlayerId && x.PokemonIdentifier == inputModel.PokemonIdentifier);
        _dbContext.Remove(playerInventory);
        _dbContext.SaveChanges();
        return true;
    }
    public IEnumerable<PlayerInventoriesDto> GetPlayerInventory(int playerId)
    {
        var playerInventories = _dbContext
                            .PlayerInventories
                            .Where(x => x.PlayerId == playerId)
                            .AsEnumerable();

        var results = _mapper.Map<IEnumerable<PlayerInventoriesDto>>(playerInventories);
        return results;
    }
}

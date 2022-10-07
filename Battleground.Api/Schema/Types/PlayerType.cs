using Battleground.Models.Dtos;
using Battleground.Services.Interfaces;
using GraphQL.Types;
using GraphQL;


namespace Battleground.Api.Schema.Types;

public class PlayerType : ObjectGraphType<PlayerDto>
{
    private IPokemonService _pokemonService;
    private IPlayerService _playerService;
    private IInventoryService _inventoryService;
    public PlayerType(IPokemonService pokemonService, IPlayerService playerService, IInventoryService inventoryService)
    {
        _pokemonService = pokemonService;
        Field(x => x.Id).Description("Player Id");
        Field(x => x.Name).Description("Player Name");
        Field<ListGraphType<NonNullGraphType<PokemonType>>>("Inventory")
           .ResolveAsync(async context =>
           {
               //var inventories = context.Source.PlayerInventories;
               // Gætum sótt inventory sér fyrir hverja requestu
               var inventories = _inventoryService.GetPlayerInventory(context.Source.Id);

               List<PokemonDto> list = new List<PokemonDto>();

               foreach (var inventory in inventories)
               {
                   var pokemon = await _pokemonService.GetPokemonByName(inventory.PokemonIdentifier);
                   list.Add(pokemon);
               }

               return list;
           });
        _playerService = playerService;
        _inventoryService = inventoryService;
    }
}
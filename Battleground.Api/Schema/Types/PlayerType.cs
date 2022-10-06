using Battleground.Models.Dtos;
using Battleground.Services.Interfaces;
using GraphQL.Types;
using GraphQL;


namespace Battleground.Api.Schema.Types;

public class PlayerType : ObjectGraphType<PlayerDto>
{
    private IPokemonService _pokemonService;
    public PlayerType(IPokemonService pokemonService)
    {
        _pokemonService = pokemonService;
        Field(x => x.Id).Description("Player Id");
        Field(x => x.Name).Description("Player Name");
        Field<ListGraphType<NonNullGraphType<PokemonType>>>("Inventory")
           .ResolveAsync(async context =>
           {
               var inventories = context.Source.Inventories;

               List<PokemonDto> list = new List<PokemonDto>();

               foreach (var inventory in inventories)
               {
                   var pokemon = await _pokemonService.getPokemonByName(inventory.PokemonIdentifier);
                   list.Add(pokemon);
               }

               return list;
           });
    }
}
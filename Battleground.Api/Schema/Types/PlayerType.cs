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
               var player_id = context.GetArgument<int>("Id");
               var all_pokemons = await _pokemonService.getAllPokemons();

               //var pokemon = all_pokemons.Where(pokemon => pokemon.owners.Any(owner => owner.Id == context.Source.Id));
               return null;
           });
    }
}
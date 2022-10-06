using Battleground.Models.Dtos;
using Battleground.Services.Interfaces;
using GraphQL.Types;

namespace Battleground.Api.Schema.Types;

public class PokemonType : ObjectGraphType<PokemonDto>
{
    private IPokemonService _pokemonService;
    public PokemonType(IPokemonService pokemonService)
    {
        _pokemonService = pokemonService;

        Field(x => x.Name).Description("The name of the pokemon");
        Field(x => x.HealthPoints).Description("The health points for the pokemon");
        Field(x => x.BaseAttack).Description("The base attack for the pokemon");
        Field(x => x.Weight).Description("The weight of the pokemon");
        Field<NonNullGraphType<ListGraphType<NonNullGraphType<PlayerType>>>>("owners")
           .Resolve(context =>
           {
               var owners = _pokemonService.getPokemonOwners(context.Source.Name);
               return owners;
           });
    }
}
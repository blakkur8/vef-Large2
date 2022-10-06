using Battleground.Models.Dtos;
using GraphQL.Types;

namespace Battleground.Api.Schema.Types;

public class PokemonType : ObjectGraphType<PokemonDto>
{
    public PokemonType()
    {
        Field(x => x.Name).Description("The name of the pokemon");
        Field(x => x.HealthPoints).Description("The health points for the pokemon");
        Field(x => x.BaseAttack).Description("The base attack for the pokemon");
        Field(x => x.Weight).Description("The weight of the pokemon");
        //  Field<ListGraphType<PlayerType>>("owners")
        //     .ResolveAsync(async context =>
        //     {
        //     return null;
        //     });
    }
}


/*

■ name: string*
■ baseAttack: int*
■ healthPoints: int*
■ weight: int*
■ owners: An array of PlayerType

*/
using Battleground.Models.Dtos;
using GraphQL.Types;

namespace Battleground.Models.Api.Schema.Types;

public class PlayerType : ObjectGraphType<PlayerDto>
{
    public PlayerType()
    {
        Field(x => x.Id).Description("Player Id");
        Field(x => x.Name).Description("Player Name");
        //  Field<ListGraphType<InventoryType>>("Inventory")
        //     .ResolveAsync(async context =>
        //     {
        //     return null;
        //     });
    }
}
using Battleground.Models.InputModels;
using GraphQL.Types;

namespace Battleground.Api.Schema.InputTypes;

public class InventoryInputType : InputObjectGraphType<InventoryInputModel>
{
    public InventoryInputType()
    {
        Field(x => x.PlayerId).Description("The player id accociated with their pokemon");
        Field(x => x.PokemonIdentifier).Description("The pokemon identifier accociated with their player");
    }
}
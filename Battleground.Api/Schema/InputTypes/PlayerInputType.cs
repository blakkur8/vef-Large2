using Battleground.Models.Dtos;
using Battleground.Models.InputModels;
using GraphQL.Types;



namespace Battleground.Api.Schema.InputTypes;
public class PlayerInputType : InputObjectGraphType<PlayerInputModel>
{
    public PlayerInputType()
    {
        Field(x => x.Name).Description("The name of the character");
    }


}
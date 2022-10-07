using Battleground.Models.Dtos;
using Battleground.Models.InputModels;
using GraphQL.Types;



namespace Battleground.Api.Schema.InputTypes;
public class BattleInputType : InputObjectGraphType<BattleInputModel>
{
    public BattleInputType()
    {
        Field(x => x.PlayerIds).Description("The players in the match");
        Field(x => x.PokemonIds).Description("The pokemons in the match");
    }
}
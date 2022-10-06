using GraphQL.Types;
using Battleground.Models.Dtos;

namespace Battleground.Api.Schema.Types;

public class BattleType : ObjectGraphType<BattleDto>
{
    public BattleType()
    {
        Field(x => x.Id).Description("The id of the battle");




        /*
         * status : BattleStatus
         * winner : PlayerType
         * battlePokemons : An array of the Pokemons
         * playersInMatch : An array of the PlayerType
         * attacks : an array of the AttackType
         */
    }

}

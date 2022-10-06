using Battleground.Models.Dtos;
using GraphQL.Types;

namespace Battleground.Models.Api.Schema.Types;

public class AttackType : ObjectGraphType<AttackDto>
{
    public AttackType()
    {
        Field(x => x.criticalHit).Description("Did the attack critical hit?");
        Field(x => x.successfulHit).Description("Did the attack hit?");
        Field(x => x.damageDealt).Description("How much damage did the attack do");
        
        //Attacked By?
        
    }
}
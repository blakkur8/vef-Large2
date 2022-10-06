using Battleground.Models.Dtos;
using GraphQL.Types;

namespace Battleground.Api.Schema.Types;

public class AttackType : ObjectGraphType<AttackDto>
{
    public AttackType()
    {
        Field(x => x.CriticalHit).Description("Did the attack critical hit?");
        Field(x => x.SuccessfulHit).Description("Did the attack hit?");
        Field(x => x.DamageDealt).Description("How much damage did the attack do");
        // Field(x => x.AttackedBy).Description("The pokemon that attacked");
        // Resolve that shit
        Field<ListGraphType<PokemonType>>("attackedBy")
            .Resolve(context =>
            {
                var blah = context.Source.BattlePokemons.PokemonIdentifier;
                System.Console.WriteLine("Blah be like:");
                System.Console.WriteLine(blah);
                return null;
            });
    }
}
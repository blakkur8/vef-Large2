using Battleground.Models.Dtos;
using Battleground.Services.Interfaces;
using GraphQL.Types;

namespace Battleground.Api.Schema.Types;

public class AttackType : ObjectGraphType<AttackDto>
{
    private IPokemonService _pokemonService;
    public AttackType(IPokemonService pokemonService)
    {
        Field(x => x.CriticalHit).Description("Did the attack critical hit?");
        Field(x => x.SuccessfulHit).Description("Did the attack hit?");
        Field(x => x.DamageDealt).Description("How much damage did the attack do");
        // Field(x => x.AttackedBy).Description("The pokemon that attacked");
        // Resolve that shit
        Field<PokemonType>("attackedBy")
            .ResolveAsync(async context =>
            {
                var pokemonIdentifier = context.Source.BattlePokemons.PokemonIdentifier;
                System.Console.WriteLine("Pokemon identifier be like:");
                System.Console.WriteLine(pokemonIdentifier);

                var pokemon = await _pokemonService.GetPokemonByName(pokemonIdentifier);

                return pokemon;

            });
        _pokemonService = pokemonService;
    }
}
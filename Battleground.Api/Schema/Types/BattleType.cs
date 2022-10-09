using GraphQL.Types;
using Battleground.Models.Dtos;
using Battleground.Services.Interfaces;

namespace Battleground.Api.Schema.Types;

public class BattleType : ObjectGraphType<BattleDto>
{
    private IPokemonService _pokemonService;

    public BattleType(IPokemonService pokemonService)
    {
        Field(x => x.Id).Description("The id of the battle");
        Field(x => x.Status).Description("The status of the battle");

        Field(x => x.Winner, nullable: true).Description("The winner of the battle");

        Field<NonNullGraphType<ListGraphType<NonNullGraphType<PokemonType>>>>("battlePokemons")
            .Description("The pokemons fighting in the battle")
            .ResolveAsync(async context =>
            {

                var pokemons = context.Source.BattlePokemons;

                List<PokemonDto> list = new List<PokemonDto>();

                foreach (var battlepokemon in pokemons)
                {
                    var pokemon = await _pokemonService.GetPokemonByName(battlepokemon.PokemonIdentifier);
                    list.Add(pokemon);
                }

                return list;
            });
        Field(x => x.PlayersInMatch).Description("The players in the battle");
        Field(x => x.Attacks).Description("The attacks that occured during the battle");
        _pokemonService = pokemonService;
    }
}

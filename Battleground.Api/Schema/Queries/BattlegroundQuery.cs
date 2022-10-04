using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Battleground.Models.Api.Schema.Types;
using Battleground.Services.Interfaces;
using GraphQL.Types;

namespace Battleground.Api.Schema.Queries;

public class BattlegroundQuery : ObjectGraphType
{
    private IPokemonService _pokemonService;
    public BattlegroundQuery(IPokemonService pokemonService)
    {
        Field<ListGraphType<PokemonType>>("allPokemons")
            .ResolveAsync(async context =>
            {
                // Get pokemons from pokemon service

                var pokemons = await pokemonService.getAllPokemons();



                return pokemons;
            });
        _pokemonService = pokemonService;
    }
}

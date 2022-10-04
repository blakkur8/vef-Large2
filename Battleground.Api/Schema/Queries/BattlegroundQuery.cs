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
    private IPlayerService _playerService;

    public BattlegroundQuery(IPokemonService pokemonService, IPlayerService playerService)
    {
        _pokemonService = pokemonService;
        _playerService = playerService;

        Field<ListGraphType<PokemonType>>("allPokemons")
            .ResolveAsync(async context =>
            {
                // Get pokemons from pokemon service

                var pokemons = await pokemonService.getAllPokemons();



                return pokemons;
            });

        Field<ListGraphType<PokemonType>>("allPlayers")
            .Resolve(context =>
            {
                var players = playerService.getAllPlayers();


                return players;
            });

    }
}

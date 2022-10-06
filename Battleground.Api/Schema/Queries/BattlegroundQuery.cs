using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Battleground.Api.Schema.Types;
using Battleground.Services.Interfaces;
using GraphQL;
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

        Field<ListGraphType<PlayerType>>("allPlayers")
            .Resolve(context =>
            {
                var players = playerService.getAllPlayers();

                return players;
            });

        Field<PlayerType>("player")
        .Argument<IntGraphType>("Id")
        .Resolve(context =>
        {

            var idArgument = context.GetArgument<int>("Id");

            //System.Console.Write("\n", "idArgument", "\n");
            //System.Console.Write("\n", idArgument, "\n");

            var player = playerService.getPlayerById(idArgument);

            return player;
        });

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Battleground.Api.Schema.Types;
using Battleground.Models.Enums;
using Battleground.Services.Interfaces;
using GraphQL;
using GraphQL.Types;

namespace Battleground.Api.Schema.Queries;

public class BattlegroundQuery : ObjectGraphType
{
    private IPokemonService _pokemonService;
    private IPlayerService _playerService;
    private IBattleService _battleService;

    public BattlegroundQuery(IPokemonService pokemonService, IPlayerService playerService, IBattleService battleService)
    {
        _pokemonService = pokemonService;
        _playerService = playerService;
        _battleService = battleService;

        // Returns [PokemonType!]!
        Field<NonNullGraphType<ListGraphType<NonNullGraphType<PokemonType>>>>("allPokemons")
            .ResolveAsync(async context =>
            {
                var pokemons = await pokemonService.GetAllPokemons();

                return pokemons;
            });

        // Returns PokemonType
        Field<PokemonType>("pokemon")
            .Argument<StringGraphType>("id")
            .ResolveAsync(async context =>
            {
                var name = context.GetArgument<string>("id");
                var pokemon = await pokemonService.GetPokemonByName(name);

                return pokemon;
            });

        // Returns [PlayerType!]!
        Field<NonNullGraphType<ListGraphType<NonNullGraphType<PlayerType>>>>("allPlayers")
            .Resolve(context =>
            {
                var players = playerService.GetAllPlayers();

                return players;
            });

        // Returns PlayerType
        Field<PlayerType>("player")
            .Argument<IntGraphType>("id")
            .Resolve(context =>
            {

                var idArgument = context.GetArgument<int>("id");

                var player = playerService.GetPlayerById(idArgument);

                return player;
            });


        Field<NonNullGraphType<ListGraphType<NonNullGraphType<BattleType>>>>("allBattles")
            .Argument<EnumerationGraphType<BattleStatus>>("status")
            .ResolveAsync(async context =>
            {
                var status = context.GetArgument<BattleStatus>("status");
                var battles = await battleService.GetAllBattles(status);
                return battles;
            });

        Field<BattleType>("battle")
            .Argument<IntGraphType>("id")
            .ResolveAsync(async context =>
            {
                var battleIdArg = context.GetArgument<int>("id");
                var battle = await battleService.GetBattleById(battleIdArg);
                return battle;
            });
    }
}

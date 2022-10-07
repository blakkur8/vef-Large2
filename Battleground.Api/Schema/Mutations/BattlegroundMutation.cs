using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Battleground.Api.Schema.Types;
using Battleground.Services.Interfaces;
using Battleground.Api.Schema.InputTypes;

using GraphQL;
using GraphQL.Types;
using AutoMapper;
using Battleground.Models.InputModels;

namespace Battleground.Api.Schema.Mutations
{
    public class BattlegroundMutation : ObjectGraphType
    {
        private IPokemonService _pokemonService;
        private IPlayerService _playerService;
        private IBattleService _battleService;
        private readonly IMapper _mapper;
        public BattlegroundMutation(IPokemonService pokemonService, IPlayerService playerService, IMapper mapper, IBattleService battleService)
        {
            _pokemonService = pokemonService;
            _playerService = playerService;
            _mapper = mapper;

            Field<PlayerType>("addPlayer")
                .Argument<PlayerInputType>("player")
                .Resolve(context =>
            {
                var player = context.GetArgument<PlayerInputModel>("player");
                return _playerService.createPlayer(player);

            });

            Field<PlayerType>("removePlayer")
                .Argument<IntGraphType>("id")
                .Resolve(context =>
                {
                    var idArgument = context.GetArgument<int>("id");
                    return _playerService.removePlayer(idArgument);
                });

            Field<BattleType>("addBattle")
                .Argument<BattleInputType>("battle")
                .ResolveAsync(async context =>
                {
                    var battle = context.GetArgument<BattleInputModel>("battle");
                    // TODO: Validate input, does pokemon exist with the given id?
                    var newBattle = await _battleService.CreateBattle(battle);

                    return null;
                });
            _battleService = battleService;
        }
    }
}
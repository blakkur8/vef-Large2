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
        private readonly IMapper _mapper;
        public BattlegroundMutation(IPokemonService pokemonService, IPlayerService playerService, IMapper mapper)
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
        }
    }
}
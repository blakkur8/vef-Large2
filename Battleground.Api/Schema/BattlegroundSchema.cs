using System;
using GraphQL;
using GraphQL.Types;
using GraphQL.Instrumentation;
using Battleground.Api.Schema.Queries;
using Battleground.Api.Schema.Mutations;
using Battleground.Api.Schema.InputTypes;
using Battleground.Models.InputModels;
namespace Battleground.Api.Schema;

public class BattlegroundSchema : GraphQL.Types.Schema
{
    public BattlegroundSchema(IServiceProvider provider)
        : base(provider)
    {


        Query = provider.GetRequiredService<BattlegroundQuery>();
        Mutation = provider.GetRequiredService<BattlegroundMutation>();

        RegisterType(typeof(PlayerInputType));
        RegisterTypeMapping(typeof(PlayerInputModel), typeof(PlayerInputType));

        FieldMiddleware.Use(new InstrumentFieldsMiddleware());
    }
}
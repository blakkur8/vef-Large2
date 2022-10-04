using System;
using GraphQL;
using GraphQL.Types;
using GraphQL.Instrumentation;
using Battleground.Api.Schema.Queries;

namespace Battleground.Api.Schema;

public class BattlegroundSchema : GraphQL.Types.Schema
{
    public BattlegroundSchema(IServiceProvider provider)
        : base(provider)
    {

        Query = provider.GetRequiredService<BattlegroundQuery>();

        FieldMiddleware.Use(new InstrumentFieldsMiddleware());
    }
}
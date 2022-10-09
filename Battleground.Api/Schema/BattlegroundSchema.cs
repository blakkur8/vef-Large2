using GraphQL.Instrumentation;
using Battleground.Api.Schema.Queries;
using Battleground.Api.Schema.Mutations;
using Battleground.Models.Dtos;
using Battleground.Api.Schema.Types;

namespace Battleground.Api.Schema;

public class BattlegroundSchema : GraphQL.Types.Schema
{
    public BattlegroundSchema(IServiceProvider provider)
        : base(provider)
    {
        Query = provider.GetRequiredService<BattlegroundQuery>();
        Mutation = provider.GetRequiredService<BattlegroundMutation>();

        RegisterType(typeof(PlayerType));
        RegisterTypeMapping(typeof(PlayerDto), typeof(PlayerType));

        RegisterType(typeof(PokemonType));
        RegisterTypeMapping(typeof(PokemonDto), typeof(PokemonType));


        RegisterType(typeof(AttackType));
        RegisterTypeMapping(typeof(AttackDto), typeof(AttackType));

        // RegisterType(typeof(PlayerType));
        // RegisterTypeMapping(typeof(PlayerDto), typeof(PlayerType));

        FieldMiddleware.Use(new InstrumentFieldsMiddleware());
    }
}
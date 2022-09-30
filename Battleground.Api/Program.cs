using Battleground.Api.Schema;
using Battleground.Services.Implementations;
using Battleground.Services.Interfaces;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDefer();
builder.Services.AddHttpScope();

builder.Services.AddTransient<IPokemonService, PokemonService>();
builder.Services.AddTransient<IPlayerService, PlayerService>();
builder.Services.AddTransient<IBattleService, BattleService>();
builder.Services.AddTransient<IInventoryService, InventoryService>();

builder.Services.AddGraphQL(qlBuilder => qlBuilder
    .AddSystemTextJson()
    .AddErrorInfoProvider(opt => opt.ExposeExceptionDetails = true) // debug shit
    .AddSchema<BattlegroundSchema>() // tekur við týpu af schema sem við þurfum að define-a
    .AddGraphTypes() // graph týpurnar sem við skilgreinum í schema verða registeraðar automatically í dependency injection ruslinu
    .AddDataLoader());

var app = builder.Build();

app.UseGraphQLPlayground();
app.UseGraphQL<ISchema>();
app.MapGet("/", context =>
{
    context.Response.Redirect("/ui/playground");
    return Task.CompletedTask;
});

app.Run();

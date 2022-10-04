using Battleground.Api.Schema;
using Battleground.Repositories.Contexts;
using Battleground.Repositories.Implementations;
using Battleground.Repositories.Interfaces;
using Battleground.Services.Implementations;
using Battleground.Services.Interfaces;
using GraphQL;
using GraphQL.Types;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDefer();
builder.Services.AddHttpScope();


builder.Services.AddTransient<IPokemonService, PokemonService>();

builder.Services.AddTransient<IPlayerService, PlayerService>();
builder.Services.AddTransient<IPlayerRepository, PlayerRepository>();

builder.Services.AddTransient<IBattleService, BattleService>();
builder.Services.AddTransient<IInventoryService, InventoryService>();

builder.Services.AddHttpClient<IPokemonService, PokemonService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("PokemonApiBaseUrl"));
});

// Add DI for DbContext
builder.Services.AddDbContext<BattlegroundDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("BattlegroundConnectionString"),
    b => b.MigrationsAssembly("Battleground.Api"));
});

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

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

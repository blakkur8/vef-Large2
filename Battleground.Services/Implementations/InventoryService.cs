using Battleground.Models.Dtos;
using Battleground.Models.InputModels;
using Battleground.Repositories.Interfaces;
using Battleground.Services.Interfaces;
using GraphQL;

namespace Battleground.Services.Implementations;

public class InventoryService : IInventoryService
{
    private IInventoryRepository _inventoryRepository;
    private IPokemonService _pokemonService;
    private IPlayerService _playerService;

    public InventoryService(IInventoryRepository inventoryRepository, IPokemonService pokemonService, IPlayerService playerService)
    {
        _inventoryRepository = inventoryRepository;
        _pokemonService = pokemonService;
        _playerService = playerService;
    }

    public async Task<bool> AddPokemonToInventory(InventoryInputModel inputModel)
    {
        // Does player exist?
        // If not, the method already throws an exception
        var player = _playerService.GetPlayerById(inputModel.PlayerId);

        // Does player have a max inventory capacity?
        // If so, throw an exception
        var inventory = GetPlayerInventory(player.Id);
        if (inventory.Count() >= 10)
            throw new ExecutionError($"Player with id '{player.Id}' has a full inventory (10 pokemons max)");


        var pokemon = await _pokemonService.GetPokemonByName(inputModel.PokemonIdentifier);
        // Check if the pokemon would be a duplicate in the current inventory
        // Throw exception
        if (_pokemonService.PokemonIsOwnedBy(pokemon, player.Id))
            throw new ExecutionError($"Player with id '{player.Id}' already owns '{pokemon.Name}' in their inventory");

        // Check if the pokemon exists in another inventory
        // Throw exception

        if (_pokemonService.PokemonHasOwner(pokemon))
            throw new ExecutionError($"The pokemon already has another owner");

        // Else, the pokemon is not currently owned by anyone

        _inventoryRepository.AddPokemonToInventory(inputModel);
        return true;
    }


    public async Task<bool> RemovePokemonFromInventory(InventoryInputModel inputModel)
    {

        // Check if player exists
        var player = _playerService.GetPlayerById(inputModel.PlayerId);

        // Check if pokemon exists
        var pokemon = await _pokemonService.GetPokemonByName(inputModel.PokemonIdentifier);

        System.Console.WriteLine("pokemon id:");
        System.Console.WriteLine(pokemon.Name);


        // Check if pokemon is in their inventory, if not throw exception
        var inventory = GetPlayerInventory(player.Id);

        bool pokemonExistsInTheirInventory = false;
        foreach (var item in inventory)
        {
            if (item.PokemonIdentifier == pokemon.Name)
            {
                pokemonExistsInTheirInventory = true;
                break;
            }
        }
        if (pokemonExistsInTheirInventory != true)
            throw new ExecutionError($"Pokemon '{pokemon.Name}' does not exist in player '{player.Id}' inventory");


        _inventoryRepository.RemovePokemonFromInventory(inputModel);
        return true;
    }
    public IEnumerable<PlayerInventoriesDto> GetPlayerInventory(int playerId) =>
        _inventoryRepository.GetPlayerInventory(playerId);


}
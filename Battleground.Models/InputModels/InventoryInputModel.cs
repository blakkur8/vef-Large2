using System.ComponentModel.DataAnnotations;

namespace Battleground.Models.InputModels;

public class InventoryInputModel
{
    [Required]
    public int PlayerId { get; set; }
    [Required]
    public string PokemonIdentifier { get; set; }
}
using System.ComponentModel.DataAnnotations;

namespace Battleground.Models.InputModels;

public class BattleInputModel
{
    [Required]
    public IEnumerable<int> PlayerIds { get; set; }

    [Required]
    public IEnumerable<string> PokemonIds { get; set; }
}
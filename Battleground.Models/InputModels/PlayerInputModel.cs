using System.ComponentModel.DataAnnotations;


namespace Battleground.Models.InputModels;

public class PlayerInputModel
{
    [Required]
    public string Name { get; set; }
}
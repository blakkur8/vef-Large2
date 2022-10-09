namespace Battleground.Repositories.Entities;

public class PlayerInventories
{
    public string PokemonIdentifier { get; set; }
    public int PlayerId { get; set; }
    public DateTime AcquiredDate { get; set; }

    // Navigation properties
    public Players Player { get; set; }
}

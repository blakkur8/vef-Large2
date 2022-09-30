namespace Battleground.Api.Schema.InputTypes;

public class BattleInputType
{
    // TODO: "the array cannot be null nor the items within the array"
    public ICollection<int> PlayerIds { get; set; }

    public ICollection<int> PokemonIds { get; set; }
}
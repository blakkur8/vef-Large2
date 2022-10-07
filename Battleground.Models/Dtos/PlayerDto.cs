namespace Battleground.Models.Dtos;

public class PlayerDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public IEnumerable<PlayerInventoriesDto> PlayerInventories { get; set; }

}
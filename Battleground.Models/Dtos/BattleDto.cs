using Battleground.Models.Enums;

namespace Battleground.Models.Dtos;

public class BattleDto
{
    public int Id { get; set; }
    // public BattleStatus Status { get; set; }
    public PlayerDto? Winner { get; set; }
    public IEnumerable<BattlePokemonsDto> BattlePokemons { get; set; }
    public IEnumerable<PlayerDto>? PlayersInMatch { get; set; }
    // public IEnumerable<AttackDto> Attacks { get; set; }

}
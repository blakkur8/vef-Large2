using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Battleground.Repositories.Entities;

public class Battles
{
    public int Id { get; set; }
    public int? WinnerId { get; set; } = -1;

    // Navigation properties
    public Players Winner { get; set; }
    public ICollection<BattlePlayer> PlayersInMatch { get; set; }
    public BattleStatus Status { get; set; }
    public ICollection<BattlePokemons> BattlePokemons { get; set; }
}

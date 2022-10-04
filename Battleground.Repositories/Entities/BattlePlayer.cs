using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Battleground.Repositories.Entities;

public class BattlePlayer
{
    public int BattleId { get; set; }
    public int PlayerInMatchId { get; set; }

    // Navigation properties
    public Players PlayerInMatch { get; set; }
    public Battles Battle { get; set; }

}

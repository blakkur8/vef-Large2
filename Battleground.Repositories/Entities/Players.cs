using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Battleground.Repositories.Entities;

public class Players
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool Deleted { get; set; }

    // Navigation properties
    public ICollection<BattlePlayer> PlayerInMatch { get; set; }
    public ICollection<PlayerInventories> PlayerInventories { get; set; }


}

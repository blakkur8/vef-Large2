using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Battleground.Repositories.Entities;

public class BattleStatus
{
    public int Id { get; set; }
    public string Name { get; set; }

    // Navigation properties
    public ICollection<Battles> Battles { get; set; }

}

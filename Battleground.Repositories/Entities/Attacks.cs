using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Battleground.Repositories.Entities;

public class Attacks
{
    public int Id { get; set; }
    public bool Success { get; set; }
    public bool CriticalHit { get; set; }
    public int Damage { get; set; }

    // Navigation properties
    public BattlePokemons Battle { get; set; }
}

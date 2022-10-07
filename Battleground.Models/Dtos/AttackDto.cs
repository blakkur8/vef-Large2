namespace Battleground.Models.Dtos;

public class AttackDto
{
    public int DamageDealt { get; set; }
    public bool CriticalHit { get; set; }
    public bool SuccessfulHit { get; set; }
    public BattlePokemonsDto BattlePokemons { get; set; }
    //public PokemonDto AttackedBy { get; set; }
}
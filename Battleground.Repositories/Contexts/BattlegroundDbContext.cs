using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Battleground.Repositories.Entities;
using Microsoft.EntityFrameworkCore;

namespace Battleground.Repositories.Contexts;

public class BattlegroundDbContext : DbContext
{
    public BattlegroundDbContext(DbContextOptions<BattlegroundDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Manual configuration of relations (many-to-many)
        modelBuilder.Entity<PlayerInventories>()
            .HasKey(x => new { x.PlayerId, x.PokemonIdentifier });
        modelBuilder.Entity<BattlePokemons>()
            .HasKey(x => new { x.BattleId, x.PokemonIdentifier });
        modelBuilder.Entity<BattlePlayer>()
            .HasKey(x => new { x.PlayerInMatchId, x.BattleId });
        // modelBuilder.Entity<Attacks>()
        // Configure foreign key stuff maybe?
    }
    public DbSet<Attacks> Attacks { get; set; }
    public DbSet<BattlePokemons> BattlePokemons { get; set; }
    public DbSet<Battles> Battles { get; set; }
    public DbSet<BattleStatus> BattleStatus { get; set; }
    public DbSet<PlayerInventories> PlayerInventories { get; set; }
    public DbSet<Players> Players { get; set; }

}

using DiceCream.DCorp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DiceCream.DCorp.Infrastructure
{
    public class DCorpDbContext : DbContext
    {
        public DCorpDbContext(DbContextOptions<DCorpDbContext> options) : base(options) { }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<DungeonMaster> DungeonMasters { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Statistic> Statistics { get; set; }
        public DbSet<Rule> Rules { get; set; }
        public DbSet<PlayerBuildingContribution> PlayerBuildingContributions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PlayerBuildingContribution>()
                .HasKey(pc => new { pc.PlayerId, pc.BuildingId });

            modelBuilder.Entity<PlayerBuildingContribution>()
                .HasOne(pc => pc.Player)
                .WithMany(p => p.BuildingContributions)
                .HasForeignKey(pc => pc.PlayerId);

            modelBuilder.Entity<PlayerBuildingContribution>()
                .HasOne(pc => pc.Building)
                .WithMany(b => b.PlayerContributions)
                .HasForeignKey(pc => pc.BuildingId);

        }
    }
}

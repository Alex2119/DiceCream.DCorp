using DiceCream.DCorp.Infrastructure.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DiceCream.DCorp.Infrastructure;
public class DCorpDbContext : IdentityDbContext<User, Role, int>
{
    public DCorpDbContext(DbContextOptions<DCorpDbContext> options) : base(options) { }

    public DbSet<Building> Buildings { get; set; }
    public DbSet<Session> Sessions { get; set; }
    public DbSet<Skill> Skills { get; set; }
    public DbSet<Statistic> Statistics { get; set; }
    public DbSet<Rule> Rules { get; set; }
    public DbSet<IdentityUserRole<int>> IdentityUserRole { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<PlayerBuildingContribution> PlayerBuildingContributions { get; set; }
    public DbSet<PlayerSkill> PlayerSkills { get; set; }
    public DbSet<PlayerProfile> PlayerProfiles { get; set; }
    public DbSet<DungeonMasterProfile> DungeonMasterProfiles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //// User to Role
        //modelBuilder.Entity<IdentityUserRole<int>>()
        //    .HasOne<IdentityRole<int>>()
        //    .WithMany()
        //    .HasForeignKey(ur => ur.RoleId)
        //    .OnDelete(DeleteBehavior.Cascade);

        //modelBuilder.Entity<IdentityUserRole<int>>()
        //    .HasOne<IdentityUser<int>>()
        //    .WithMany()
        //    .HasForeignKey(ur => ur.UserId)
        //    .OnDelete(DeleteBehavior.Cascade);

        // PlayerProfile to Session (historique des sessions)
        modelBuilder.Entity<PlayerProfile>()
            .HasMany(p => p.SessionHistory)
            .WithMany(s => s.Participants)
            .UsingEntity<Dictionary<string, object>>(
                "PlayerSession",
                ps => ps.HasOne<Session>().WithMany().HasForeignKey("SessionId"),
                ps => ps.HasOne<PlayerProfile>().WithMany().HasForeignKey("PlayerProfileId"));

        // PlayerProfile to Skill (compétences permanentes)
        modelBuilder.Entity<PlayerProfile>()
            .HasMany(p => p.AcquiredSkills)
            .WithMany()
            .UsingEntity<Dictionary<string, object>>(
                "PlayerSkill",
                ps => ps.HasOne<Skill>().WithMany().HasForeignKey("SkillId"),
                ps => ps.HasOne<PlayerProfile>().WithMany().HasForeignKey("PlayerProfileId"));

        // DungeonMasterProfile to Session (sessions dirigées)
        modelBuilder.Entity<DungeonMasterProfile>()
            .HasMany(d => d.SessionDirected)
            .WithOne(s => s.DungeonMaster)
            .HasForeignKey(s => s.DungeonMasterProfileId);

        // Building relations
        modelBuilder.Entity<Building>()
            .Property(b => b.IsUnlocked)
            .IsRequired();

        // Statistic setup
        modelBuilder.Entity<Statistic>()
            .HasKey(s => s.Id);

        // Rule setup with author relation
        modelBuilder.Entity<Rule>()
            .HasOne(r => r.Author)
            .WithMany()
            .HasForeignKey(r => r.DungeonMasterProfileId);

        // PlayerProfile to Statistic (characteristics)
        modelBuilder.Entity<PlayerProfile>()
            .OwnsOne(p => p.Stats);

        // PlayerProfile to User (identity)
        modelBuilder.Entity<PlayerBuildingContribution>()
            .HasKey(pbc => new { pbc.UserId, pbc.BuildingId });

        // PlayerProfile to Skill (compétences temporaires)
        modelBuilder.Entity<PlayerSkill>()
            .HasKey(ps => new { ps.PlayerProfileId, ps.SkillId });
    }
}

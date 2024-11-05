namespace DiceCream.DCorp.Infrastructure;
public class DCorpDbContext : Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext<User, Role, int>
{
    public DCorpDbContext(DbContextOptions<DCorpDbContext> options) : base(options) { }
    public DbSet<Building> Buildings { get; set; }
    public DbSet<Session> Sessions { get; set; }
    public DbSet<Skill> Skills { get; set; }
    public DbSet<Statistic> Statistics { get; set; }
    public DbSet<Rule> Rules { get; set; }
    public DbSet<PlayerBuildingContribution> PlayerBuildingContributions { get; set; }
    public DbSet<PlayerSkill> PlayerSkills { get; set; }
    public DbSet<PlayerProfile> PlayerProfiles { get; set; }
    public DbSet<DungeonMasterProfile> DungeonMasterProfiles { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // PlayerBuildingContribution relationships
        builder.Entity<PlayerBuildingContribution>()
            .HasKey(pc => new { pc.UserId, pc.BuildingId });

        builder.Entity<PlayerBuildingContribution>()
            .HasOne(pc => pc.User)
            .WithMany(u => u.PlayerBuildingContributions)
            .HasForeignKey(pc => pc.UserId);

        builder.Entity<PlayerBuildingContribution>()
            .HasOne(pc => pc.Building)
            .WithMany(b => b.PlayerContributions)
            .HasForeignKey(pc => pc.BuildingId);

        // Identity User-Role configuration
        builder.Entity<UserRole>()
            .HasOne(ur => ur.User)
            .WithMany(u => u.UserRoles)
            .HasForeignKey(ur => ur.UserId);

        builder.Entity<UserRole>()
            .HasOne(ur => ur.Role)
            .WithMany(r => r.UserRoles)
            .HasForeignKey(ur => ur.RoleId);

        // Relation entre PlayerProfile et Skill
        builder.Entity<PlayerProfile>()
            .HasMany(p => p.PlayerSkills)
            .WithOne(ps => ps.PlayerProfile)
            .HasForeignKey(ps => ps.PlayerProfileId);

        builder.Entity<Session>()
            .HasMany(s => s.Participants)
            .WithMany(u => u.SessionHistory);

        // Configure User <-> PlayerProfile relationship
        builder.Entity<PlayerProfile>()
        .HasKey(pp => pp.Id);

        builder.Entity<User>()
            .HasOne(u => u.PlayerProfile)
            .WithOne(p => p.User)
            .HasForeignKey<PlayerProfile>(p => p.UserId);

        // Configure User <-> DungeonMasterProfile relationship
        builder.Entity<User>()
            .HasOne(u => u.DungeonMasterProfile)
            .WithOne(d => d.User)
            .HasForeignKey<DungeonMasterProfile>(d => d.UserId);

        // Relation entre DungeonMasterProfile et Session
        builder.Entity<Session>()
            .HasOne(s => s.DungeonMaster)
            .WithMany(d => d.SessionDirected)
            .HasForeignKey(s => s.DungeonMasterProfileId)
            .OnDelete(DeleteBehavior.NoAction);

        // Relation entre PlayerProfile et Statistic
        builder.Entity<PlayerProfile>()
            .HasMany(p => p.Stats)
            .WithOne(ps => ps.PlayerProfile)
            .HasForeignKey(ps => ps.PlayerProfileId);

        builder.Entity<PlayerSkill>()
            .HasKey(ps => new { ps.PlayerProfileId, ps.SkillId });

        builder.Entity<PlayerSkill>()
            .HasOne(ps => ps.PlayerProfile)
            .WithMany(p => p.PlayerSkills)  // Navigation dans PlayerProfile
            .HasForeignKey(ps => ps.PlayerProfileId);

        builder.Entity<PlayerSkill>()
            .HasOne(ps => ps.Skill)
            .WithMany(s => s.AssignedToPlayers)  // Navigation dans Skill
            .HasForeignKey(ps => ps.SkillId);

        builder.Entity<PlayerStatistic>()
            .HasKey(ps => new { ps.PlayerProfileId, ps.StatisticId });

        builder.Entity<PlayerStatistic>()
            .HasOne(ps => ps.PlayerProfile)
            .WithMany(p => p.Stats)
            .HasForeignKey(ps => ps.PlayerProfileId);

        builder.Entity<PlayerStatistic>()
            .HasOne(ps => ps.Statistic)
            .WithMany()
            .HasForeignKey(ps => ps.StatisticId);

    }
}

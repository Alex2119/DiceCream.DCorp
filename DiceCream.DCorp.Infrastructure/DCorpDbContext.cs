using DiceCream.DCorp.Infrastructure.Models;

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
    }
}

namespace DiceCream.DCorp.Infrastructure.Models;

public class User : IdentityUser<int>
{
    public ICollection<UserRole> UserRoles { get; set; }
    public ICollection<PlayerBuildingContribution> PlayerBuildingContributions { get; set; }
    public PlayerProfile PlayerProfile { get; set; }
    public DungeonMasterProfile DungeonMasterProfile { get; set; }
    public ICollection<Session> SessionHistory { get; set; }
}

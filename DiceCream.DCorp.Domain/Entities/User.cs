using Microsoft.AspNetCore.Identity;

namespace DiceCream.DCorp.Domain.Entities
{
    public class User : IdentityUser<int>
    {
        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<PlayerBuildingContribution> PlayerBuildingContributions { get; set; }
        public PlayerProfile PlayerProfile { get; set; }
        public DungeonMasterProfile DungeonMasterProfile { get; set; }
        public ICollection<Session> SessionHistory { get; set; }
    }
}

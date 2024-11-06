namespace DiceCream.DCorp.Domain.Entities;

public class Identity
{
    public User User { get; set; }
    public Role Role { get; set; }  
    public UserRole UserRole { get; set; }
    public DungeonMasterProfile DungeonMasterProfile { get; set; }
}

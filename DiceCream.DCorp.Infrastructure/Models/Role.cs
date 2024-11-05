namespace DiceCream.DCorp.Infrastructure.Models;
public class Role : IdentityRole<int>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<UserRole> UserRoles { get; set; }
}

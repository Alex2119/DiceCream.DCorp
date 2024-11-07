using DiceCream.DCorp.Infrastructure.Models;

namespace DiceCream.DCorp.Application.Services;

public class UserRoleService : IUserRoleService
{
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<IdentityRole<int>> _roleManager;
    private readonly DCorpDbContext _context;

    public UserRoleService(UserManager<User> userManager, RoleManager<IdentityRole<int>> roleManager, DCorpDbContext context)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _context = context;
    }
    public async Task CreateUserWithRoleAsync(string email, string password, string role)
    {
        var user = new User { UserName = email, Email = email };
        var result = await _userManager.CreateAsync(user, password);

        if(result.Succeeded)
        {
            if(!await _roleManager.RoleExistsAsync(role))
            {
                await _roleManager.CreateAsync(new Role { Name = role });
            }
            await _userManager.AddToRoleAsync(user, role);
        }
    }
    public async Task AssignRoleAndProfileAsync(User user, string roleName)
    {
        // Check if role exists, if not, create it
        if(!await _roleManager.RoleExistsAsync(roleName))
        {
            await _roleManager.CreateAsync(new IdentityRole<int>(roleName));
        }

        // Assign the role to the user
        await _userManager.AddToRoleAsync(user, roleName);

        // Create specific profile based on role
        if(roleName == "Player")
        {
            var playerProfile = new PlayerProfile
            {
                UserId = user.Id,
                Level = 1,
                Xp = 0,
                Sp = 0,
                Hp = 100,
            };

            _context.PlayerProfiles.Add(playerProfile);
        }
        else if(roleName == "DungeonMaster")
        {
            var dungeonMasterProfile = new DungeonMasterProfile
            {
                UserId = user.Id,
                SessionDirected = new List<Session>() // Start with an empty session list
            };

            _context.DungeonMasterProfiles.Add(dungeonMasterProfile);
        }

        // Save the changes to the database
        await _context.SaveChangesAsync();
    }
}

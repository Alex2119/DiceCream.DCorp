namespace DiceCream.DCorp.Infrastructure.Repositories;

public class Repository : IRepository
{
    private readonly DCorpDbContext _context;

    public Repository(DCorpDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Player> GetPlayers()
    {
        return (IEnumerable<Player>)_context.PlayerProfiles;
    }

    public async Task<Player> GetPlayerByIdAsync(int id)
    {
        return await _context.Player.Include(p => p.PlayerProfile)
                                     .Include(p => p.PlayerSkills)
                                     .FirstOrDefaultAsync(p => p.PlayerProfile.Id == id);
    }
}

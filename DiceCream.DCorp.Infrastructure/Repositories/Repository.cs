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

    public async Task<PlayerProfile> GetPlayerByIdAsync(int playerId)
    {
        return await _context.PlayerProfiles
            .Include(p => p.PlayerSkills)
            .ThenInclude(ps => ps.Skill)
            .FirstOrDefaultAsync(p => p.Id == playerId);
    }

}

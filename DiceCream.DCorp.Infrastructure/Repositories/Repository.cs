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
        return (IEnumerable<Player>)_context.PlayerSkills;
    }
}

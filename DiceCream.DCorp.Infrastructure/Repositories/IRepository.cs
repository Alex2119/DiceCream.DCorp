namespace DiceCream.DCorp.Infrastructure.Repositories;

public interface IRepository
{
    IEnumerable<Player> GetPlayers();
}

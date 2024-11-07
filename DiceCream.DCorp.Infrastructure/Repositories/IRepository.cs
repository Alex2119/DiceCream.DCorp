namespace DiceCream.DCorp.Infrastructure.Repositories;

public interface IRepository
{
    IEnumerable<Player> GetPlayers();
    Task<PlayerProfile> GetPlayerByIdAsync(int playerId);

}

using DiceCream.DCorp.Application.DTO;
using DiceCream.DCorp.Infrastructure.Models;

namespace DiceCream.DCorp.Infrastructure.Repositories;

public interface IRepository
{
    IEnumerable<PlayerDTO> GetPlayers();
    Task<PlayerProfile> GetPlayerByIdAsync(int playerId);

}

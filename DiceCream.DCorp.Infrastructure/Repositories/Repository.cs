using DiceCream.DCorp.Application.DTO;
using DiceCream.DCorp.Infrastructure.Models;

namespace DiceCream.DCorp.Infrastructure.Repositories;

public class Repository : IRepository
{
    private readonly DCorpDbContext _context;

    public Repository(DCorpDbContext context)
    {
        _context = context;
    }

    public IEnumerable<PlayerDTO> GetPlayers()
    {
        return [.. _context.PlayerProfiles
            .Select(p => new PlayerDTO
            {
                Id = p.Id,
                Nickname = p.Nickname,
                Level = p.Level,
                AcquiredSkills = p.AcquiredSkills.Select(ps => new SkillDTO
                {
                    Id = ps.Id,
                    Name = ps.Name ?? string.Empty,
                    Effect = ps.Effect ?? string.Empty,
                    IsPermanent = ps.IsPermanent,
                })
                .ToList()
            })];
    }

    public async Task<PlayerProfile?> GetPlayerByIdAsync(int playerId)
    {
        return await _context.PlayerProfiles
            .Include(p => p.PlayerSkills)
            .ThenInclude(ps => ps.Skill)
            .FirstOrDefaultAsync(p => p.Id == playerId);
    }

    Task<PlayerProfile> IRepository.GetPlayerByIdAsync(int playerId)
    {
        throw new NotImplementedException();
    }
}

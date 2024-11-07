using DiceCream.DCorp.Infrastructure.Models;

namespace DiceCream.DCorp.Application.Extensions;

public static class MapperDTO
{
    public static PlayerDTO ToDTO(this PlayerProfile playerProfile)
    {
        return new PlayerDTO
        {
            Id = playerProfile.Id,
            Nickname = playerProfile.Nickname,
            Level = playerProfile.Level,
            Xp = playerProfile.Xp,
            // A faire via une methode d'extension (y'aura du yield)
            AcquiredSkills = playerProfile.PlayerSkills.Select(ps => new SkillDTO
            {
                Id = ps.Skill.Id,
                Name = ps.Skill.Name,
                Effect = ps.Skill.Effect,
                IsPermanent = ps.Skill.IsPermanent
            }).ToList().AsReadOnly()
        };
    }
}
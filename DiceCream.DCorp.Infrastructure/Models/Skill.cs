using DiceCream.DCorp.Application.DTO;

namespace DiceCream.DCorp.Infrastructure.Models;
public class Skill
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Effect { get; set; }
    public string? Universe { get; set; }
    public bool IsPermanent { get; set; }
    public ICollection<PlayerSkill> AssignedToPlayers { get; set; }

    public static implicit operator Skill(SkillDTO v)
    {
        throw new NotImplementedException();
    }
}

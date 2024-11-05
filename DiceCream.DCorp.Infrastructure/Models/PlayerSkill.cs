namespace DiceCream.DCorp.Infrastructure.Models;
public class PlayerSkill
{
    public int PlayerProfileId { get; set; }
    public PlayerProfile PlayerProfile { get; set; }
    public int SkillId { get; set; }
    public Skill Skill { get; set; }
    public bool IsPermanent { get; set; }
    public DateTime AquisitionDate { get; set; } = DateTime.Now;
}

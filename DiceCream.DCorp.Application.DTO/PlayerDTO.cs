namespace DiceCream.DCorp.Application.DTO;

public class PlayerDTO
{
    public int Id { get; set; }
    public string Nickname { get; set; }
    public int Level { get; set; }
    public int Xp { get; set; }
    public IReadOnlyList<SkillDTO>? AcquiredSkills { get; set; }
    public IReadOnlyList<SessionDTO>? SessionHistory { get; set; }
    public StatisticDTO Stats { get; set; }
}

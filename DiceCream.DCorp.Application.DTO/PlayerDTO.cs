namespace DiceCream.DCorp.Application.DTO;

public class PlayerDTO
{
    public int Id { get; set; }
    public string Nickname { get; set; }
    public int Level { get; set; }
    public int Xp { get; set; }
    public List<SkillDTO> AcquiredSkills { get; set; } = new();
    public List<SessionDTO> SessionHistory { get; set; } = new();
    public StatisticDTO Stats { get; set; }
}

namespace DiceCream.DCorp.Domain.Entities;

public class Game
{
    public Building Building { get; set; }
    public Session Session { get; set; }
    public Rule Rule { get; set; }
    public Skill Skill { get; set; }
    public Statistic Statistic { get; set; }
}

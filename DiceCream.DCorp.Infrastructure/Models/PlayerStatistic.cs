namespace DiceCream.DCorp.Infrastructure.Models;

public class PlayerStatistic
{
    public int PlayerProfileId { get; set; }
    public PlayerProfile PlayerProfile { get; set; }
    public int StatisticId { get; set; }
    public Statistic Statistic { get; set; }
    public DateTime AquisitionDate { get; set; } = DateTime.Now;
    public int Value { get; set; } // Valeur de la statistique pour ce joueur
}

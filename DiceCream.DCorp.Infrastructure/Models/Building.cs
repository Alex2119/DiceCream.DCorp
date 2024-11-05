namespace DiceCream.DCorp.Infrastructure.Models;

public class Building
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsUnlocked { get; set; }
    public string PreciseEffect { get; set; }
    public string GlobalEffect { get; set; }
    public int RequiredXp {  get; set; }

    public ICollection<PlayerBuildingContribution> PlayerContributions { get; set; } = [];
}

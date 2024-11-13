namespace DiceCream.DCorp.Infrastructure.Models;
public class Rule
{
    public int Id { get; set; }
    public string? Content { get; set; }
    public DateTime LastModification { get; set; } = DateTime.Now;
    public int DungeonMasterProfileId { get; set; }
    public DungeonMasterProfile Author { get; set; } = new();
}

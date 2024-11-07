namespace DiceCream.DCorp.Application.DTO;

public class SessionDTO
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string Feedback { get; set; }
    public string DungeonMasterName { get; set; }
    public List<string> ParticipantNames { get; set; } = new();
}

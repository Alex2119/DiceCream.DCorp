
namespace DiceCream.DCorp.Domain.Entities
{
    public class Session
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int DungeonMasterProfileId { get; set; }
        public DungeonMasterProfile DungeonMaster { get; set; }
        public ICollection<PlayerProfile> Participants { get; set; } = [];
        public string? Feedback { get; set; }
    }
}

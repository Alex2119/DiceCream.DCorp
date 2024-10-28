
namespace DiceCream.DCorp.Domain.Entities
{
    public class Session
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Player Players { get; set; }
        public DungeonMaster DungeonMaster { get; set; }
        public string Feedback { get; set; }
    }
}

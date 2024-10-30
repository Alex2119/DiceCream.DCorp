
namespace DiceCream.DCorp.Domain.Entities
{
    public class DungeonMasterProfile
    {
        public int Id { get; set; }
        public string? RealName { get; set; }
        public string? Nickname { get; set; }
        public List<Session> SessionDirected { get; set; } = [];

        public int UserId { get; set; }
        public User User { get; set; }
    }
}


namespace DiceCream.DCorp.Domain.Entities
{
    public class PlayerProfile
    {
        public int Id { get; set; }
        public string RealName { get; set; }
        public string Nickname { get; set; }
        public int Level { get; set; }
        public DateTime LastSession { get; set; }
        public int Xp { get; set; }
        public int Sp { get; set; }
        public List<Session> SessionHistory { get; set; }
        public List<Skill> AcquiredSkills { get; set; }
        public int Hp { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public List<PlayerSkill> PlayerSkills { get; set; }
        public ICollection<Statistic> Stats { get; set; }
    }
}

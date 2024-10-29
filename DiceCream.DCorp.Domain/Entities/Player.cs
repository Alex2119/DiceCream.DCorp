
namespace DiceCream.DCorp.Domain.Entities
{
    public class Player
    {
        private int Id { get; set; }
        private string RealName { get; set; }
        private string Nickname { get; set; }
        private int Level { get; set; }
        private DateTime LastSession { get; set; }
        private int Xp { get; set; }
        private int Sp { get; set; }
        public List<Session> SessionHistory { get; set; } = [];
        public List<Skill> AcquiredSkills { get; set; } = [];
        public Statistic Stats { get; set; }
        private int PointsDeVie { get; set; }

        public ICollection<PlayerBuildingContribution> BuildingContributions { get; set; } = [];
    }
}

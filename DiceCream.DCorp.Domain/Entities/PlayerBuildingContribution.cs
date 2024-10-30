
namespace DiceCream.DCorp.Domain.Entities
{
    public class PlayerBuildingContribution
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int BuildingId { get; set; }
        public Building Building { get; set; }
        public int XpContribution { get; set; }
    }
}

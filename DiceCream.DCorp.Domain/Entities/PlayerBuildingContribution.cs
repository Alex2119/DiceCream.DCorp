
namespace DiceCream.DCorp.Domain.Entities
{
    public class PlayerBuildingContribution
    {
        public int PlayerId { get; set; }
        public Player? Player { get; set; }
        public int BuildingId { get; set; }
        public Building? Building { get; set; }
        public int XPContribution { get; set; }
    }
}

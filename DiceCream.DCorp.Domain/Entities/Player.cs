namespace DiceCream.DCorp.Domain.Entities;
public class Player
{
   public PlayerProfile PlayerProfile { get; set; }
   public PlayerSkill PlayerSkill { get; set; }
   public PlayerStatistic PlayerStatistic { get; set; }
   public PlayerBuildingContribution PlayerBuildingContribution { get; set; }

}

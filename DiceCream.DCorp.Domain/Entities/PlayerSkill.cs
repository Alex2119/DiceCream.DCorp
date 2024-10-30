using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceCream.DCorp.Domain.Entities
{
    public class PlayerSkill
    {
        public int PlayerProfileId { get; set; }
        public PlayerProfile PlayerProfile { get; set; }
        public int SkillId { get; set; }
        public Skill Skill { get; set; }
        public bool IsPermanent { get; set; }
        public DateTime AquisitionDate { get; set; } = DateTime.Now;
    }
}

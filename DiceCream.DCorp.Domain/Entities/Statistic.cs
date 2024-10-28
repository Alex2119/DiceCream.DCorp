using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace DiceCream.DCorp.Domain.Entities
{
    public class Statistic
    {
        public int Strength { get; set; }
        public int Endurance { get; set; }
        public int Charisma { get; set; }
        public int Stealth { get; set; }
        public int Luck { get; set; }
        public int HitPoints { get; set; }
    }
}

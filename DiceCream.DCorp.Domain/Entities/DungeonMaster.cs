using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceCream.DCorp.Domain.Entities
{
    public class DungeonMaster
    {
        public int Id { get; set; }
        public string RealName { get; set; }
        public string Nickname { get; set; }
        public Role Role {get; set;}
        public List<Session>? SessionDirected {  get; set; }
    }
}

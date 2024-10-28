using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceCream.DCorp.Domain.Entities
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Effect { get; set; }
        public string Universe {  get; set; }
        public bool IsPermanent { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceCream.DCorp.Domain.Entities
{
    public class Rules
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime LastModification { get; set; }
        public DungeonMaster Author { get; set; }
    }
}

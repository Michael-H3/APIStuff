﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIStuff.Models
{
    public class Samurai
    {
        public int samuraiID { get; set; }
        public int battlesFought { get; set; }
        public string name { get; set; }

        //this is a navigation for Entity, framework so it can create a relation to SamuraisInBattle
        public List<SamuraisInBattle> SamuraisInBattle { get; set; }
    }
}

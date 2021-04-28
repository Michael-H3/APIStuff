using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIStuff.Models
{
    public class Battle
    {
        public int battleID { get; set; }
        public string name { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }

        //this is a navigation for Entity, framework so it can create a relation to SamuraisInBattle
        public List<SamuraisInBattle> SamuraisInBattle { get; set; }
    }
}

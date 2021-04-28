using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIStuff.Models
{
    public class SamuraisInBattle
    {
        public int samuraiID { get; set; }
        public Samurai Samurai { get; set; }
        public int battleID { get; set; }
        public Battle Battle { get; set; }
    }
}

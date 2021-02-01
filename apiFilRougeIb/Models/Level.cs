using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiFilRougeIb.Models
{
    public class Level
    {

        public long? IdLevel { get; set; }
        public string Title{ get; set; }


        public Level() { }
        public Level(string title, long? idLevel = null)
        {
            this.Title = title;
            this.IdLevel = idLevel;
        }


    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiFilRougeIB.Models
{
    public class Theme
    {

        public long? IdTheme { get; set; }
        public string Category { get; set; }


        public Theme() { }
        public Theme(string category, long? idWorld = null)
        {
            this.Category = category;
            this.IdTheme = idWorld;
        }


    }
}
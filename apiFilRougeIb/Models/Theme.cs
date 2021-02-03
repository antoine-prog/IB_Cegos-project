using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiFilRougeIb.Models
{
    public class Theme
    {

        public long? IdTheme { get; set; }
        public string theme { get; set; }


        public Theme() { }
        public Theme(string category, long? idTheme = null)
        {
            this.theme = category;
            this.IdTheme = idTheme;
        }


    }
}
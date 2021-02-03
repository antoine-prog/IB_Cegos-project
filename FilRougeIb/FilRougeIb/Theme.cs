using System;
using System.Collections.Generic;
using System.Text;

namespace FilRougeIb
{
    class Theme
    {
        public long? IdTheme { get; set; }
        public string Category { get; set; }


        public Theme() { }
        public Theme(string category, long? idTheme = null)
        {
            this.Category = category;
            this.IdTheme = idTheme;
        }

    }
}

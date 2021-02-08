using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiFilRougeIb.Dto.FindAll
{
    public class FindAllThemesDto
    {
        public long? IdTheme { get; set; }
        public string Theme{ get; set; }
        public FindAllThemesDto(string theme, long? idTheme = null)
        {
            this.IdTheme = idTheme;
            this.Theme = theme;
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiFilRougeIb.Dto.FindAll
{
    public class FindAllThemesDto
    {
        public long? IdTheme { get; set; }
        public string Category { get; set; }
        public FindAllThemesDto(string category, long? idTheme = null)
        {
            this.IdTheme = idTheme;
            this.Category = category;
        }


    }
}

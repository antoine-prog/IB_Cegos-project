using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiFilRougeIb.Dto.AfterCreate
{
    public class AfterCreateThemeDto
    {

        public long? IdTheme { get; set; }
        public string Category { get; set; }
        public bool IsCreated { get; set; }
        public AfterCreateThemeDto(string category, bool isCreated, long? idTheme = null)
        {
            this.IdTheme = idTheme;
            this.Category = category;
            this.IsCreated = isCreated;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiFilRougeIb.Dto.Create
{
    public class CreateThemeDto
    {
        public string Theme { get; set; }
        public CreateThemeDto(string theme)
        {
            this.Theme = theme;
        }


    }
}

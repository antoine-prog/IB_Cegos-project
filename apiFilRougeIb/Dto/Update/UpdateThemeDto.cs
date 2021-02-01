using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiFilRougeIb.Dto.Update
{
    public class UpdateThemeDto
    {
        public string Category { get; set; }
        public UpdateThemeDto(string category)
        {
            this.Category = category;
        }


    }
}

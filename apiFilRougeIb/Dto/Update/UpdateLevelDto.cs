using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiFilRougeIb.Dto.Update
{
    public class UpdateLevelDto
    {
        public string Title { get; set; }
        public UpdateLevelDto(string title)
        {
            this.Title = title;
        }


    }
}

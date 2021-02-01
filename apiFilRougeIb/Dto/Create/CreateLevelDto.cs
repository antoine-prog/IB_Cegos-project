using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiFilRougeIb.Dto.Create
{
    public class CreateLevelDto
    {
        public string Title{ get; set; }
        public CreateLevelDto(string title)
        {
            this.Title = title;
        }


    }
}

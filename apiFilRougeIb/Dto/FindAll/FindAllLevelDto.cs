using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiFilRougeIb.Dto.FindAll
{
    public class FindAllLevelDto
    {
        public long? IdLevel { get; set; }
        public string Title { get; set; }
        public FindAllLevelDto(string title, long? idLevel = null)
        {
            this.IdLevel = idLevel;
            this.Title = title;
        }


    }
}

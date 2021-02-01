using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiFilRougeIb.Dto.AfterCreate
{
    public class AfterCreateLevelDto
    {

        public long? IdLevel { get; set; }
        public string Title { get; set; }
        public bool IsCreated { get; set; }
        public AfterCreateLevelDto(string title, bool isCreated, long? idLevel = null)
        {
            this.IdLevel = idLevel;
            this.Title = title;
            this.IsCreated = isCreated;
        }




    }
}

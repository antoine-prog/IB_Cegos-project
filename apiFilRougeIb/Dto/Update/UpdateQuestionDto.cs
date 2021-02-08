using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiFilRougeIb.Dto.Update
{
    public class UpdateQuestionDto
    {
        public string Title { get; set; }
        public long Level_idLevel { get; set; }
        public UpdateQuestionDto(string title,  long level_idLevel)
        {
            this.Title = title;
            this.Level_idLevel = level_idLevel;
        }
    }

    
}

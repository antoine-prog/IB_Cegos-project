using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiFilRougeIb.Dto.Create
{
    public class CreateQuestionDto
    {
        public string Title { get; set; }
        public long Level_idLevel { get; set; }
        public string? Comment { get; set; }

        public CreateQuestionDto( string title, long level_idLevel,string? comment)
        {
            this.Title = title;
            this.Level_idLevel = level_idLevel;
            this.Comment = comment;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiFilRougeIb.Dto.Create
{
    public class CreateQuestionDto
    {
        public string Title { get; set; }
        public long Theme_idTheme { get; set; }
        public long Level_idLevel { get; set; }

      
        public CreateQuestionDto( string title, long theme_idTheme, long level_idLevel)
        {
            this.Title = title;
            this.Theme_idTheme = theme_idTheme;
            this.Level_idLevel = level_idLevel;
        }
    }
}

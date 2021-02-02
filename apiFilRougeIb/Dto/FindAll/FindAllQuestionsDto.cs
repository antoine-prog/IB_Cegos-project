using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiFilRougeIb.Dto.FindAll
{
    public class FindAllQuestionsDto
    {
        public long? IdQuestion { get; set; }
        public string Title { get; set; }
        public long Theme_idTheme { get; set; }
        public long Level_idLevel { get; set; }

        public FindAllQuestionsDto(string title, long theme_idTheme, long level_idLevel, long? idQuestion = null)
        {
            Title = title;
            Theme_idTheme = theme_idTheme;
            Level_idLevel = level_idLevel;
            IdQuestion = idQuestion;
        }

    }
}

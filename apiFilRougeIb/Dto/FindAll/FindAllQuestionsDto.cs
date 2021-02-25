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
        public long Level_idLevel { get; set; }
        public string? Comment { get; set; }

        public FindAllQuestionsDto(string title, long level_idLevel, string? comment,long? idQuestion = null)
        {
            Title = title;
            Level_idLevel = level_idLevel;
            Comment = comment;
            IdQuestion = idQuestion;
        }

    }
}

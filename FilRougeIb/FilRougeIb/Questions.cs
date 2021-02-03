using System;
using System.Collections.Generic;
using System.Text;

namespace FilRougeIb
{
    class Questions
    {
        List<Solutions> solutions = new List<Solutions>();
        public long? IdQuestions { get; set; }
        public string Title { get; set; }
        public long Theme_idTheme { get; set; }
        public long Level_idLevel { get; set; }

        public Questions() { }

        public Questions(List<Solutions> solutions, long? idQuestions, string title, long theme_idTheme, long level_idLevel)
        {
            this.solutions = solutions;
            IdQuestions = idQuestions;
            Title = title;
            Theme_idTheme = theme_idTheme;
            Level_idLevel = level_idLevel;
        }
    }
}

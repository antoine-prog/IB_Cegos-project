using System;
using System.Collections.Generic;
using System.Text;

namespace FilRougeIb
{
    class Question
    {
        
        public long? IdQuestions { get; set; }
        public string Title { get; set; }
        public long Theme_idTheme { get; set; }
        public long Level_idLevel { get; set; }
        public Quiz Quiz { get; set; }
        public List<Solution> Solutions { get; set; } = new List<Solution>();
        public Answer Answer { get; set; }


        public Question() { }

        public Question(string title, long theme_idTheme, long level_idLevel, Quiz quiz, List<Solution> solutions, Answer answer, long? idQuestions)
        {
           
            this.IdQuestions = idQuestions;
            this.Title = title;
            this.Theme_idTheme = theme_idTheme;
            this.Level_idLevel = level_idLevel;
            this.Quiz = quiz;
            this.Solutions = solutions;
            this.Answer = answer;
        }
    }
}

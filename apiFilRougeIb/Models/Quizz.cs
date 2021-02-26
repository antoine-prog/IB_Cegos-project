using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiFilRougeIb.Models
{
    public class Quizz
    {

        public long? IdQuizz { get; set; }
        public string Name { get; set; }
        public long User_idUser { get; set; }
        public long Theme_idTheme { get; set; }
        public string Code { get; set; }
        public DateTime? DateClosed { get; set; }
        public int? Timer { get; set; }
        public int Level_idLevel { get; set; }

        public Quizz() { }
        public Quizz(string name, long user_idUser, long Theme_idTheme,string code,
            DateTime? dateClosed, int level_idlevel,  int? timer, 
            long? idQuizz = null)
        {
            this.Name = name;
            this.User_idUser = user_idUser;
            this.IdQuizz = idQuizz;
            this.Theme_idTheme = Theme_idTheme;
            this.Code =code;
            this.DateClosed =dateClosed;
            this.Timer =timer;
            this.Level_idLevel = level_idlevel;

        }
    }
}
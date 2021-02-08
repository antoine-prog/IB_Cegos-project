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

        public Quizz() { }
        public Quizz(string name, long user_idUser, long Theme_idTheme,long? idQuizz = null)
        {
            this.Name = name;
            this.User_idUser = user_idUser;
            this.IdQuizz = idQuizz;
            this.Theme_idTheme = Theme_idTheme;
        }
    }
}
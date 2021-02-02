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

        public Quizz() { }
        public Quizz(string name, long user_idUser, long? idQuizz = null)
        {
            Name = name;
            User_idUser = user_idUser;
            IdQuizz = idQuizz;
        }
    }
}
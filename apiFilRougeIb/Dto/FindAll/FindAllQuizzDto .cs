using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiFilRougeIb.Dto.FindAll
{
    public class FindAllQuizzDto
    {
        public long? IdQuizz { get; set; }
        public string Name { get; set; }
        public long User_idUser { get; set; }

        public FindAllQuizzDto( string name, long user_idUser, long? idQuizz = null)
        {
            IdQuizz = idQuizz;
            Name = name;
            User_idUser = user_idUser;
        }


    }
}

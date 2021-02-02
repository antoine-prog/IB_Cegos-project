using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiFilRougeIb.Dto.AfterCreate
{
    public class AfterCreateQuizzDto
    {

        public long? IdQuizz { get; set; }
        public string Name { get; set; }
        public long User_idUser { get; set; }
        public bool IsCreated { get; set; }

        public AfterCreateQuizzDto( string name, long user_idUser, bool isCreated, long? idQuizz= null)
        {
            IdQuizz = idQuizz;
            Name = name;
            User_idUser = user_idUser;
            IsCreated = isCreated;
        }
    }
}

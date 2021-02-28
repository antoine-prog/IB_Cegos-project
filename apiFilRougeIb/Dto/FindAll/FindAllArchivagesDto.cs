using apiFilRougeIb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiFilRougeIb.Dto.FindAll
{
    public class FindAllArchivagesDto 
    {    
            //public FindAllArchivagesDto() { }
            public FindAllArchivagesDto(DateTime dateCompleted, bool isValidated, long quizz_idQuizz, long user_idUser, long? idArchivage)
            {
                IdArchivage = idArchivage;
                DateCompleted = dateCompleted;
                IsValidated = isValidated;
                Quizz_idQuizz = quizz_idQuizz;
                User_idUser = user_idUser;
            }

        public long? IdArchivage { get; set; }
        public DateTime DateCompleted { get; set; }
        public bool IsValidated { get; set; }
        public long Quizz_idQuizz { get; set; }
        public long User_idUser { get; set; }

    }
}

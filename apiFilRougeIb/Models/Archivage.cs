using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiFilRougeIb.Models
{
    public class Archivage
    {
        public Archivage() { }
        public Archivage(DateTime? dateCompleted, bool isValidated, long quizz_idQuizz, long user_idUser,long? idArchivage =null)
        {
            this.IdArchivage = idArchivage;
            DateCompleted = dateCompleted;
            IsValidated = isValidated;
            Quizz_idQuizz = quizz_idQuizz;
            User_idUser = user_idUser;
        }

        public long? IdArchivage { get; set; }
        public DateTime? DateCompleted { get; set; }
        public bool IsValidated { get; set; }
        public long Quizz_idQuizz { get; set; }
        public long User_idUser { get; set; }

    }
}

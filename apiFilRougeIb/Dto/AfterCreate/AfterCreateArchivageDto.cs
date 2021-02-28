using System;

namespace apiFilRougeIb.Dto.AfterCreate
{
    public class AfterCreateArchivageDto
    {
        public AfterCreateArchivageDto() { }
        public AfterCreateArchivageDto(DateTime dateCompleted, bool isValidated, long quizz_idQuizz, long user_idUser, long? idArchivage)
        {
            this.IdArchivage = idArchivage;
            DateCompleted = dateCompleted;
            IsValidated = isValidated;
            Quizz_idQuizz = quizz_idQuizz;
            User_idUser = user_idUser;
            IsCreated = true;
        }

        public long? IdArchivage { get; set; }
        public DateTime DateCompleted { get; set; }
        public bool IsValidated { get; set; }
        public long Quizz_idQuizz { get; set; }
        public long User_idUser { get; set; }
        public bool IsCreated { get; set; }
    }
}
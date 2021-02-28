using System;
namespace apiFilRougeIb.Dto.Create
{
    public class CreateArchivageDto
    {
        public CreateArchivageDto() { }
        public CreateArchivageDto(DateTime dateCompleted, bool isValidated, long quizz_idQuizz, long user_idUser)
        {
            DateCompleted = dateCompleted;
            IsValidated = isValidated;
            Quizz_idQuizz = quizz_idQuizz;
            User_idUser = user_idUser;
        }

        
        public DateTime DateCompleted { get; set; }
        public bool IsValidated { get; set; }
        public long Quizz_idQuizz { get; set; }
        public long User_idUser { get; set; }

    }
}
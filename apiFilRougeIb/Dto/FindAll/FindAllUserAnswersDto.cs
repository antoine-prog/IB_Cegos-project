namespace apiFilRougeIb.Dto.FindAll
{
    public class FindAllUserAnswersDto 
    {
        public long User_IdUser { get; set; }
        public long Answer_IdAnswer { get; set; }
        public long Question_IdQuestion { get; set; }


        public FindAllUserAnswersDto(long idUser, long answer_IdAnswer, long question_IdQuestion)
        {
            User_IdUser = idUser;
            Answer_IdAnswer = answer_IdAnswer;
            Question_IdQuestion = question_IdQuestion;
        }
    }
}
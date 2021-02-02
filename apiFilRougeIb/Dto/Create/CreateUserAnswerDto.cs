namespace apiFilRougeIb.Dto.Create
{
    internal class CreateUserAnswerDto
    {
        public CreateUserAnswerDto(long idUser, long answer_IdAnswer, long question_IdQuestion)
        {
            IdUser = idUser;
            Answer_IdAnswer = answer_IdAnswer;
            Question_IdQuestion = question_IdQuestion;
        }

        public long IdUser { get; set; }
        public long Answer_IdAnswer { get; set; }
        public long Question_IdQuestion { get; set; }
    }
}
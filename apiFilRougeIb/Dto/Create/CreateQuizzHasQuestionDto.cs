namespace apiFilRougeIb.Dto.Create
{
    public class CreateQuizzHasQuestionDto
    {
        public long quizz_idQuizz { get; set; }
        public long question_idQuestion { get; set; }
        public CreateQuizzHasQuestionDto() { }

        public CreateQuizzHasQuestionDto(long quizz_idQuizz, long question_idQuestion)
        {
            this.quizz_idQuizz = quizz_idQuizz;
            this.question_idQuestion = question_idQuestion;
        }
    }
}
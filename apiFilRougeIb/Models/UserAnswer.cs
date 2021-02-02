namespace apiFilRougeIb.Models
{
    public class UserAnswer
    {
        public long User_IdUser { get; set; }
        public long Answer_IdAnswer { get; set; }
        public long Question_IdQuestion { get; set; }

        public UserAnswer() { }

        public UserAnswer(long idUser, long answer_IdAnswer, long question_IdQuestion)
        {
            User_IdUser = idUser;
            Answer_IdAnswer = answer_IdAnswer;
            Question_IdQuestion = question_IdQuestion;
        }
        public override string ToString()
        {
            return $"{this.User_IdUser} {this.Answer_IdAnswer} {this.Question_IdQuestion}";
        }
    }
}
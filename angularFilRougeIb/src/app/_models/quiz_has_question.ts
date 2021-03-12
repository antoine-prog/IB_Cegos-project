export class Quiz_has_Question{

  private _quizz_idQuizz : number;
  private _question_idQuestion : number;

  constructor(question_idQuestion : number, quizz_idQuizz? : number){
    this._quizz_idQuizz = quizz_idQuizz;
    this._question_idQuestion = question_idQuestion;
  }

  get quizz_idQuizz() : number {
    return this._quizz_idQuizz;
  }

  get question_idQuestion() : number {
    return this._question_idQuestion;
  }

  set question_idQuestion(question_idQuestion : number){
    this._question_idQuestion = question_idQuestion;
  }
}

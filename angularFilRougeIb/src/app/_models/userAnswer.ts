import { time } from "console";
import { tmpdir } from "os";

export class UserAnswer{

  private _user_IdUser : number;
  private _answer_IdAnswer : number;
  private _question_IdQuestion : number;

  constructor(user_IdUser : number, answer_IdAnswer : number, question_IdQuestion : number){
    this._user_IdUser = user_IdUser;
    this._answer_IdAnswer = answer_IdAnswer;
    this._question_IdQuestion = question_IdQuestion;
  }

  get user_IdUser() : number {
    return this._user_IdUser;
  }

  get answer_IdAnswer() : number {
    return this._answer_IdAnswer;
  }

  get question_IdQuestion() : number {
    return this._question_IdQuestion;
  }

}

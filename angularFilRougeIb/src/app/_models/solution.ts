import { time } from "console";
import { tmpdir } from "os";

export class Solution{

  private _idSolution : number;
  private _solution : string;
  private _question_idQuestion: number;
  private _isTrue : boolean;

  constructor(solution : string, question_idQuestion : number, isTrue : boolean, idSolution? : number){
    this._idSolution = idSolution;
    this._solution = solution;
    this._question_idQuestion = question_idQuestion;
    this._isTrue = isTrue;
  }

  get idSolution() : number {
    return this._idSolution;
  }

  get solution() : string {
    return this._solution;
  }

  set solution(solution : string){
    this._solution = solution;
  }

  get question_idQuestion() : number {
    return this._question_idQuestion;
  }

  set question_idQuestion(question_idQuestion : number){
    this._question_idQuestion = question_idQuestion;
  }

  get isTrue() : boolean {
    return this._isTrue;
  }

  set isTrue(isTrue : boolean){
    this._isTrue = isTrue;
  }
}

import { time } from "console";
import { tmpdir } from "os";

export class Answer{

  private _idAnswer : number;
  private _answer : string;
  private _result : boolean;

  constructor(answer : string, result? : boolean, idAnswer? : number){
    this._idAnswer = idAnswer;
    this._answer = answer;
    this._result = result;
  }

  get idAnswer() : number {
    return this._idAnswer;
  }

  get answer() : string {
    return this._answer;
  }

  set answer(answer : string){
    this._answer = answer;
  }

  get result() : boolean {
    return this._result;
  }

  set result(result : boolean){
    this._result = result;
  }
}

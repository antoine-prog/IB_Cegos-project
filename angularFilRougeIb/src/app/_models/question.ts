import { time } from "console";
import { tmpdir } from "os";

export class Question{

  private _idQuestion : number;
  private _title : string;
  private _level_idLevel : number;
  private _comment : string;


  constructor(title : string, level_idLevel : number, comment : string, idQuestion? : number){
    this._idQuestion = idQuestion;
    this._title = title;
    this._level_idLevel = level_idLevel;
    this._comment = comment;
  }

  get idQuestion() : number {
    return this._idQuestion;
  }

  get title() : string {
    return this._title;
  }

  set title(title : string){
    this._title = title;
  }

  get level_idLevel() : number {
    return this._level_idLevel;
  }

  set level_idLevel(level_idLevel : number){
    this._level_idLevel = level_idLevel;
  }

  get comment() : string {
    return this._comment;
  }

  set comment(comment : string){
    this._comment = comment;
  }
}

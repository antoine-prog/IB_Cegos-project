import { time } from "console";
import { tmpdir } from "os";

export class Answer{

  private _idLevel : number;
  private _title: string;

  constructor(title : string, idLevel? : number){
    this._idLevel = idLevel;
    this._title = title;

  }

  get idLevel() : number {
    return this._idLevel;
  }

  get title() : string {
    return this._title;
  }

  set title(title : string){
    this._title = title;
  }
}

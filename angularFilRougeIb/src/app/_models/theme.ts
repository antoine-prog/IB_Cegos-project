import { time } from "console";
import { tmpdir } from "os";

export class Theme{

  private _idTheme : number;
  private _theme : string;

  constructor(theme : string, idTheme ? : number){
    this._idTheme  = idTheme ;
    this._theme = theme;
  }

  get idTheme () : number {
    return this._idTheme ;
  }

  get theme() : string {
    return this._theme;
  }

  set theme(theme : string){
    this._theme = theme;
  }
}

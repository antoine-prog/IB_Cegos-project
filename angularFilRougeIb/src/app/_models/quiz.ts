import { time } from "console";
import { tmpdir } from "os";

export class Quiz{

  private _idQuiz : number;
  private _name : string;
  private _user_idUser : number;
  private _theme_idTheme: string;
  private _code : string;
  private _dateClosed : Date;
  private _timer : number;
  private _level_idLevel : number;

  constructor(name : string, user_idUser : number, theme_idTheme : string, code : string, level_idLevel : number, dateClosed? : Date, timer? : number, idQuiz? : number){
    this._idQuiz = idQuiz;
    this._name = name;
    this._user_idUser = user_idUser;
    this._theme_idTheme = theme_idTheme;
    this._code = code;
    this._dateClosed = dateClosed;
    this._timer = timer;
    this._level_idLevel = level_idLevel;
  }

  get idQuiz() : number {
    return this._idQuiz;
  }

  get name() : string {
    return this._name;
  }

  set name(name : string){
    this._name = name;
  }

  get user_idUser() : number {
    return this._user_idUser;
  }

  set user_idUser(user_idUser : number){
    this._user_idUser = user_idUser;
  }

  get theme_idTheme() : string {
    return this._theme_idTheme;
  }

  set theme_idTheme(theme_idTheme : string){
    this._theme_idTheme = theme_idTheme;
  }

  get code() : string {
    return this._code;
  }

  set code(code : string){
    this._code = code;
  }

  get dateClosed() : Date {
    return this._dateClosed;
  }

  set dateClosed(dateClosed : Date){
    this._dateClosed = dateClosed;
  }

  get timer() : number {
    return this._timer;
  }

  set timer(timer : number){
    this._timer = timer;
  }

  get level_idLevel() : number {
    return this._level_idLevel;
  }

  set level_idLevel(level_idLevel : number){
    this._level_idLevel = level_idLevel;
  }
}

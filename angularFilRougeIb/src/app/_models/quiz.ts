import { Question } from "./question";

export class Quiz{

  private _idQuizz : number;
  private _name : string;
  private _user_idUser : number;
  private _theme_idTheme: number;
  private _code : string;
  private _dateClosed : Date;
  private _timer : number;
  private _level_idLevel : number;
  private _listquestionsolution : Quiz[] = [];

  constructor(name : string, user_idUser : number, theme_idTheme : number, code : string, level_idLevel : number, listquestions? : Quiz[], dateClosed? : Date, timer? : number, idQuiz? : number){
    this._idQuizz = idQuiz;
    this._listquestionsolution = listquestions;
    this._name = name;
    this._user_idUser = user_idUser;
    this._theme_idTheme = theme_idTheme;
    this._code = code;
    this._dateClosed = dateClosed;
    this._timer = timer;
    this._level_idLevel = level_idLevel;
  }

  get idQuizz() : number {
    return this._idQuizz;
  }

  get listquestionsolution() : Quiz[] {
    return this._listquestionsolution;
  }

  set listquestionsolution(listquestions : Quiz[]){
    this._listquestionsolution = listquestions;
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

  get theme_idTheme() : number {
    return this._theme_idTheme;
  }

  set theme_idTheme(theme_idTheme : number){
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

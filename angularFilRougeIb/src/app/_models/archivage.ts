export class Archivage{

  private _idArchivage : number;
  private _dateCompleted : Date;
  private _isValidated : boolean;
  private _quizz_idQuizz : number;
  private _user_idUser : number;


  constructor(dateCompleted : Date, isValidated : boolean, quizz_idQuizz : number, user_idUser : number, idArchivage? : number){
    this._idArchivage = idArchivage;
    this._dateCompleted = dateCompleted;
    this._isValidated = isValidated;
    this._quizz_idQuizz = quizz_idQuizz;
    this._user_idUser = user_idUser;
  }

  get idArchivage() : number {
    return this._idArchivage;
  }

  get dateCompleted() : Date {
    return this._dateCompleted;
  }

  set dateCompleted(dateCompleted : Date){
    this._dateCompleted = dateCompleted;
  }

  get isValidated() : boolean {
    return this._isValidated;
  }

  set isValidated(isValidated : boolean){
    this._isValidated = isValidated;
  }

  get quizz_idQuizz() : number {
    return this._quizz_idQuizz;
  }

  set quizz_idQuizz(quizz_idQuizz : number){
    this._quizz_idQuizz = quizz_idQuizz;
  }

  get user_idUser() : number {
    return this._user_idUser;
  }

  set user_idUser(user_idUser : number){
    this._user_idUser = user_idUser;
  }
}

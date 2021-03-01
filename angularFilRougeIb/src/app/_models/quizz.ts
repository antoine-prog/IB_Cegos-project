export class Quizz{

    private  _idQuizz :number;  
    private  _name :string; 
    private _user_idUser  :number;
    private  _theme_idTheme  :number;
    private  _code  :string;
    private  _dateClosed :Date;
    private  _timer  :number;
    private _level_idLevel  :number;

    get idQuizz() : number {
        return this._idQuizz;
      }
    
    get name() : string {
    return this._name;
    }

    set name(Name : string){
        this._name = Name;
    }

    get  user_idUser() : number {
        return this._user_idUser;
        }

    set  user_idUser( User_idUser : number){
        this._user_idUser =  User_idUser;
    }
    get  theme_idTheme() : number {
        return this._theme_idTheme;
        }

    set  theme_idTheme( Theme_idTheme : number){
        this._theme_idTheme =  Theme_idTheme;
    }

    get code() : string {
        return this._code;
        }
    
    set code(Code : string){
        this._code = Code;
    }

    get dateClosed() : Date {
        return this._dateClosed;
        }
    
    set dateClosed(DateClosed : Date){
        this._dateClosed = DateClosed;
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
    
    set level_idLevel(Level_idLevel : number){
        this._level_idLevel = Level_idLevel;
    }
}
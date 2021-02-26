export class User{

  private _idUser : number;
  private _firstName : string;
  private _lastName : string;
  private _username: string;
  private _adress : string;
  private _mail : string;
  private _password : string;
  private _isAdmin : boolean;
  private _isCreator : boolean;


  constructor(firstName : string, lastName : string, username : string, adress : string, mail : string, password : string, isAdmin : boolean, isCreator : boolean, idUser? : number){
    this._idUser = idUser;
    this._firstName = firstName;
    this._lastName = lastName;
    this._username = username;
    this._adress = adress;
    this._password = password;
    this._isAdmin = isAdmin;
    this._isCreator = isCreator;
  }

  get idUser() : number {
    return this._idUser;
  }

  get firstName() : string {
    return this._firstName;
  }

  set firstName(firstName : string){
    this._firstName = firstName;
  }

  get lastName() : string {
    return this._lastName;
  }

  set lastName(lastName : string){
    this._lastName = lastName;
  }

  get username() : string {
    return this._username;
  }

  set username(username : string){
    this._username = username;
  }

  get adress() : string {
    return this._adress;
  }

  set adress(adress : string){
    this._adress = adress;
  }

  get password() : string {
    return this._password;
  }

  set password(password : string){
    this._password = password;
  }

  get isAdmin() : boolean {
    return this._isAdmin;
  }

  set isAdmin(isAdmin : boolean){
    this._isAdmin = isAdmin;
  }

  get isCreator() : boolean {
    return this._isCreator;
  }

  set isCreator(isCreator : boolean){
    this._isCreator = isCreator;
  }

}

import { Injectable } from '@angular/core';
import { UserInterface } from '../_interfaces/user-interface';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor() { }

  public connect(userInfo: UserInterface){
    localStorage.setItem('ACCESS_TOKEN',"access_token");
  }

  public isConnect() : boolean{
    return localStorage.getItem('ACCES_TOKEN') !== null;
  }

  public disconnect(){
    localStorage.removeItem('ACCES_TOKEN');
  }

}

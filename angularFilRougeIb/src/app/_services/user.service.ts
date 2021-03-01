import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { User } from '../_models/user';


@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http : HttpClient) { }

  getAll() : Observable<User[]>{
    return this.http.get<User[]>(`${environment.apiUrl}/api/users`)
  }

  getById(idUser : number) : Observable<User[]>{
    return this.http.get<User[]>(`${environment.apiUrl}/api/users/${idUser}`)
  }

  getUserQuizbtId( idUser :number) : Observable<User[]>{
    return this.http.get<User[]>(`${environment.apiUrl}/api/users/${idUser}/quizz`)

  }

  create(user: User) : Observable<User>{
    return this.http.post<User>(`${environment.apiUrl}/api/users`, user)
  }

  update(user: User): Observable<User> {
        return this.http.put<User>(`${environment.apiUrl}/api/users`, user);
      }

  delete(idUser : number) : Observable<User[]>{
    console.log("toto");
    return this.http.delete<User[]>(`${environment.apiUrl}/api/users/${idUser}`)
  }
}

import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import * as EventEmitter from 'events';
import { BehaviorSubject, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Quiz } from '../_models/quiz';

@Injectable({
  providedIn: 'root'
})
export class HomeService {

  constructor(private http : HttpClient) { }


  getByCode(code : string) : Observable<Quiz>{
    return this.http.get<Quiz>(`${environment.apiUrl}/api/Quiz/code/${code}`)
  }
}

import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Quizz } from '../_models/quizz';

@Injectable({
  providedIn: 'root'
})
export class HomeService {

  constructor(private http : HttpClient) { }

  getByCode(code : string) : Observable<Quizz>{
    return this.http.get<Quizz>(`${environment.apiUrl}/api/Quiz/code/${code}`)
  }
}

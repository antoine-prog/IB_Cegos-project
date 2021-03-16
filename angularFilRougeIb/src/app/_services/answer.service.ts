import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Answer } from '../_models/answer';
import { Quiz } from '../_models/quiz';
import { User } from '../_models/user';

@Injectable({
  providedIn: 'root'
})
export class AnswerService {

  constructor(private http : HttpClient) { }

  //Il nous faut : post dans answer et useranswer
  postAnswer(body:Answer) /*: Observable<any>*/{
    return this.http.post<Answer>(`${environment.apiUrl}/api/answers/`,body)
  }
  postUserAnswer(body) : Observable<any>{
    return this.http.post<Answer>(`${environment.apiUrl}/api/useranswers`,body)
  }

  //Récupération des réponses par utilisateur par quiz
  get(idCandidat,idQuiz): Observable<any>{
    return this.http.get<Answer[]>(`${environment.apiUrl}/api/answers/${idCandidat},${idQuiz}`)
  }
  resultat(idArchivage,idUser,idQuiz) : Observable<any>{
    return this.http.get<Answer[]>(`${environment.apiUrl}/results/${idArchivage}/${idUser}/${idQuiz}`)
  }

}

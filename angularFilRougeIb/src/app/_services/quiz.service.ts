import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Quiz } from '../_models/quiz';

@Injectable({
  providedIn: 'root'
})
export class QuizService {

  constructor(private http : HttpClient) { }

  getAll() : Observable<Quiz[]>{
    return this.http.get<Quiz[]>(`${environment.apiUrl}/api/quiz`)
  }
  getById(idQuiz : number) : Observable<Quiz>{
    return this.http.get<Quiz>(`${environment.apiUrl}/api/quiz/${idQuiz}`)
  }

  getQuestionsQuizbtId(idQuiz :number) : Observable<Quiz>{
    return this.http.get<Quiz>(`${environment.apiUrl}/api/quiz/${idQuiz}/questions`)
  }

  getQuestionsSolutionsQuizbtId(idQuiz :number) : Observable<Quiz>{
    return this.http.get<Quiz>(`${environment.apiUrl}/api/quiz/${idQuiz}/questions&solution`)
  }

  create(quiz: Quiz) : Observable<Quiz>{
    return this.http.post<Quiz>(`${environment.apiUrl}/api/quiz`, quiz)
  }

  update(quiz: Quiz): Observable<Quiz> {
        return this.http.put<Quiz>(`${environment.apiUrl}/api/quiz`,quiz);
      }

  delete(idQuiz : number){
    return this.http.delete(`${environment.apiUrl}/api/quiz/${idQuiz}`)
  }
}

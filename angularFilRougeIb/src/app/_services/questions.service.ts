import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Question } from '../_models/question';
import { Quiz_has_Question } from '../_models/quiz_has_question';

@Injectable({
  providedIn: 'root'
})
export class QuestionsService {

  constructor(private http : HttpClient) { }

  getAll() : Observable<Question[]>{
    return this.http.get<Question[]>(`${environment.apiUrl}/api/questions`)
  }

  getById(idQuestion : number) : Observable<Question>{
    return this.http.get<Question>(`${environment.apiUrl}/api/questions/${idQuestion}`)
  }

  create(question: Question) : Observable<Question>{
    let testpostquestion ={title:question.title, level_idlevel:question.level_idLevel, comment:question.comment }
    console.log("ICI SERVICE FRONT CREATE QUESITON" , question)
    return this.http.post<Question>(`${environment.apiUrl}/api/questions`, testpostquestion)
  }

  update(question: Question): Observable<Question> {
        return this.http.put<Question>(`${environment.apiUrl}/api/questions`,question);
      }

  delete(idQuestion : number){
    return this.http.delete(`${environment.apiUrl}/api/Questions/${idQuestion}`)
  }

  createQuizHasQuestions(quizHaSQuestion : Quiz_has_Question) : Observable<Quiz_has_Question>{
    console.log(quizHaSQuestion)
    let testpostQHQ ={quizz_idQuizz:quizHaSQuestion.quizz_idQuizz,question_idQuestion:quizHaSQuestion.question_idQuestion}
    return this.http.post<Quiz_has_Question>(`${environment.apiUrl}/api/quizz_has_Questions`, testpostQHQ)
  }
}

import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Solution } from '../_models/solution';

@Injectable({
  providedIn: 'root'
})
export class SolutionsService {

  constructor(private http : HttpClient) { }

  getAll() : Observable<Solution[]>{
    return this.http.get<Solution[]>(`${environment.apiUrl}/api/solutions`)
  }

  getById(idSolution : number) : Observable<Solution>{
    return this.http.get<Solution>(`${environment.apiUrl}/api/solutions/${idSolution}`)
  }

  create(solution: Solution) : Observable<Solution>{
    console.log(solution)
    let sol ={  solution:solution.solution,
    isTrue: solution.isTrue,
    question_idQuestion: solution.question_idQuestion}

    return this.http.post<Solution>(`${environment.apiUrl}/api/solutions`, sol)
  }

  update(solution: Solution): Observable<Solution> {
        return this.http.put<Solution>(`${environment.apiUrl}/api/solutions`,solution);
      }

  delete(idQuestion : number){
    return this.http.delete(`${environment.apiUrl}/api/Questions/${idQuestion}`)
  }
}

import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Quiz } from '../_models/quiz';

@Injectable({
  providedIn: 'root'
})
export class SharedService {

  private quizSource = new BehaviorSubject<Quiz>(new Quiz('',0,0,'',0,[]))
quiz= this.quizSource.asObservable()

  constructor() { }

  UpdateQuiz =(quiz) => {
    this.quizSource.next(quiz);

  }
}

import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Quiz } from '../_models/quiz';
import { User } from '../_models/user';

@Injectable({
  providedIn: 'root'
})
export class SharedService {

  private quizSource = new BehaviorSubject<Quiz>(new Quiz('',0,0,'',0,[]));
  quiz= this.quizSource.asObservable();

  private currentUserSource = new BehaviorSubject<User>(new User('','','','','','',false,false));
  currentUser = this.currentUserSource.asObservable();


  constructor() { }

  UpdateQuiz =(quiz) => {
    this.quizSource.next(quiz);
  }
  UpdateCurrentUser = (user) => {
    this.currentUserSource.next(user);
  }
}

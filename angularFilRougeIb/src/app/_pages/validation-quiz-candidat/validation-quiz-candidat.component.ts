import { Component, OnInit } from '@angular/core';
import { forkJoin, of } from 'rxjs';
import { Quiz } from 'src/app/_models/quiz';
import { Resultat } from 'src/app/_models/resultat';
import { User } from 'src/app/_models/user';
import { AnswerService } from 'src/app/_services/answer.service';
import { SharedService } from 'src/app/_services/shared.service';

@Component({
  selector: 'app-validation-quiz-candidat',
  templateUrl: './validation-quiz-candidat.component.html',
  styleUrls: ['./validation-quiz-candidat.component.css']
})
export class ValidationQuizCandidatComponent implements OnInit {

  constructor(private shared : SharedService,private answerService : AnswerService) { }

  resultat : Resultat
  user : User
  quiz : Quiz

  ngOnInit(): void {
    console.clear()
    
    this.shared.currentUser
    .subscribe((user)=>{
      this.user=user
      console.log("user",this.user)
    })
    this.shared.quiz.subscribe((quiz)=>{
      this.quiz=quiz
      console.log("quiz",this.quiz)
    }    )
    
    this.answerService.get(this.user.idUser,this.quiz.idQuizz).subscribe(res=>{
      this.resultat=res
      
      console.log("resultat",this.resultat)
    })
  }

}

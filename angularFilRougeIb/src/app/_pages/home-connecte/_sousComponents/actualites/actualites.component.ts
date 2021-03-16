import { Component, Input, OnInit } from '@angular/core';
import { Question } from 'src/app/_models/question';
import { Quiz } from 'src/app/_models/quiz';
import { Resultat } from 'src/app/_models/resultat';
import { User } from 'src/app/_models/user';
import { AnswerService } from 'src/app/_services/answer.service';
import { HomeService } from 'src/app/_services/home.service';
import { QuizService } from 'src/app/_services/quiz.service';
import { UserService } from 'src/app/_services/user.service';

@Component({
  selector: 'app-actualites',
  templateUrl: './actualites.component.html',
  styleUrls: ['./actualites.component.css']
})
export class ActualitesComponent implements OnInit {
  @Input() actualite;
  quiz : Quiz
  candidat:User
  candLoaded :boolean = false
  questions : any[] 
  resultat : Resultat
  constructor(private quizService : QuizService,private userService : UserService,private answerService : AnswerService) {
    
   }

  ngOnInit(): void {
        this.quizService.getById(this.actualite.quizz_idQuizz).subscribe(q=>{
      this.quiz=q;
    })
    this.userService.getById(this.actualite.user_idUser).subscribe(u=>{
      this.candidat=u
      // console.log(this.candidat)
      this.candLoaded = true
      this.answerService.resultat(this.actualite.idArchivage,this.candidat.idUser,this.quiz.idQuizz).subscribe(res=>{
        this.resultat=res
        console.log(this.resultat)
      })
    })

  }

}

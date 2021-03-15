import { Component, Input, OnInit } from '@angular/core';
import { Quiz } from 'src/app/_models/quiz';
import { User } from 'src/app/_models/user';
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

  constructor(private quizService : QuizService,private userService : UserService) {

   }

  ngOnInit(): void {
        this.quizService.getById(this.actualite.quizz_idQuizz).subscribe(q=>{
      this.quiz=q;
    })
    this.userService.getById(this.actualite.user_idUser).subscribe(u=>{
      this.candidat=u
      console.log(this.candidat)
      this.candLoaded = true
    })
  }

}

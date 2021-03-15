import { Component, OnInit } from '@angular/core';
import { Archivage } from 'src/app/_models/archivage';
import { Quiz } from 'src/app/_models/quiz';
import { User } from 'src/app/_models/user';
import { AuthService } from 'src/app/_services/auth.service';
import { QuizService } from 'src/app/_services/quiz.service';
import { UserService } from 'src/app/_services/user.service';

@Component({
  selector: 'app-mes-questionnaires',
  templateUrl: './mes-questionnaires.component.html',
  styleUrls: ['./mes-questionnaires.component.css']
})
export class MesQuestionnairesComponent implements OnInit {

  questionnaires : Quiz[] = [];
  currentUser : User

  constructor(
    private userService : UserService,
    private authService : AuthService) {
      this.authService.currentUser.subscribe(x => this.currentUser = x)
    }

  ngOnInit(): void {
   this.getQuiz();
  }

  getQuiz(){
    this.userService.getUserQuizbtId(this.currentUser.idUser).subscribe(response => {
      this.questionnaires = response.listQuizz;
    });
  }

}

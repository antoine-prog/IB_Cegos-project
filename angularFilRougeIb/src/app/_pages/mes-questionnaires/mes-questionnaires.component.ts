import { Component, OnInit } from '@angular/core';
import { Archivage } from 'src/app/_models/archivage';
import { Quiz } from 'src/app/_models/quiz';
import { QuizService } from 'src/app/_services/quiz.service';

@Component({
  selector: 'app-mes-questionnaires',
  templateUrl: './mes-questionnaires.component.html',
  styleUrls: ['./mes-questionnaires.component.css']
})
export class MesQuestionnairesComponent implements OnInit {

  questionnaires : Quiz[] = [];

  constructor(private quiService : QuizService) { }

  ngOnInit(): void {
   this.getQuiz();
  }

  getQuiz(){
    this.quiService.getAll().subscribe(response => {
      this.questionnaires = response;
    });
  }

}

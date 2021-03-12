import { Component, Input, OnInit } from '@angular/core';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Quiz } from 'src/app/_models/quiz';
import { MesQuestionnairesComponent } from 'src/app/_pages/mes-questionnaires/mes-questionnaires.component';
import { QuizService } from 'src/app/_services/quiz.service';
import { DialogComponent } from '../dialog/dialog.component';

export interface DialogData {
  name: string;
  code: string;
}

@Component({
  selector: 'app-questionnaire',
  templateUrl: './questionnaire.component.html',
  styleUrls: ['./questionnaire.component.css']
})
export class QuestionnaireComponent implements OnInit {

  @Input() questionnaire : Quiz;

  constructor(
    private quizService : QuizService,
    private questionnaires : MesQuestionnairesComponent,
    public dialog: MatDialog) { }

  ngOnInit(): void {
  }


  openDialog(): void {
    const dialogRef = this.dialog.open(DialogComponent, {
      width: '40rem',
      data: {name: this.questionnaire.name, code: this.questionnaire.code}
    });
  }

  deleteQuiz() : void {
    this.quizService.delete(this.questionnaire.idQuizz).subscribe(data =>this.questionnaires.getQuiz() );
  }


}

import { Component, OnInit } from '@angular/core';
import { Theme } from 'src/app/_models/theme';
import { QuizService } from 'src/app/_services/quiz.service';
import { ThemesService } from 'src/app/_services/themes.service';

@Component({
  selector: 'app-creation-quiz',
  templateUrl: './creation-quiz.component.html',
  styleUrls: ['./creation-quiz.component.css']
})
export class CreationQuizComponent implements OnInit {

  themes : Theme[] = [];

  constructor(private themesService : ThemesService,
    private quizService : QuizService) { }

  ngOnInit(): void {
    this.getThemesQuiz();
  }

  getThemesQuiz(){
    this.themesService.getAll().subscribe(response => {
      this.themes = response;
    })
  }
}

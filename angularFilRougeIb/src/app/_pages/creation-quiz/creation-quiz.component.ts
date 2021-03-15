import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Question } from 'src/app/_models/question';
import { Theme } from 'src/app/_models/theme';
import { User } from 'src/app/_models/user';
import { AlertService } from 'src/app/_services/alert.service';
import { AuthService } from 'src/app/_services/auth.service';
import { QuizService } from 'src/app/_services/quiz.service';
import { ThemesService } from 'src/app/_services/themes.service';

@Component({
  selector: 'app-creation-quiz',
  templateUrl: './creation-quiz.component.html',
  styleUrls: ['./creation-quiz.component.css']
})
export class CreationQuizComponent implements OnInit {

  themes : Theme[] = [];
  currentUser : User;
  quizForm : FormGroup;
  loading = false;
  isSubmitted = false;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private themesService : ThemesService,
    private quizService : QuizService,
    private alertService: AlertService,
    private fb : FormBuilder,
    private authService : AuthService
    ) {
      this.authService.currentUser.subscribe(x => this.currentUser = x);
      this.quizForm = this.fb.group({
        name : ['', Validators.required],
        user_idUser :  [this.currentUser.idUser],
        theme_idTheme:  [''],
        code : [''],
        dateClosed : [''],
        timer : [''],
        level_idLevel : [''],
        listquestionsolution : [[]]
    })
  }


  ngOnInit(): void {
    this.getThemesQuiz();
  }

  getThemesQuiz(){
    this.themesService.getAll().subscribe(response => {
      this.themes = response;
    })
  }

  onSubmit = () =>{
    this.isSubmitted = true;

    //reset alert on submit
    this.alertService.clear();

    //stop if form invalid
    if(this.quizForm.invalid){
      return;
    }

    this.loading = true;
    this.quizService
      .create(this.quizForm.value)
      .subscribe(
        {
        next:() =>{
          this.alertService.success('Registration successful', { keepAfterRouteChange: true });
          this.router.navigate(['/creation-questions'], { relativeTo: this.route });
        },
        error: error => {
          this.alertService.error(error);
          this.loading = false;
      }
    }
    );
  }
}

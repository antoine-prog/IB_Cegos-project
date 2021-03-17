import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { DateAdapter, MAT_DATE_FORMATS, MAT_DATE_LOCALE } from '@angular/material/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Question } from 'src/app/_models/question';
import { Quiz } from 'src/app/_models/quiz';
import { User } from 'src/app/_models/user';
import { AlertService } from 'src/app/_services/alert.service';
import { AuthService } from 'src/app/_services/auth.service';
import { QuizService } from 'src/app/_services/quiz.service';
import { SharedService } from 'src/app/_services/shared.service';


@Component({
  selector: 'app-quiz-cree-code',
  templateUrl: './quiz-cree-code.component.html',
  styleUrls: ['./quiz-cree-code.component.css']
})
export class QuizCreeCodeComponent implements OnInit {

  quiz : Quiz ;
  quizForm : FormGroup;
  loading = false;
  isSubmitted = false;
  currentUser : User;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private shared: SharedService,
    private quizService: QuizService,
    private alertService: AlertService,
    private fb : FormBuilder,
    private authService: AuthService,
  ) {

   }

  ngOnInit(): void {
    this.shared.quiz.subscribe((result)=> {
      this.quiz=result;
    })
    console.log("icii", this.quiz);

    this.quizForm = this.fb.group({
      idQuizz: [this.quiz.idQuizz],
      name : [this.quiz.name],
      user_idUser : [this.quiz.user_idUser],
      theme_idTheme: [this.quiz.theme_idTheme],
      code : [this.quiz.code],
      timer :[''],
      dateClosed : [''],
      level_idLevel : [this.quiz.level_idLevel],
      listquestionsolution : [[]]
    });
    this.authService.currentUser.subscribe(x => this.currentUser = x);
  }

  get f() { return this.quizForm.controls; }

  onSubmit() : void {
    this.isSubmitted = true;
    this.quizForm.value.dateClosed

    if (this.quizForm.value.dateClosed == ''){
      this.quizForm.value.dateClosed = '9999-12-31'
    }

    //reset alert on submit
    this.alertService.clear();

    //stop if form invalid
    if(this.quizForm.invalid){
      return;
    }
  console.log("value", this.quizForm.value);
  console.log("form", this.quizForm);
    this.loading = true;
    this.quizService
      .update(this.quizForm.value)
      .subscribe(
        {
        next:() =>{
          console.log(this.quizForm.value.code);
        },
        error: error => {
          this.alertService.error(error);
          this.loading = false;
      }
    }
    );
  }

  onHome() : void{
    this.router.navigate(['/home-connecte'], { relativeTo: this.route });
  }

}

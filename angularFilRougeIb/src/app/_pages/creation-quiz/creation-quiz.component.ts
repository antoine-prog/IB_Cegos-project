import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Question } from 'src/app/_models/question';
import { Theme } from 'src/app/_models/theme';
import { User } from 'src/app/_models/user';
import { AlertService } from 'src/app/_services/alert.service';
import { AuthService } from 'src/app/_services/auth.service';
import { HomeService } from 'src/app/_services/home.service';
import { QuizService } from 'src/app/_services/quiz.service';
import { SharedService } from 'src/app/_services/shared.service';
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
  listCode = [];

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private themesService : ThemesService,
    private quizService : QuizService,
    private alertService: AlertService,
    private fb : FormBuilder,
    private authService : AuthService,
    private homeService : HomeService,
    private sharedService : SharedService,
    ) {
      this.authService.currentUser.subscribe(x => this.currentUser = x);
      this.quizForm = this.fb.group({
        name : ['', Validators.required],
        user_idUser : [this.currentUser.idUser],
        theme_idTheme: ['', Validators.required],
        code : [this.getRandomString(10)],
        dateClosed : ['9999-12-31'],
        level_idLevel : ['', Validators.required],
        listquestionsolution : [[]]
    })
  }

  ngOnInit(): void {
    this.getThemesQuiz();
  }

  get f() { return this.quizForm.controls; }

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
          this.continue(this.quizForm.value.code);
          console.log(this.quizForm.value.code);
        },
        error: error => {
          this.alertService.error(error);
          this.loading = false;
      }
    }
    );
  }

  continue = (code :string) =>{
    this.homeService.getByCode(code).subscribe(
      (data) => {
          this.sharedService.UpdateQuiz(data)
          this.sharedService.UpdateCode(code)
          this.router.navigate(['/creation-questions'], { relativeTo: this.route });
          })
  }





   getRandomString(length) : string {
    this.quizService.getAll().subscribe(data => ( quiz => this.listCode.push(quiz.code)));

    var randomChars = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';
    var result = '';

    for ( var i = 0; i < length; i++ ) {
        result += randomChars.charAt(Math.floor(Math.random() * randomChars.length));
    }

    while(this.listCode.includes(result)){
      for ( var i = 0; i < length; i++ ) {
        result += randomChars.charAt(Math.floor(Math.random() * randomChars.length));
      }
    }

    return result;
}
}

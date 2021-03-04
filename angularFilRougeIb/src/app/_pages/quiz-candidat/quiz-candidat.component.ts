import { Component, OnInit } from '@angular/core';
import { Quiz } from 'src/app/_models/quiz';
import { HomeService } from 'src/app/_services/home.service';
import { SharedService } from 'src/app/_services/shared.service';

@Component({
  selector: 'app-quiz-candidat',
  templateUrl: './quiz-candidat.component.html',
  styleUrls: ['./quiz-candidat.component.css']
})
export class QuizCandidatComponent implements OnInit {

  quiz : Quiz

  constructor(private shared : SharedService,private service : HomeService ) { }


  ngOnInit(): void {
    this.service.getByCode("azerty").subscribe((quiz)=>{
      this.quiz=quiz
      console.log(this.quiz.listquestionsolution)
    })
    // this.shared.quiz.subscribe((quiz) => {
    //   this.quiz = quiz;
    // } )
  }

}

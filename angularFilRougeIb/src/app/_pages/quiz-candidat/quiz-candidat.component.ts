import { Component, Input, OnInit } from '@angular/core';
import { FormArray, FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { Quiz } from 'src/app/_models/quiz';
import { HomeService } from 'src/app/_services/home.service';
import { SharedService } from 'src/app/_services/shared.service';

@Component({
  selector: 'app-quiz-candidat',
  templateUrl: './quiz-candidat.component.html',
  styleUrls: ['./quiz-candidat.component.css']
})

@Input() 
export class QuizCandidatComponent implements OnInit {

  quiz : Quiz
  private listReponses : any[]
  
  constructor(private shared : SharedService,private service : HomeService, private route:Router) {
    // this.listReponses=this.fb.array([
    //   this.fb.control('')
    // ])
    this.listReponses=[]
   }
  //  get listReponses() : FormArray {
  //    return this.listReponses
  //  }
   
  ngOnInit(): void {
    // debug
    this.service.getByCode("azerty").subscribe((quiz)=>{
      this.quiz=quiz
      this.shared.UpdateQuiz(quiz)
      console.log(this.quiz.listquestionsolution)
    })
    // this.shared.quiz.subscribe((quiz) => {
    //   this.quiz = quiz;
    // } )
  }
  addReponse(){
    // this.listReponses.push(this.fb.control(''))
    alert("oi")
  }


  valider() {
    this.route.navigate(["validation_quiz_candidat"]);
  }
  
}

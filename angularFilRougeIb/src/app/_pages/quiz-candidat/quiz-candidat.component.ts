import { Component, Input, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { AnyCnameRecord } from 'node:dns';
import { Answer } from 'src/app/_models/answer';
import { Quiz } from 'src/app/_models/quiz';
import { Solution } from 'src/app/_models/solution';
import { AnswerService } from 'src/app/_services/answer.service';
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
  listReponses =new Map<number,number>();
  
  
  constructor(private shared : SharedService,private homeService : HomeService,private answerService : AnswerService, private route:Router) {
    // this.listReponses=this.fb.array([
    //   this.fb.control('')
    // ])
    // this.listReponses=[]
   }
  //  get listReponses() : FormArray {
  //    return this.listReponses
  //  }
   
  ngOnInit(): void {
    // debug
    this.homeService.getByCode("azerty").subscribe((quiz)=>{
      this.quiz=quiz
      this.shared.UpdateQuiz(quiz)
      console.log(this.quiz.listquestionsolution)
    })
    // this.shared.quiz.subscribe((quiz) => {
    //   this.quiz = quiz;
    // } )
  }
  updateReponse(event){
    this.listReponses.set(event[0],event[1])
    console.clear()

    this.quiz.listquestionsolution.forEach(question =>{
      let q = question as any
      console.log([q.idQuestion,this.listReponses.get(q.idQuestion)])
    })
    
    console.log(this.listReponses)
  }


  valider() {
    this.quiz.listquestionsolution.forEach(question =>{
      console.clear
      let q = question as any
      // console.log(q)
      q.solution.forEach(sol => {
        // if(sol.idSolution=this.listReponses.get(q.idQuestion)){
        //   console.log(q.title)
        // }
        if(sol.idSolution==this.listReponses.get(q.idQuestion)){

          let solution=sol.solution as string
          let isTrue=sol.isTrue as boolean
          // console.log({"answer":sol.solution,"result":sol.isTrue})
          
          // this.answerService.postAnswer({"answer":sol.solution,"result":sol.isTrue}as Answer).subscribe()
        }
      })
      // console.log([q.idQuestion,this.listReponses.get(q.idQuestion)])
      // let sol  = this.getSol(q.idQuestion,this.listReponses.get(q.idQuestion));
      // console.log(sol)
    })
    // this.route.navigate(["validation_quiz_candidat"]);

  }
  getQuestion(idquestion :number) {
    this.quiz.listquestionsolution.forEach((item)=> {
      let i=item as any
      if(i.idQuestion=idquestion){
        console.log("trouvé")
        // console.log(i.idQuestion,idquestion)
        var question= i as any[];
        return question
        
      }
        // console.log(question)
        // question.forEach((solution)=>{
        //   if(solution.idSolution==idsolution){
        //     return solution
        //   }
        // })
      

    })
  }
  getSol(idquestion :number,idsolution:number){
    let question= this.getQuestion(idquestion)
    console.log(question)
  }
}

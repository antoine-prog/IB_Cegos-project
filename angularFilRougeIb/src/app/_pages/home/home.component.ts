import { Input } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { Quizz } from 'src/app/_models/quizz';
import { HomeService } from 'src/app/_services/home.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  Code : string
  Quiz : Quizz 
  constructor(private service : HomeService) { }
  
  
  ngOnInit(): void {
  }


  start = () =>{
    // console.log(this.Code);
    this.service.getByCode(this.Code).subscribe(
      (data) => {
      // Object.keys(data).forEach(key => {
      // console.log(data);
      this.Quiz=data;
      // console.log(data)
       console.log(data);    
      if(this.Quiz.idQuizz==null) {
        alert("Id null !!")
      } 
      else
      {
        alert("Id "+this.Quiz.idQuizz)
        
      }
      })
    // if(code !=0){
    //   alert("Début de quiz")
    // }
    // else{
    //   alert("Aucun questionnaire ne correpond à ce code")
    // }
  }

}

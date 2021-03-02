import { Input, Output } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { NavigationExtras, Router } from '@angular/router';
import * as EventEmitter from 'events';
import { send } from 'process';
import { Quiz } from 'src/app/_models/quiz';
import { HomeService } from 'src/app/_services/home.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  Code : string
  Quiz : Quiz 
  constructor(private service : HomeService, private router :Router) { }
  
  
  ngOnInit(): void {
  }



  start = () =>{
    // console.log(this.Code);
    this.service.getByCode(this.Code).subscribe(
      (data) => {
        
        this.Quiz=data;
        // console.log(data); 

        if(this.Quiz.idQuizz==null) {
          alert("Le code que vous avez entré est incorrect. Veuillez réessayer.")
        } 
        else
        {
          let navigationExtras:NavigationExtras = {
            queryParams : { 
              idQuiz:this.Quiz.idQuizz,
              name:this.Quiz.name,
               user_idUser:this.Quiz.user_idUser,
              theme_idTheme:this.Quiz.theme_idTheme,
              code:this.Quiz.code,
               dateClosed:this.Quiz.dateClosed,
               timer:this.Quiz.timer,
               level_idLevel:this.Quiz.level_idLevel
              
              // quiz : new Quiz(this.Quiz.name,this.Quiz.user_idUser,this.Quiz.theme_idTheme,this.Quiz.code,this.Quiz.level_idLevel,this.Quiz.dateClosed,this.Quiz.timer,this.Quiz.idQuizz) 
            },
            skipLocationChange:true
          }
          console.log(this.Quiz)
            this.router.navigate(["espace_candidat"],navigationExtras)//.then(
          //    () => this.service.emmiter.emit()
          //  )
        }
          })
  }

}

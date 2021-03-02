import { Input, Output } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { NavigationExtras, Router } from '@angular/router';
import * as EventEmitter from 'events';
import { send } from 'process';
import { Quiz } from 'src/app/_models/quiz';
import { HomeService } from 'src/app/_services/home.service';
import { SharedService } from 'src/app/_services/shared.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  Code : string
  IsNotOk : boolean
  constructor(private service : HomeService,private shared : SharedService, private router :Router) { }
  SharedQuiz : Quiz;
  
  ngOnInit(): void {
    this.shared.quiz.subscribe((result) =>{
      this.SharedQuiz=result
    } )
  }



  start = () =>{
    this.service.getByCode(this.Code).subscribe(
      (data) => {
        this.IsNotOk=(data.idQuizz==null);
        if(this.IsNotOk) {
          alert("Le code que vous avez entré est incorrect. Veuillez réessayer.")
        } 
        else
        {
          this.shared.UpdateQuiz(data)
          this.router.navigate(["espace_candidat"])
        }
          })
  }

}

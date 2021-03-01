import { Input } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
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
  constructor(private service : HomeService) { }
  
  
  ngOnInit(): void {
  }


  start = () =>{
    // console.log(this.Code);
    this.service.getByCode(this.Code).subscribe(
      (data) => {
        
        this.Quiz=data;
        console.log(data);  

        if(this.Quiz.idQuizz==null) {
          alert("Le code que vous avez entré est incorrect. Veuillez réessayer.")
        } 
        else
        {
          
        }
          })
  }

}

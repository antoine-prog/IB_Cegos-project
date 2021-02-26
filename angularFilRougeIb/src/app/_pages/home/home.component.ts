import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }
  start = () =>{
    // if(code !=0){
    //   alert("Début de quiz")
    // }
    // else{
    //   alert("Aucun questionnaire ne correpond à ce code")
    // }
  }

}

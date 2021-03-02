import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Quiz } from 'src/app/_models/quiz';

@Component({
  selector: 'app-inscription-candidat',
  templateUrl: './inscription-candidat.component.html',
  styleUrls: ['./inscription-candidat.component.css']
})
export class InscriptionCandidatComponent implements OnInit {

  Quiz : Quiz 
  constructor(private route:ActivatedRoute) { 

  }
  

  ngOnInit() {
    this.route.queryParams.subscribe(params=> {

      this.Quiz=params as Quiz;
  console.log(this.Quiz)
})

}}

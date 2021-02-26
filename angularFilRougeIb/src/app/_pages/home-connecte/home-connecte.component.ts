import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-home-connecte',
  templateUrl: './home-connecte.component.html',
  styleUrls: ['./home-connecte.component.css']
})
export class HomeConnecteComponent implements OnInit {
  actualites = [
    {nom : "nom du candidat", prenom : "prénom du candidat"},
    {nom :"nom du candidat", prenom :"prénom du candidat"}
  ]


  constructor() {}

  ngOnInit(): void {
  }

}

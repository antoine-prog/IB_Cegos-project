import { Component, Input, OnInit } from '@angular/core';
import { Solution } from 'src/app/_models/solution';

@Component({
  selector: 'app-solution',
  templateUrl: './solution.component.html',
  styleUrls: ['./solution.component.css']
})
export class SolutionComponent implements OnInit {

  @Input() solution : Solution
  constructor() { }

  ngOnInit(): void {
  }

}

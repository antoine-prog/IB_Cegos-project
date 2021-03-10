import { EventEmitter ,Component, Input, OnInit, Output } from '@angular/core';

import { Question } from 'src/app/_models/question';

@Component({
  selector: 'app-question',
  templateUrl: './question.component.html',
  styleUrls: ['./question.component.css']
})
export class QuestionComponent implements OnInit {

  @Input() question;
  @Output() questionUpdate = new EventEmitter<any>()
  selected : number[];
  text : string;


  constructor() { 
    this.selected=[]
  }

  relai(event){
    // if(this.selected.indexOf(event)>-1  ){
    //   delete this.selected[event]  
    // }
    const index = this.selected.indexOf(event, 0);
      if (index > -1) {
        this.selected.splice(index, 1);
      }
      else {
        this.selected.push(event)
      }
    this.questionUpdate.emit(this.selected)
  }
  ngOnInit(): void {
  }

}

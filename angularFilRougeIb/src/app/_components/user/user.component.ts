import { Component, Input, OnInit } from '@angular/core';
import { Quiz } from 'src/app/_models/quiz';
import { User } from 'src/app/_models/user';
import { UserService } from 'src/app/_services/user.service';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {

  @Input() user : User;
  panelOpenState = false;
  listQuiz : Quiz[] ;

  constructor(private service : UserService) { }

  ngOnInit(): void {
  }

  openPannel(){
    this.panelOpenState = true
    this.service.getUserQuizbtId(this.user.idUser).subscribe(user =>{console.log(user)})
    this.listQuiz = this.user.listQuiz;
  }

  closePannel(){
    this.panelOpenState = false
  }

  deleteUtilisateur() : void {
    console.log(this.user.idUser);
    this.service.delete(this.user.idUser).subscribe(user => {console.log(user)});
  }

  deleteQuiz() : void {

  }
}

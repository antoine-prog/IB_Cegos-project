import { Component, Input, OnInit, Output, ViewChild } from '@angular/core';
import { Quiz } from 'src/app/_models/quiz';
import { User } from 'src/app/_models/user';
import { UsersComponent } from 'src/app/_pages/users/users.component';
import { UserService } from 'src/app/_services/user.service';
import { switchMap } from 'rxjs/operators';
import * as EventEmitter from 'events';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {

  @Input() user : User;
  panelOpenState = false;
  //listQuiz : Quiz[] = [] ;
  descriptionA : string = "Cliquer pour afficher l'utilisateur";
  descriptionB : string = "Afficher";
  test : boolean = true;

  constructor(private service : UserService, private users:UsersComponent) { }

  ngOnInit(): void {
    this.getUserQuiz();
  }

  getUserQuiz(){
    console.log(this.user.listQuizz);
    this.service.getUserQuizbtId(this.user.idUser).subscribe(data => {
      // this.user.listQuiz = [...data];
      this.user.listQuizz = data.listQuizz
      console.log(this.user.listQuizz);
    })
    //this.listQuiz = this.user.listQuiz;
    // console.log(this.user.listQuiz);
  }

  openPannelA(){
    this.panelOpenState = true;
    this.descriptionA = "Cliquer pour fermer l'utilisateur";
  }

  closePannelA(){
    this.panelOpenState = false;
    this.descriptionA = "Cliquer pour afficher l'utilisateur";
  }

  openPannelB(){
    this.descriptionB = "Fermer";
  }

  closePannelB(){
    this.descriptionB = "Afficher"
  }

  deleteUtilisateur() : void {
    this.service.delete(this.user.idUser).subscribe(data =>this.users.getUsers()  );

  }


  deleteQuiz() : void {
  }

}

import { Component, Input, OnInit, Output, ViewChild } from '@angular/core';
import { Quiz } from 'src/app/_models/quiz';
import { User } from 'src/app/_models/user';
import { UsersComponent } from 'src/app/_pages/users/users.component';
import { UserService } from 'src/app/_services/user.service';
import { switchMap } from 'rxjs/operators';
import * as EventEmitter from 'events';
import { QuizService } from 'src/app/_services/quiz.service';
import { Router } from '@angular/router';
import { SharedService } from 'src/app/_services/shared.service';

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

  constructor(private userService : UserService,
    private users:UsersComponent,
    private quizService : QuizService,
    private shared : SharedService,
    private router : Router) { }

  ngOnInit(): void {
    this.getUserQuiz();
  }
  navtoedit = () =>{
    this.shared.UpdateEditId(this.user.idUser)
    this.router.navigate(["/modifier-profil"])
  }
  getUserQuiz(){
    this.userService.getUserQuizbtId(this.user.idUser).subscribe(data => {
      this.user.listQuizz = data.listQuizz;
    })
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
    this.userService.delete(this.user.idUser).subscribe(data =>this.users.getUsers()  );
  }


  deleteQuiz( id : number) : void {
    this.quizService.delete(id).subscribe(data =>this.getUserQuiz())
  }

}

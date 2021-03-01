import { Component, Input, OnInit } from '@angular/core';
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

  constructor(private service : UserService) { }

  ngOnInit(): void {
  }

  deleteUtilisateur() : void {
    console.log(this.user.idUser);
    this.service.delete(this.user.idUser).subscribe(user => {console.log(user)});
  }

  deleteQuiz() : void {

  }
}

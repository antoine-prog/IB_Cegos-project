import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/_models/user';
import { UserService } from 'src/app/_services/user.service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {

  users : User[] = [];

  constructor(private UserService : UserService) { }

  ngOnInit(): void {
   this.getUsers();
  }

  getUsers(){
    this.UserService.getAll().subscribe(response => {
      this.users = response;
    });
  }
}

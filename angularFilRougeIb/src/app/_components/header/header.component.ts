import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { User } from 'src/app/_models/user';
import { AuthService } from 'src/app/_services/auth.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  currentUser : User;


  constructor(
    private authService: AuthService,
    private router: Router
    ) {
    this.authService.currentUser.subscribe(x => this.currentUser = x);
  }

  ngOnInit(): void {
  }

  seDeconnecter(){
    this.authService.disconnect();
    this.router.navigateByUrl('/home');
  }
}

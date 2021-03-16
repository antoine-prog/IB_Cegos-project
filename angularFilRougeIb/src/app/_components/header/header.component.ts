import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { User } from 'src/app/_models/user';
import { AuthService } from 'src/app/_services/auth.service';
import { SharedService } from 'src/app/_services/shared.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  currentUser : User;


  constructor(
    private authService: AuthService,
    private router: Router,
    private shared :SharedService
    ) {
    this.authService.currentUser.subscribe(x => this.currentUser = x);
  }

  ngOnInit(): void {
  }

  navtoeditprofil(){
    this.shared.UpdateEditId(this.authService.currentUserValue.idUser)
    this.router.navigate(["/modifier-profil"])

  }
  seDeconnecter(){
    this.authService.disconnect();
    this.router.navigateByUrl('/home');
  }
}

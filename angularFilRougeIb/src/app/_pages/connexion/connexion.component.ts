import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { first } from 'rxjs/operators';
import { AuthService } from 'src/app/_services/auth.service';

@Component({
  selector: 'app-connexion',
  templateUrl: './connexion.component.html',
  styleUrls: ['./connexion.component.css']
})
export class ConnexionComponent implements OnInit {

  loginForm: FormGroup;
  isSubmitted = false;
  returnUrl : string;

  constructor(
    private authService: AuthService,
    private router: Router,
    private formBuilder: FormBuilder
    ) {
      if(this.authService.currentUserValue){
        this.router.navigateByUrl('/home');
      }
    }

  ngOnInit(): void {
    this.loginForm = this.formBuilder.group({
      username : ['', Validators.required],
      password : ['',Validators.required]
    });

  }

  get formControls() { return this.loginForm.controls;}

  onSubmit(){
    console.log(this.loginForm.value);
    this.isSubmitted = true;

    //stop if form invalid
    if(this.loginForm.invalid){
      return;
    }

    this.authService.connect(this.formControls.username, this.formControls.password)
      .pipe(first())
      .subscribe(
        date => {this.router.navigateByUrl('/home-connecte')}
      ),
      error => {
        alert("ereur")
      }
  }

}

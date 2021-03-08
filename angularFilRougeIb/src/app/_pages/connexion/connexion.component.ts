import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ThemePalette } from '@angular/material/core';
import { ProgressSpinnerMode } from '@angular/material/progress-spinner';
import { ActivatedRoute, Router } from '@angular/router';
import { first } from 'rxjs/operators';
import { AlertService } from 'src/app/_helper/alert.service';
import { AuthService } from 'src/app/_services/auth.service';

@Component({
  selector: 'app-connexion',
  templateUrl: './connexion.component.html',
  styleUrls: ['./connexion.component.css']
})
export class ConnexionComponent implements OnInit {

  loginForm: FormGroup;
  isSubmitted = false;
  loading = false;

  //progresse sninner
  color: ThemePalette = 'primary';
  mode: ProgressSpinnerMode = 'indeterminate';


  constructor(
    private authService: AuthService,
    private route: ActivatedRoute,
    private router: Router,
    private formBuilder: FormBuilder,
    private alertService: AlertService
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

  //getter pour acceder facilement aux champs du formulaire
  get formControls() { return this.loginForm.controls;}

  onSubmit(){
    console.log(this.loginForm.value);
    this.isSubmitted = true;

    //reset alert on submit
    this.alertService.clear();

    //stop if form invalid
    if(this.loginForm.invalid){
      return;
    }

    this.loading = true;

    this.authService.connect(this.formControls.username.value, this.formControls.password.value)
      .pipe(first())
      .subscribe({
        next: () => {
        // get return url from query parameters or default to home page
        const returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/home-connecte';
        this.router.navigateByUrl(returnUrl);
    },
    error: error => {
        this.alertService.error(error);
        this.loading = false;
    }
      });
  }

}

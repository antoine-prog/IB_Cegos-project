import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

import { AlertService } from 'src/app/_services/alert.service';
import { UserService } from 'src/app/_services/user.service';

@Component({
  selector: 'app-inscription',
  templateUrl: './inscription.component.html',
  styleUrls: ['./inscription.component.css']
})
export class InscriptionComponent implements OnInit {

  userForm : FormGroup;
  loading = false;
  submitted = false;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private fb : FormBuilder,
    private service : UserService,
    private alertService: AlertService
    ){
      this.userForm = this.fb.group({
        firstName: ['', Validators.required],
        lastName: ['', Validators.required],
        username:['',Validators.required],
        adress: [''],
        mail: ['', Validators.required],
        password:['',['', [Validators.required, Validators.minLength(6)]]],
        isAdmin:false,
        isCreator:true
      })
    }

  ngOnInit(): void {
  }

  // onRegister = () => {
  //   alert("Vous êtes enregistré(e)");
  // }

  get f() { return this.userForm.controls; }

  onSubmit = () =>{
    this.service
      .create(this.userForm.value)
      .subscribe({
        next:() =>{
          this.alertService.success('Registration successful', { keepAfterRouteChange: true });
          this.router.navigate(['/home-connecte'], { relativeTo: this.route });
        },
        error: error => {
          this.alertService.error(error);
          this.loading = false;
      }
    });
  }


}

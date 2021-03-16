import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, FormGroupDirective, NgForm, Validators } from '@angular/forms';
import { ErrorStateMatcher } from '@angular/material/core';
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
  isSubmitted = false;
  hide = true;
  matcher = new MyErrorStateMatcher();

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private fb : FormBuilder,
    private userService : UserService,
    private alertService: AlertService
    ){
      this.userForm = this.fb.group({
        firstName: ['', Validators.required],
        lastName: ['', Validators.required],
        username:['',Validators.required],
        adress: [''],
        mail: ['', [Validators.required, Validators.email]],
        isAdmin:false,
        isCreator:true,
        password:['', [Validators.required, Validators.minLength(6),Validators.maxLength(30), Validators.pattern('((?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).{0,})')]],
        confirmPassword: ['',Validators.required],
    })}

  ngOnInit(): void {
  }

  // onRegister = () => {
  //   alert("Vous êtes enregistré(e)");
  // }

  get f() { return this.userForm.controls; }

  getErrorMessage() {
    if (this.f.mail.hasError('required')) {
      return 'e-mail requis';
    }
    return this.f.mail.hasError('email') ? 'adresse e-mail incorrect' : '';
  }

  checkPasswords(group: FormGroup){
    let password = group.get('password').value;
    let confirmPassword = group.get('confirmPassword').value;
    return password === confirmPassword ? null : { notSame: true };
  }

  onSubmit = () =>{
    this.isSubmitted = true;

    //reset alert on submit
    this.alertService.clear();

    //stop if form invalid
    if(this.userForm.invalid){
      return;
    }

    this.loading = true;
    this.userService
      .create(this.userForm.value)
      .subscribe(
        {
        next:() =>{
          this.alertService.success('Registration successful', { keepAfterRouteChange: true });
          this.router.navigate(['/home-connecte'], { relativeTo: this.route });
        },
        error: error => {
          this.alertService.error(error);
          this.loading = false;
      }
    }
    );
  }
}

export class MyErrorStateMatcher implements ErrorStateMatcher {
  isErrorState(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean {
    const invalidCtrl = !!(control && control.invalid && control.parent.dirty);
    const invalidParent = !!(control && control.parent && control.parent.invalid && control.parent.dirty);

    return (invalidCtrl || invalidParent);
  }
}

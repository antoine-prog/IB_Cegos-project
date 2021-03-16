import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, FormGroupDirective, NgForm, Validators } from '@angular/forms';
import { ErrorStateMatcher } from '@angular/material/core';
import { ActivatedRoute, Router } from '@angular/router';
import { User } from 'src/app/_models/user';


import { AlertService } from 'src/app/_services/alert.service';
import { AuthService } from 'src/app/_services/auth.service';
import { SharedService } from 'src/app/_services/shared.service';
import { UserService } from 'src/app/_services/user.service';

@Component({
  selector: 'app-modifier-profil',
  templateUrl: './modifier-profil.component.html',
  styleUrls: ['./modifier-profil.component.css']
})
export class ModifierProfilComponent implements OnInit {

  userForm : FormGroup;
  loading = false;
  isSubmitted = false;
  hide = true;
  matcher = new MyErrorStateMatcher();
  user:User;
  idUser:number;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private fb : FormBuilder,
    private service : UserService,
    private alertService: AlertService,
    private authService :AuthService,
    private shared : SharedService
    
    ){
      if(!this.authService.currentUserValue.isAdmin)
      {
        this.user=this.authService.currentUserValue
        this.formage()
      }
      else {
        this.shared.editId.subscribe(id=>{
          this.service.getById(id).subscribe(usercible=>{
            this.user=usercible
            this.formage()
        })
      })
  }}
formage(){ 
  this.userForm = this.fb.group({
    firstName: [this.user.firstName, Validators.required],
    lastName: [this.user.lastName, Validators.required],
    username:[this.user.username,Validators.required],
    adress: [this.user.adress],
    mail: [this.user.mail, [Validators.required, Validators.email]],
    isAdmin:this.user.isAdmin,
    isCreator:this.user.isCreator,
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
    this.service
      .update(this.userForm.value,this.user.idUser)
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

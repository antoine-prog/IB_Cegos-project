import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from 'src/app/_services/user.service';

@Component({
  selector: 'app-inscription',
  templateUrl: './inscription.component.html',
  styleUrls: ['./inscription.component.css']
})
export class InscriptionComponent implements OnInit {

  userForm : FormGroup;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private fb : FormBuilder,
    private service : UserService){
      this.userForm = this.fb.group({
        firstName: [''],
        lastName: [''],
        username:[''],
        adress: [''],
        mail: [''],
        password:[''],
        isAdmin:false,
        isCreator:true
      })
    }

  ngOnInit(): void {
  }

  // onRegister = () => {
  //   alert("Vous êtes enregistré(e)");
  // }

  onSubmit = () =>{
    this.service.create(this.userForm.value).subscribe();
    this.router.navigate(['/home-connecte'], { relativeTo: this.route });
  }


}

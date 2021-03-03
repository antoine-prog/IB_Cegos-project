import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { Form, FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Quiz } from 'src/app/_models/quiz';
import { User } from 'src/app/_models/user';
import { SharedService } from 'src/app/_services/shared.service';
import { UserService } from 'src/app/_services/user.service';

@Component({
  selector: 'app-inscription-candidat',
  templateUrl: './inscription-candidat.component.html',
  styleUrls: ['./inscription-candidat.component.css']
})
export class InscriptionCandidatComponent implements OnInit {

  Quiz : Quiz 
  userForm : FormGroup

  constructor(private fb : FormBuilder,private router: Router,private route:ActivatedRoute,
    private shared : SharedService,private service : UserService) { 
      this.userForm = this.fb.group({
        firstName: [''],
        lastName: [''],
        username:'',
        adress: '',
        mail: [''],
        password:'',
        isAdmin:false,
        isCreator:false
      })
  }
  
  onSubmit(){
    let alpha : User = this.userForm.value as User
    if(this.checkExists()){
      // let candidat : User = this.service.GetByMail()
    } else {

    }
    
    this.service.create(this.userForm.value).subscribe();
    this.router.navigate(["quiz_candidat"])
  }

  checkExists = () => {
    return true;
  }

  ngOnInit() {
    this.shared.quiz.subscribe((result)=> {
      this.Quiz=result
    })
  }
}
import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { Form, FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { promise } from 'protractor';
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
    let doe : User = this.userForm.value as User
    this.checkExists(doe.mail).subscribe((retour) => {
      if(retour>=1){
        this.service.getById(retour).subscribe((anon) => {
          console.log(anon)
          if(confirm(`Adresse déjà utilisée ! Continuer en tant que ${anon.firstName } ${anon.lastName}*/ ?`)){
            alert("On continue !!")
            this.shared.UpdateCurrentUser(anon)
            this.router.navigateByUrl("quiz_candidat")
          } else {}
        })
      }
      else {
        if(confirm(`Continuer en tant que ${doe.firstName} ${doe.lastName} ?`)){
          alert("Nous allons commencer !!")
          this.shared.UpdateCurrentUser(doe)
          this.router.navigateByUrl("quiz_candidat")
        }
      }
    })
    
    // console.log(oi)
    // console.log(oi)
    // if(this.checkExists(alpha.mail)){
    //   // let candidat : User = this.service.GetByMail()
    //   alert("Adresse déjà éxistante !!!")
    // } else {
    //   alert("Adresse nouvelle !!")
    // }
    
    // this.service.create(this.userForm.value).subscribe();
    // this.router.navigate(["quiz_candidat"])
  }
  checkExists =(mail : string)  => {
    // var result : boolean;
    //  this.service.checkMail(mail).subscribe(retour=>{
    //    result=retour
    //    console.log(result)
    //  return result;
    return this.service.checkMail(mail);
      //  console.log(retour);
    //  });
     
    // return oi;
  }

  ngOnInit() {
    this.shared.quiz.subscribe((result)=> {
      this.Quiz=result
    })
  }
}
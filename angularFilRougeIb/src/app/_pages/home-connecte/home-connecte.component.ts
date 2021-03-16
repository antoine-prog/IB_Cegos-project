import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Archivage } from 'src/app/_models/archivage';
import { User } from 'src/app/_models/user';
import { ArchivageService } from 'src/app/_services/archivage.service';
import { AuthService } from 'src/app/_services/auth.service';

@Component({
  selector: 'app-home-connecte',
  templateUrl: './home-connecte.component.html',
  styleUrls: ['./home-connecte.component.css']
})
export class HomeConnecteComponent implements OnInit {
  actualites : Archivage[]
  user:User


  constructor(private archivageService : ArchivageService,private authService : AuthService) {}

  ngOnInit(): void {
    this.user =this.authService.currentUserValue
    console.log("storage",this.authService.currentUserValue)
    console.log("User",this.user)
      this.archivageService.getbyidCreator(this.user.idUser).subscribe(event=>{
        this.actualites=event
        console.log(this.actualites)
      })

    }
      
    
  

}

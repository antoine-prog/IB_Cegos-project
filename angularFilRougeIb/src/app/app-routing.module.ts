import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeConnecteComponent } from './_pages/home-connecte/home-connecte.component';
import { HomeComponent } from './_pages/home/home.component';
import { InscriptionComponent } from './_pages/inscription/inscription.component';
import { NotfoundComponent } from './_pages/notfound/notfound.component';
import { UsersComponent } from './_pages/users/users.component';


const routes: Routes = [
  {path:"", component : HomeComponent},
  {path:"inscription", component : InscriptionComponent},
  {path:"home-connecte", component : HomeConnecteComponent},
  {path:"404", component : NotfoundComponent},
  {path:"users", component : UsersComponent},
  {path:"**", redirectTo: '404'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

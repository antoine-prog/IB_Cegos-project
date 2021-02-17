import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './_pages/home/home.component';
import { InscriptionComponent } from './_pages/inscription/inscription.component';
import { VoletConnectionComponent } from './_pages/volet-connection/volet-connection.component';

const routes: Routes = [
  {path:"", component : HomeComponent},
  {path:"inscription", component : InscriptionComponent},
  {path:"se-connecter", component : VoletConnectionComponent}
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

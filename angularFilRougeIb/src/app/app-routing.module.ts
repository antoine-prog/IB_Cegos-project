import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeConnecteComponent } from './_pages/home-connecte/home-connecte.component';
import { HomeComponent } from './_pages/home/home.component';
import { InscriptionComponent } from './_pages/inscription/inscription.component';
import { NotfoundComponent } from './_pages/notfound/notfound.component';
import { UsersComponent } from './_pages/users/users.component';
import { QuizCreeCodeComponent } from './_pages/quiz-cree-code/quiz-cree-code.component';
import { QuizCandidatComponent } from './_pages/quiz-candidat/quiz-candidat.component';
import { InscriptionCandidatComponent } from './_pages/inscription-candidat/inscription-candidat.component';
import { ModifierProfilComponent } from './_pages/modifier-profil/modifier-profil.component';
import {AuthGuardGuard} from './_guard/auth-guard.guard';
import { ConnexionComponent } from './_pages/connexion/connexion.component';
import { CreationQuizComponent } from './_pages/creation-quiz/creation-quiz.component';
import { MesQuestionnairesComponent } from './_pages/mes-questionnaires/mes-questionnaires.component';


const routes: Routes = [
  {path:"", component : HomeComponent},
  {path:"home", component : HomeComponent},
  {path:"quiz", component : QuizCandidatComponent},
  {path:"espace_candidat",component : InscriptionCandidatComponent },
  {path:"quiz_candidat",component : QuizCandidatComponent},
  {path:"inscription", component : InscriptionComponent},
  {path:"home-connecte", component : HomeConnecteComponent, canActivate:[AuthGuardGuard]},
  {path:"quiz-cree-code", component : QuizCreeCodeComponent, canActivate:[AuthGuardGuard]},
  {path:"create", component : CreationQuizComponent, canActivate:[AuthGuardGuard]},
  {path:"questionnaires", component : MesQuestionnairesComponent, canActivate:[AuthGuardGuard]},

  {path:"404", component : NotfoundComponent},
  {path:"users", component : UsersComponent, canActivate:[AuthGuardGuard]},
  {path:"modifier-profil", component : ModifierProfilComponent, canActivate:[AuthGuardGuard]},
  {path:"connexion", component : ConnexionComponent},
  {path:"**", redirectTo: '404'}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

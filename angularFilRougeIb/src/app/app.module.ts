import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {MatInputModule} from '@angular/material/input';
import {MatAutocompleteModule} from '@angular/material/autocomplete';
import {MatDatepickerModule} from '@angular/material/datepicker';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatRadioModule} from '@angular/material/radio';
import {MatSelectModule} from '@angular/material/select';
import {MatSliderModule} from '@angular/material/slider';
import {MatSlideToggleModule} from '@angular/material/slide-toggle';
import {MatMenuModule} from '@angular/material/menu';
import {MatSidenavModule} from '@angular/material/sidenav';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatListModule} from '@angular/material/list';
import {MatGridListModule} from '@angular/material/grid-list';
import {MatCardModule} from '@angular/material/card';
import {MatStepperModule} from '@angular/material/stepper';
import {MatTabsModule} from '@angular/material/tabs';
import {MatExpansionModule} from '@angular/material/expansion';
import {MatButtonToggleModule} from '@angular/material/button-toggle';
import {MatChipsModule} from '@angular/material/chips';
import {MatIconModule} from '@angular/material/icon';
import {MatProgressSpinnerModule} from '@angular/material/progress-spinner';
import {MatProgressBarModule} from '@angular/material/progress-bar';
import {MatDialogModule} from '@angular/material/dialog';
import {MatTooltipModule} from '@angular/material/tooltip';
import {MatSnackBarModule} from '@angular/material/snack-bar';
import {MatTableModule} from '@angular/material/table';
import {MatSortModule} from '@angular/material/sort';
import {MatPaginatorModule} from '@angular/material/paginator';
import {MatBadgeModule} from '@angular/material/badge';
import {MatCheckboxModule} from '@angular/material/checkbox';
import {MatButtonModule} from '@angular/material/button';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FooterComponent } from './_components/footer/footer.component';
import { HeaderComponent } from './_components/header/header.component';
import { HomeComponent } from './_pages/home/home.component';
import { InscriptionComponent } from './_pages/inscription/inscription.component';
import { VoletConnectionComponent } from './_components/volet-connection/volet-connection.component';
import { MotDePasseOublieComponent } from './_pages/mot-de-passe-oublie/mot-de-passe-oublie.component';
import { MotDePasseOublieDeuxiemePageComponent } from './_pages/mot-de-passe-oublie-deuxieme-page/mot-de-passe-oublie-deuxieme-page.component';
import { InscriptionCandidatComponent } from './_pages/inscription-candidat/inscription-candidat.component';
import { QuizCandidatComponent } from './_pages/quiz-candidat/quiz-candidat.component';
import { ValidationQuizCandidatComponent } from './_pages/validation-quiz-candidat/validation-quiz-candidat.component';
import { HomeConnecteComponent } from './_pages/home-connecte/home-connecte.component';
import { CreationQuizComponent } from './_pages/creation-quiz/creation-quiz.component';
import { CreationQuestionsQuizComponent } from './_pages/creation-questions-quiz/creation-questions-quiz.component';
import { QuizCreeCodeComponent } from './_pages/quiz-cree-code/quiz-cree-code.component';
import { MesQuestionnairesComponent } from './_pages/mes-questionnaires/mes-questionnaires.component';
import { ModifierUnQuestionnaireComponent } from './_pages/modifier-un-questionnaire/modifier-un-questionnaire.component';
import { VoirUnQuestionnaireComponent } from './_pages/voir-un-questionnaire/voir-un-questionnaire.component';
import { EditQCMComponent } from './_pages/edit-qcm/edit-qcm.component';
import { VoirUnUtilisateurComponent } from './_pages/voir-un-utilisateur/voir-un-utilisateur.component';
import { ProfilUtilisateurComponent } from './_pages/profil-utilisateur/profil-utilisateur.component';
import { ModifierProfilComponent } from './_pages/modifier-profil/modifier-profil.component';
import { NotfoundComponent } from './_pages/notfound/notfound.component';
import { ActualitesComponent } from './_pages/home-connecte/_sousComponents/actualites/actualites.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { UsersComponent } from './_pages/users/users.component';
import { UserComponent } from './_components/user/user.component';
import { HttpClientModule } from '@angular/common/http';
import { ConnexionComponent } from './_pages/connexion/connexion.component';


@NgModule({
  declarations: [
    AppComponent,
    FooterComponent,
    HeaderComponent,
    HomeComponent,
    InscriptionComponent,
    VoletConnectionComponent,
    MotDePasseOublieComponent,
    MotDePasseOublieDeuxiemePageComponent,
    InscriptionCandidatComponent,
    QuizCandidatComponent,
    ValidationQuizCandidatComponent,
    HomeConnecteComponent,
    CreationQuizComponent,
    CreationQuestionsQuizComponent,
    QuizCreeCodeComponent,
    MesQuestionnairesComponent,
    ModifierUnQuestionnaireComponent,
    VoirUnQuestionnaireComponent,
    EditQCMComponent,
    VoirUnUtilisateurComponent,
    ProfilUtilisateurComponent,
    ModifierProfilComponent,
    NotfoundComponent,
    ActualitesComponent,
    UsersComponent,
    UserComponent,
    ConnexionComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    MatBadgeModule,
    MatCardModule,
    MatCheckboxModule,
    MatCheckboxModule,
    MatButtonModule,
    MatInputModule,
    MatAutocompleteModule,
    MatDatepickerModule,
    MatFormFieldModule,
    MatRadioModule,
    MatSelectModule,
    MatSliderModule,
    MatSlideToggleModule,
    MatMenuModule,
    MatSidenavModule,
    MatToolbarModule,
    MatListModule,
    MatGridListModule,
    MatCardModule,
    MatStepperModule,
    MatTabsModule,
    MatExpansionModule,
    MatButtonToggleModule,
    MatChipsModule,
    MatIconModule,
    MatProgressSpinnerModule,
    MatProgressBarModule,
    MatDialogModule,
    MatTooltipModule,
    MatSnackBarModule,
    MatTableModule,
    MatSortModule,
    MatPaginatorModule,
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

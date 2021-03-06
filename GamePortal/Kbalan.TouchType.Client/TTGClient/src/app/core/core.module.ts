import { NotificationService } from './services/notification.service';
import { LoginService,  } from './services/login.service';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './components/login/login.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { OAuthModule } from 'angular-oauth2-oidc';
import { RegistrationComponent } from './components/registration/registration.component';
import { EntryMenuComponent } from './components/entrymenu/entrymenu.component';
import { AppModule } from '../app.module';
import { RouterModule } from '@angular/router';
import { oauthCodeConfig, PASSWORD_FLOW_CONFIG, CODE_FLOW_CONFIG, oauthPassConfig } from './configs/auth.config';
import { SgameComponent } from '../sgame/component/sgame/sgame.component';




@NgModule({
  declarations: [LoginComponent, NavbarComponent, NotFoundComponent, RegistrationComponent, EntryMenuComponent],
  imports: [
    RouterModule,
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    OAuthModule.forRoot()
  ],
  providers:
  [
    LoginService,
    NotificationService,
    { provide: CODE_FLOW_CONFIG, useValue: oauthCodeConfig },
    { provide: PASSWORD_FLOW_CONFIG, useValue: oauthPassConfig },
  ],
  exports: [LoginComponent, NavbarComponent, NotFoundComponent, OAuthModule, RegistrationComponent, EntryMenuComponent ]
})
export class CoreModule { }

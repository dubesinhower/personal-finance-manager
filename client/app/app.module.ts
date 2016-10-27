import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpModule }    from '@angular/http';
import { FormsModule } from '@angular/forms';

import { AppComponent }  from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { StoreModule } from '@ngrx/store';

import { CoreModule } from './core';
import { UserAccountRegistrationFormComponent, UserAccountService } from './user-accounts';
import { EmailAccountsComponent, EmailAccountCardComponent, EmailAccountListComponent,
    EmailAccountService, GmailOAuthService } from './email-accounts';
import { HomeComponent } from './home';
import { OAuthService, userTokenReducer } from './shared';
import { AuthorizeComponent } from './authorize';
import { AccountsComponent, AccountService, TransactionTableComponent } from './accounts';

@NgModule({
  imports: [
      BrowserModule,
      HttpModule,
      AppRoutingModule,
      CoreModule,
      FormsModule,
      StoreModule.provideStore({ userToken: userTokenReducer }) ],
  declarations: [
      UserAccountRegistrationFormComponent,
      HomeComponent,
      AppComponent,
      AccountsComponent,
      AuthorizeComponent,
      TransactionTableComponent,
      EmailAccountsComponent,
      EmailAccountCardComponent,
      EmailAccountListComponent ],
  providers: [
      OAuthService,
      AccountService,
      UserAccountService,
      EmailAccountService,
      GmailOAuthService ],
  bootstrap: [ AppComponent ]
})
export class AppModule { }
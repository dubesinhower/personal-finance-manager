import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';

import { AppComponent }  from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { StoreModule } from '@ngrx/store';

import { CoreModule } from './core';
import { UserAccountModule, UserAccountService } from './user-account';
import { SharedModule, userTokenReducer, emailAccountsReducer, selectedEmailAccountReducer, 
    googleOAuthSecurityTokenReducer } from './shared';
import { EmailAccountsModule } from './email-accounts';
import { HomeComponent } from './home';
import { AuthorizeComponent } from './authorize';
import { AccountsComponent, AccountService, TransactionTableComponent } from './accounts';

@NgModule({
    imports: [
        BrowserModule,
        HttpModule,
        FormsModule,
        AppRoutingModule,
        StoreModule.provideStore({
            userToken: userTokenReducer,
            emailAccounts: emailAccountsReducer,
            selectedEmailAccount: selectedEmailAccountReducer,
            googleOAuthSecurityToken: googleOAuthSecurityTokenReducer }),
        CoreModule,
        UserAccountModule,
        SharedModule,
        EmailAccountsModule ],
    declarations: [
        HomeComponent,
        AppComponent,
        AccountsComponent,
        AuthorizeComponent,
        TransactionTableComponent ],
    providers: [
        AccountService,
        UserAccountService ],
    bootstrap: [ AppComponent ]
})
export class AppModule { }

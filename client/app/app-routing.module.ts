import { NgModule }     from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { HomeComponent } from './home';
import { UserAccountRegistrationFormComponent } from './user-accounts';
import { EmailAccountsComponent } from './email-accounts';
import { AuthorizeComponent }  from './authorize';
import { AccountsComponent } from './accounts';

const routes: Routes = [
  { path: '', component: HomeComponent },  
  { path: 'account/register', component: UserAccountRegistrationFormComponent },
  { path: 'emailAccounts', component: EmailAccountsComponent },
  { path: 'authorize', component: AuthorizeComponent },
  { path: 'accounts', component: AccountsComponent }
]

@NgModule({
  imports: [ RouterModule.forRoot(routes) ],
  exports: [ RouterModule ]
})

export class AppRoutingModule {}
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { HomeComponent } from './home';
import { AuthorizeComponent }  from './authorize';
import { AccountsComponent } from './accounts';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'authorize', component: AuthorizeComponent },
  { path: 'accounts', component: AccountsComponent }
];

@NgModule({
  imports: [ RouterModule.forRoot(routes) ],
  exports: [ RouterModule ]
})

export class AppRoutingModule {}

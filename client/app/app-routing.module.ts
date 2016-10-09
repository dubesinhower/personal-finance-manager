import { NgModule }     from '@angular/core';
import { RouterModule } from '@angular/router';

import { AuthorizeComponent }  from './authorize';
import { AccountsComponent } from './accounts';

@NgModule({
  imports: [
    RouterModule.forRoot([
      { path: 'authorize', component: AuthorizeComponent },
      { path: 'accounts', component: AccountsComponent }
    ])
  ],
  exports: [
    RouterModule
  ]
})
export class AppRoutingModule {}
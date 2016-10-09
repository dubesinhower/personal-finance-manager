import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FileSelectDirective } from 'ng2-file-upload/ng2-file-upload';
import { HttpModule }    from '@angular/http';

import { AppComponent }  from './app.component';
import { AppRoutingModule } from './app-routing.module';

import { AuthorizeComponent } from './authorize';
import { OAuthService } from './shared';
import { AccountsComponent, AccountService, TransactionTableComponent } from './accounts';

@NgModule({
  imports: [ 
      BrowserModule, 
      HttpModule,
      AppRoutingModule ],
  declarations: [
      AppComponent, 
      AccountsComponent,
      AuthorizeComponent,
      FileSelectDirective,
      TransactionTableComponent ],
  providers: [
      AccountService,
      OAuthService ],
  bootstrap: [ AppComponent ]
})
export class AppModule {
  
}
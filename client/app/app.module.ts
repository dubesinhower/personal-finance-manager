import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FileSelectDirective } from 'ng2-file-upload/ng2-file-upload';
import { HttpModule }    from '@angular/http';

import { AppComponent }  from './app.component';
import { AppRoutingModule } from './app-routing.module';

import { AccountsComponent, AccountService } from './accounts';
import { AuthorizeComponent } from './authorize';
import { OAuthService } from './shared';

@NgModule({
  imports: [ 
      BrowserModule, 
      HttpModule,
      AppRoutingModule ],
  declarations: [ 
      AppComponent, 
      AccountsComponent,
      AuthorizeComponent,
      FileSelectDirective ],
  providers: [
      AccountService,
      OAuthService ],
  bootstrap: [ AppComponent ]
})
export class AppModule {
  
}
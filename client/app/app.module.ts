import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FileSelectDirective } from 'ng2-file-upload/ng2-file-upload';
import { HttpModule }    from '@angular/http';

import { AppComponent }  from './app.component';
import { AccountsComponent } from './accounts';
import { AccountService } from './accounts/shared';

@NgModule({
  imports: [ 
    BrowserModule, 
    HttpModule ],
  declarations: [ 
    AppComponent, 
    AccountsComponent, 
    FileSelectDirective ],
  providers: [
      AccountService
    ],
  bootstrap: [ AppComponent ]
})
export class AppModule {
  
}
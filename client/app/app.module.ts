import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FileSelectDirective } from 'ng2-file-upload/ng2-file-upload';
import { HttpModule }    from '@angular/http';

import { AppComponent }  from './app.component';
import { AccountsComponent, AccountService, TransactionTableComponent } from './accounts';

@NgModule({
  imports: [ 
    BrowserModule, 
    HttpModule ],
  declarations: [ 
    AppComponent, 
    AccountsComponent, 
    TransactionTableComponent,
    FileSelectDirective ],
  providers: [
      AccountService
    ],
  bootstrap: [ AppComponent ]
})
export class AppModule {
  
}
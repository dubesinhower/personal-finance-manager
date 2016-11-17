import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { UserAccountRegistrationComponent } from './user-account-registration';
import { UserAccountRoutingModule } from './user-account-routing.module';

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        UserAccountRoutingModule ],
    declarations: [ UserAccountRegistrationComponent ],
    exports: [ UserAccountRegistrationComponent ]
})
export class UserAccountModule { }

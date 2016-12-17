import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { UserAccountRegistrationComponent }    from './user-account-registration';

@NgModule({
    imports: [
        RouterModule.forChild([
            { path: 'userAccount/registration',  component: UserAccountRegistrationComponent }
        ])
    ],
    exports: [
        RouterModule
    ]
})
export class UserAccountRoutingModule { }

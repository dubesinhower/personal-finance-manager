import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { EmailAccountsComponent }    from '../email-accounts';

@NgModule({
    imports: [
        RouterModule.forChild([
            { path: 'emailAccounts',  component: EmailAccountsComponent }
        ])
    ],
    exports: [
        RouterModule
    ]
})
export class EmailAccountsRoutingModule { }

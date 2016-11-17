import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { EmailAccountListComponent } from './email-account-list';
import { ImapSettingsFormComponent } from './imap-settings-form';
import { EmailAccountService, GmailAccountService, ImapService } from './shared';
import { EmailAccountsComponent } from './email-accounts.component';
import { EmailAccountsRoutingModule } from './email-accounts-routing.module';

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        EmailAccountsRoutingModule ],
    declarations: [ EmailAccountListComponent, ImapSettingsFormComponent, EmailAccountsComponent ],
    exports: [ EmailAccountListComponent, ImapSettingsFormComponent ],
    providers: [ EmailAccountService, GmailAccountService, ImapService ]
})
export class EmailAccountsModule { }

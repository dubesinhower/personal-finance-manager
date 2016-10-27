import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs/Rx';

import { AppStore } from '../shared';
import { EmailAccount, EmailAccountService,  GmailOAuthService } from '../email-accounts';

@Component ({
    selector: 'pfm-email-accounts',
    templateUrl: 'app/email-accounts/email-accounts.component.html'
})
export class EmailAccountsComponent implements OnInit {
    private _emailAccounts$: Observable<EmailAccount>;

    constructor(
        private _store: Store<AppStore>,
        private _emailAccountService: EmailAccountService,
        private _gmailOAuthService: GmailOAuthService) { }

    ngOnInit() {
        this._emailAccounts$ = this._emailAccountService.getEmailAccounts();
    }

    authorizeGmail(accountId: number) {
        console.log(accountId);
        this._gmailOAuthService.initServerFlow('');
    }
}

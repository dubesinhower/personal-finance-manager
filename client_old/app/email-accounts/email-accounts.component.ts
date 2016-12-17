import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs/Rx';

import { AppStore } from '../shared';
import { EmailAccount, ImapSettings, EmailAccountService, ImapService, GmailAccountService } from '../email-accounts';

@Component ({
    selector: 'pfm-email-accounts',
    templateUrl: 'app/email-accounts/email-accounts.component.html'
})
export class EmailAccountsComponent implements OnInit {
    private selectedEmailAccount$: Observable<number>;
    private emailAccounts$: Observable<EmailAccount>;

    constructor(
        private _store: Store<AppStore>,
        private _emailAccountService: EmailAccountService,
        private _imapService: ImapService,
        private _gmailAccountService: GmailAccountService) { }

    ngOnInit() {
        this.emailAccounts$ = this._store.select<EmailAccount>('emailAccounts');
        this.selectedEmailAccount$ = this._store.select<number>('selectedEmailAccount');
        this._emailAccountService.loadEmailAccounts();
    }

    addImapSettings(settings: ImapSettings) {
        this._imapService.addSettings(settings)
            .map(response => response.json())
            .subscribe(
                response => console.log(response),
                error => {
                    console.log('settings not added');
                    console.log(error);
                }
            );
    }

    addGmailAccount(accountId: number) {
        this._gmailAccountService.initServerFlow('action=add');
    }

    selectEmailAccount(accountId: number) {
        this._store.dispatch({ type: 'SELECT_EMAIL_ACCOUNT', payload: accountId });
    }

    deleteEmailAccount(accountId: number) {
        this._emailAccountService
            .deleteAccount(accountId)
            .subscribe(
                response => {
                    console.log(response);
                    this._store.dispatch({ type: 'DELETE_EMAIL_ACCOUNT', payload: response });
                },
                error => {
                    console.log('delete error');
                    console.log('error');
                }
            );
    }
}

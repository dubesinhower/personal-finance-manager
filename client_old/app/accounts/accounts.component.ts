import { Component, OnInit } from '@angular/core';
import { Account, Transaction, AccountService } from './shared';
import { TransactionTableComponent } from './transaction-table';

@Component ({
    selector: 'pfm-accounts',
    templateUrl: 'app/accounts/accounts.component.html'
})
export class AccountsComponent implements OnInit {
    account: Account = new Account;

    constructor(private _accountService: AccountService) {

    }

    ngOnInit() {
        this._accountService.getAccount(1).then(account => this.account = account);
    }
}
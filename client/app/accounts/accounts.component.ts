import { Component, OnInit } from '@angular/core';
import { Account, Transaction, AccountService } from './shared';

@Component ({
    selector: 'pfm-accounts',
    templateUrl: 'app/accounts/accounts.component.html'
})
export class AccountsComponent implements OnInit {
    accounts: Account[];

    constructor(private _accountService: AccountService) {

    }

    ngOnInit() {
    }
}
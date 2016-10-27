import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';

import { AppStore } from '../../shared';
import { Login, UserAccountService, Token } from '../../user-accounts';
import { Observable } from 'rxjs/Rx';

@Component ({
    selector: 'pfm-nav',
    templateUrl: 'app/core/nav/nav.component.html'
})
export class NavComponent implements OnInit{
    private _userToken$: Observable<Token>;
    private _loginModel = new Login();

    constructor(
        private _userAccountService: UserAccountService,
        private _store: Store<AppStore>) { }

    ngOnInit() {
        this._userToken$ = this._store.select<Token>('userToken');
    }

    onLogin() {
        this._userAccountService.login(this._loginModel);
    }

    onLogout() {
        this._userAccountService.logout();
    }
}
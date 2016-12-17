import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';

import { Observable } from 'rxjs/Rx';

import { AppStore } from './shared';
import { UserAccountService, Token } from './user-account';

@Component({
    selector: 'pfm-app',
    templateUrl: 'app/app.component.html',
    styleUrls: ['app/app.component.css']
})
export class AppComponent implements OnInit {
    userToken$: Observable<Token>;

    constructor(private _userAccountService: UserAccountService) { }

    ngOnInit() {
        this._userAccountService.load();
    }
}

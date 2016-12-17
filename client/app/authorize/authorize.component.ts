import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Http } from '@angular/http';
import { Store } from '@ngrx/store';

import { AppStore } from '../shared';
import { GmailAccountService } from '../email-accounts';

@Component ({
    selector: 'pfm-authorize',
    templateUrl: 'app/authorize/authorize.component.html'
})
export class AuthorizeComponent implements OnInit {
    authorizationMessages: string[] = [];

    constructor(
        private _router: Router,
        private _http: Http,
        private _store: Store<AppStore>,
        private _gmailAccountService: GmailAccountService) { }

    ngOnInit() {
        let queryString = window.location.search;
        if (queryString === undefined) {
            this.authorizationMessages.push('Error, no queryString!');
            return;
        }
        // console.log(queryString);
        let state = `?${this.getParameterByName('state', queryString)}`;
        // console.log(`state: ${state}`); 
        let storedSecurityToken = sessionStorage.getItem('googleOAuthSecurityToken');
        // console.log(`storedToken: ${storedSecurityToken}`);
        let urlSecurityToken = this.getParameterByName('security_token', state);
        // console.log(`urlToken: ${urlSecurityToken}`);

        if (storedSecurityToken !== urlSecurityToken) {
            this.authorizationMessages.push('Error, security_token doesnt match!');
            return;
        }

        let code = this.getParameterByName('code', queryString);
        // console.log(code);
        let action = this.getParameterByName('action', state);
        switch (action) {
            case('add'):
                break;
            case('update'):
                break;
            default:
                this.authorizationMessages.push('Error!'); 
                return;
        }
        if(this._gmailAccountService.addAccount(code)) {
            this._router.navigate(['/emailAccounts']);
        }            
    }

    getParameterByName(name: string, url: string) {
        if (!url) {
        url = window.location.href;
        }
        name = name.replace(/[\[\]]/g, '\\$&');
        let regex = new RegExp('[?&]' + name + '(=([^&#]*)|&|#|$)'),
            results = regex.exec(url);
        if (!results) { return null; };
        if (!results[2]) { return ''; };
        return decodeURIComponent(results[2]);
    }
}

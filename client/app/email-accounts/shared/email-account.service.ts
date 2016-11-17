import { Injectable, OnInit }    from '@angular/core';
import { Http, Headers, RequestOptions } from '@angular/http';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs/Rx';

import { EmailAccount, ImapAccount } from '../shared';
import { AppStore } from '../../shared';

@Injectable()
export class EmailAccountService implements OnInit {
    private _secureBaseUrl = 'https://localhost:44337';

    constructor(
        private _http: Http,
        private _store: Store<AppStore>) { }

    ngOnInit() {
        this.getEmailAccounts();
    }

    loadEmailAccounts() {
        this.getEmailAccounts()
            .subscribe(
                emailAccounts => {
                    this._store.dispatch({ type: 'LOAD_EMAIL_ACCOUNTS', payload: emailAccounts });
                },
                error => console.log(error));
    }

    deleteAccount(id: number) {
        let token = JSON.parse(localStorage.getItem('userAccountToken'));
        let headers = new Headers({ 'Authorization': `Bearer ${token.access_token}` });
        let options = new RequestOptions({ headers: headers });
        return this._http
            .delete(`${this._secureBaseUrl}/api/emailAccounts/${id}`, options)
            .map(response => response.json() as EmailAccount);
    }

    private getEmailAccounts(): Observable<EmailAccount> {
        let token = JSON.parse(localStorage.getItem('userAccountToken'));
        let headers = new Headers({ 'Authorization': `Bearer ${token.access_token}` });
        let options = new RequestOptions({ headers: headers });
        return this._http
            .get(`${this._secureBaseUrl}/api/emailAccounts`, options)
            .map(response => response.json() as ImapAccount);
    }
}

import { Injectable, OnInit }    from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs/Rx';

import { AppStore } from '../../shared';
import { Registration, Login, Token } from '../shared';

@Injectable()
export class UserAccountService {
    private _secureBaseUrl = 'https://localhost:44337';

    constructor(
        private _http: Http,
        private _store: Store<AppStore>) { }

    login(model: Login) {
        this.getNewTokenFromServer(model)
            .subscribe(
                token => {
                    this._store.dispatch({ type: 'SET_USER_TOKEN', payload: token });
                    this.saveTokenToLocalStorage(token);
                    console.log(token);
                },
                error => console.log(error));
    }

    logout() {
        this._store.dispatch({ type: 'CLEAR_USER_TOKEN' });
        this.removeTokenFromLocalStorage();
    }

    loadExistingToken() {
        let token = this.retrieveTokenFromLocalStorage();
        this._store.dispatch({ type: 'SET_USER_TOKEN', payload: token });
    }

    private getNewTokenFromServer(model: Login) {
        let body = `grant_type=password&username=${model.username}&password=${model.password}`;
        let headers = new Headers({ 'Content-Type': 'application/x-www-form-urlencoded' });
        let options = new RequestOptions({ headers: headers });
        return this._http
            .post(`${this._secureBaseUrl}/token`, body, options)
            .map(response => response.json());
    }

    private saveTokenToLocalStorage(token: Token) {
        localStorage.setItem('userAccountToken', JSON.stringify(token));
    }

    private removeTokenFromLocalStorage() {
        localStorage.removeItem('userAccountToken');
    }

    private retrieveTokenFromLocalStorage(): Token {
        let token = localStorage.getItem('userAccountToken');
        return JSON.parse(token);
    }
}

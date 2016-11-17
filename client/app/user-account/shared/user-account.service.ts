import { Injectable }    from '@angular/core';
import { Http, Headers, RequestOptions } from '@angular/http';
import { Store } from '@ngrx/store';
import 'rxjs/add/operator/map';

import { AppStore, Login } from '../../shared';
import { Token } from '../shared';

@Injectable()
export class UserAccountService {
    private _secureBaseUrl = 'https://localhost:44337';

    constructor(
        private _http: Http,
        private _store: Store<AppStore>) { }

    load() {
        let token = this.getStoredToken();
        this._store.dispatch({ type: 'SET_USER_TOKEN', payload: token });
    }

    login(loginModel: Login) {
        console.log(loginModel);
        this.getToken(loginModel)
            .subscribe(
                token => {
                    this._store.dispatch({ type: 'SET_USER_TOKEN', payload: token });
                    this.storeToken(token);
                },
                error => console.log(error));
    }

    logout() {
        this._store.dispatch({ type: 'CLEAR_USER_TOKEN' });
        this.clearStoredToken();
    }

    private getToken(loginModel: Login) {
        let body = `grant_type=password&username=${loginModel.username}&password=${loginModel.password}`;
        let headers = new Headers({ 'Content-Type': 'application/x-www-form-urlencoded' });
        let options = new RequestOptions({ headers: headers });
        return this._http
            .post(`${this._secureBaseUrl}/token`, body, options)
            .map(response => response.json());
    }

    private storeToken(token: Token) {
        localStorage.setItem('userAccountToken', JSON.stringify(token));
    }

    private clearStoredToken() {
        localStorage.removeItem('userAccountToken');
    }

    private getStoredToken(): Token {
        let token = localStorage.getItem('userAccountToken');
        return JSON.parse(token);
    }
}

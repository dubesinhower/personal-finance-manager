import { Injectable }    from '@angular/core';
import { Http, Headers } from '@angular/http';

import 'rxjs/add/operator/toPromise';

import { Account } from './account.model';

@Injectable()
export class AccountService {
    private accountsUrl = "http://localhost:51775/api/accounts";

    constructor(private _http: Http) { }

    getAccounts(): Promise<Account[]> {
    return this._http.get(this.accountsUrl)
               .toPromise()
               .then(response => response.json() as Account[])
               .catch(this.handleError);
    }

    getAccount(id: number): Promise<Account> {
    return this._http.get(`${this.accountsUrl}/${id}`)
               .toPromise()
               .then(response => response.json()  as Account)
               .catch(this.handleError);
    }

    private handleError(error: any): Promise<any> {
        console.error('An error occurred', error); // for demo purposes only
        return Promise.reject(error.message || error);
    }
}
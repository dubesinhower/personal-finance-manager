import { Injectable }    from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';

import { AppStore, AuthorizationUrl } from '../../shared';

// https://github.com/manfredsteyer/angular2-oauth2/blob/master/oauth-service.ts#L61
@Injectable()
export class GmailOAuthService {
    public scopes =  [
        'https://www.googleapis.com/auth/userinfo.email',
        'https://www.googleapis.com/auth/userinfo.profile',
        'https://www.googleapis.com/auth/gmail.readonly'
    ];
    public redirectUri = 'http://localhost:3000/authorize';
    public clientId = '371588315131-giv2qovr6bspahdcnbv0f8d8magm6e9o.apps.googleusercontent.com';
    public authUri = 'https://accounts.google.com/o/oauth2/auth';

    private _secureBaseUrl = 'https://localhost:44337';

    constructor(
        private _http: Http,
        private _store: Store<AppStore>) { }

    initServerFlow(state = '') {
        this.createLoginUrl(state)
            .then(url => location.href = url)
            .catch(error => {
                console.error('Error in initServerFlow');
                console.error(error);
            });
    }

    private createLoginUrl(state: string): Promise<string> {
        if (typeof state === 'undefined') {
            state = '';
        };

        return this.getAndStoreAntiForgeryToken()
            .then(token => {
                if (state) {
                    state = `security_token=${token}&${state}`;
                } else {
                    state = `security_token=${token}`;
                }

                let params = [
                    `scope=${this.scopes.join('%20')}`,
                    `redirect_uri=${this.redirectUri}`,
                    `response_type=code`,
                    `state=${encodeURIComponent(state)}`,
                    `client_id=${this.clientId}`,
                    `access_type=offline`,
                    `approval_prompt=force`
                ];
                let url = `${this.authUri}?${params.join('&')}`;
                return url;
            });
     }

    private getAndStoreAntiForgeryToken(): Promise<string> {
        return this.getAntiForgeryToken()
            .then(token => {
                sessionStorage.setItem('gmailOAuthAntiForgeryToken', token);
                return token;
            });
    }

    private getAntiForgeryToken(): Promise<string> {
        let token = JSON.parse(localStorage.getItem('userAccountToken'));
        let headers = new Headers({ 'Authorization': `Bearer ${token.access_token}` });
        let options = new RequestOptions({ headers: headers });
        return this._http
            .get(`${this._secureBaseUrl}/api/gmailOAuth/antiForgeryToken`, options)
            .toPromise()
            .then(this.extractData)
            .catch(this.handleError);
    }

    private getAuthorizationUrl(): Observable<AuthorizationUrl>  {
        let token = JSON.parse(localStorage.getItem('userAccountToken'));
        let headers = new Headers({ 'Authorization': `Bearer ${token.access_token}` });
        let options = new RequestOptions({ headers: headers });
        return this._http
            .get(`${this._secureBaseUrl}/api/gmailOAuth/authorizationUrl`, options)
            .map(response => response.json() as AuthorizationUrl);
    }

    private extractData(res: Response) {
        return res.json();
    }
    private handleError (error: Response | any) {
    // In a real world app, we might use a remote logging infrastructure
    let errMsg: string;
    if (error instanceof Response) {
        const body = error.json() || '';
        const err = body.error || JSON.stringify(body);
        errMsg = `${error.status} - ${error.statusText || ''} ${err}`;
    } else {
        errMsg = error.message ? error.message : error.toString();
    }
    console.error(errMsg);
    return Promise.reject(errMsg);
    }
}

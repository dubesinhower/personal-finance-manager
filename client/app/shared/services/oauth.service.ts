import { Injectable } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Rx';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

import { AuthorizationUrl } from '../../shared';

@Injectable()
export class OAuthService {
    private clientSecretsLocation: string = './client_secret.json';
    private scopes: string[] = [
        'https://www.googleapis.com/auth/userinfo.email',
        'https://www.googleapis.com/auth/userinfo.profile',
        'https://www.googleapis.com/auth/gmail.readonly'
    ]
    private oAuthApiUrl = "http://localhost:52572/api/googleoauth";

    constructor(private http: Http) { }

    getAuthorizationUrl(): Observable<AuthorizationUrl> {
        return this.http.get(`${this.oAuthApiUrl}/authorizationUrl`)
                        .map(res => res.json())
                        .catch(this.handleError);
    }

    postAuthorizationCode(authCode: string): Observable<any> {
        let body = JSON.stringify(authCode);
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });
        return this.http
            .post(`${this.oAuthApiUrl}/authorizationCode`, body, options);
    }

    private extractData(res: Response) {
        let body = res.json();
        return body || { };
    }

    private handleError (error: any) {
        // In a real world app, we might use a remote logging infrastructure
        // We'd also dig deeper into the error to get a better message
        let errMsg = (error.message) ? error.message :
        error.status ? `${error.status} - ${error.statusText}` : 'Server error';
        console.error(errMsg); // log to console instead
        return Observable.throw(errMsg);
  }
}
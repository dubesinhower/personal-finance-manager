import { Injectable } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Rx';
import 'rxjs/add/operator/map';

@Injectable()
export class OAuthService {
    authorizationUrl: Observable<string>;
    private clientSecretsLocation: string = './client_secret.json';
    private scopes: string[] = [
        'https://www.googleapis.com/auth/userinfo.email',
        'https://www.googleapis.com/auth/userinfo.profile',
        'https://www.googleapis.com/auth/gmail.readonly'
    ]
    private oAuthUrl = "http://localhost:51775/api/oauth";

    constructor(private http: Http) { 
        this.buildAuthorizationUrl();
    }

    buildAuthorizationUrl() {
        // TODO: move to server
        this.authorizationUrl = this.http
            .request(this.clientSecretsLocation)
            .map(res => res.json().web)
            .map(clientSecrets => {
                return `${clientSecrets.auth_uri}?scope=${this.scopes.join('%20')}&redirect_uri=${clientSecrets.redirect_uris[0]}&response_type=code&client_id=${clientSecrets.client_id}&access_type=offline`;
            });        
    }

    sendAuthCodeToServer(authCode: string) {
        let body = JSON.stringify(authCode);
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });
        this.http
            .post(`${this.oAuthUrl}/authorization`, body, options)
            .map(res => res.json())
            .subscribe(
                res => console.log(res),
                error => this.handleError);
    }

    private extractData(res: Response) {
        let body = res.json();
        return body.data || { };
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
import { Injectable }    from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Rx';
import 'rxjs/add/operator/map';

@Injectable()
export class OAuthService {
    authorizationUrl: Observable<string>;
    private clientSecretsLocation: string = './client_id.json';
    private scopes: string[] = [
        'https://www.googleapis.com/auth/userinfo.email',
        'https://www.googleapis.com/auth/userinfo.profile',
        'https://www.googleapis.com/auth/gmail.readonly'
    ]

    constructor(private http: Http) { 
        this.authorizationUrl = this.http
            .request(this.clientSecretsLocation)
            .map(res => res.json().web)
            .map(clientSecrets => {
                return `${clientSecrets.auth_uri}?scope=${this.scopes.join('%20')}&redirect_uri=${clientSecrets.redirect_uris[0]}&response_type=token&client_id=${clientSecrets.client_id}`;
            });
    }

    init() {
        
    }

    requestAccessToken(queryString: string) {
        
    }

    parseQueryString() {
        let queryParams = {}, queryString = location.hash.substring(1);
        let params = queryString.split('&');
        for(let param of params) {
            console.log(decodeURIComponent(param));
        }
        /*for (let m of regex.exec(queryString)) {
            console.log(m);
            queryParams[decodeURIComponent(m[1])] = decodeURIComponent(m[2]);
        }
        return queryParams;*/
    }
}
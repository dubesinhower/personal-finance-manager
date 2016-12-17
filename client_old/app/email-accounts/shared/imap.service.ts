import { Injectable } from '@angular/core';
import { Http, Headers, RequestOptions } from '@angular/http';

import { Socket, ImapSettings } from '../shared';

@Injectable()
export class ImapService {
    private secureBaseUrl = 'https://localhost:44337';

    constructor(
        private _http: Http) { }

    addSettings(settings: ImapSettings) {
        let body = JSON.stringify(settings);
        let token = JSON.parse(localStorage.getItem('userAccountToken'));
        let headers = new Headers({
            'Authorization': `Bearer ${token.access_token}`,
            'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });
        return this._http
            .post(`${this.secureBaseUrl}/api/imapSettings`, body, options);
    }
}

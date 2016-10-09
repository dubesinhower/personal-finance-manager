import { Component, OnInit } from '@angular/core';

import { OAuthService } from '../shared';

@Component ({
    selector: 'pfm-authorize',
    templateUrl: 'app/authorize/authorize.component.html'
})
export class AuthorizeComponent implements OnInit{
    authorizationMessage: string;

    constructor(private oAuthService: OAuthService) { }

    ngOnInit() {
        let queryString = location.hash.substring(1);
        this.authorizationMessage = 'Authorizing your Gmail account...';
        this.oAuthService.requestAccessToken(queryString);
    }    
}
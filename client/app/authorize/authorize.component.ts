import { Component, OnInit } from '@angular/core';

import { OAuthService } from '../shared';

@Component ({
    selector: 'pfm-authorize',
    templateUrl: 'app/authorize/authorize.component.html'
})
export class AuthorizeComponent implements OnInit{
    authorizationMessages: string[];

    constructor(private oAuthService: OAuthService) { }

    ngOnInit() {
        this.oAuthService.sendAuthCodeToServer(this.getParameterByName('code'));
    }

    getParameterByName(name: string) {
        let match = new RegExp('[?&]' + name + '=([^&]*)').exec(window.location.search);
        return match && decodeURIComponent(match[1].replace(/\+/g, ' '));
    }
}
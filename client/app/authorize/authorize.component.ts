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
        this.oAuthService
            .postAuthorizationCode(this.getParameterByName('code'))
            .subscribe(res => {
                if(res.status == 400) {
                    console.log("error")
                }
                else if(res.status == 200) {
                    console.log("success");
                }
        });
    }

    getParameterByName(name: string) {
        let match = new RegExp('[?&]' + name + '=([^&]*)').exec(window.location.search);
        return match && decodeURIComponent(match[1].replace(/\+/g, ' '));
    }
}
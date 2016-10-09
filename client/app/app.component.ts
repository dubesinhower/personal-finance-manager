import { Component, OnInit } from '@angular/core';

import { OAuthService } from './shared';

@Component({
    selector: 'pfm-app',
    templateUrl: 'app/app.component.html',
    styleUrls: ['app/app.component.css']
})
export class AppComponent implements OnInit {
    authorizationUrl: string = '';
    authorized: boolean = false;

    constructor(private oAuthService: OAuthService) {  }

    ngOnInit() {
        this.oAuthService
            .authorizationUrl
            .subscribe(url => this.authorizationUrl = url);
    }
}
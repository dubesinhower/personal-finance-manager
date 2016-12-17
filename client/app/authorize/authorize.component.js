"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var core_1 = require("@angular/core");
var router_1 = require("@angular/router");
var http_1 = require("@angular/http");
var store_1 = require("@ngrx/store");
var email_accounts_1 = require("../email-accounts");
var AuthorizeComponent = (function () {
    function AuthorizeComponent(_router, _http, _store, _gmailAccountService) {
        this._router = _router;
        this._http = _http;
        this._store = _store;
        this._gmailAccountService = _gmailAccountService;
        this.authorizationMessages = [];
    }
    AuthorizeComponent.prototype.ngOnInit = function () {
        var queryString = window.location.search;
        if (queryString === undefined) {
            this.authorizationMessages.push('Error, no queryString!');
            return;
        }
        // console.log(queryString);
        var state = "?" + this.getParameterByName('state', queryString);
        // console.log(`state: ${state}`); 
        var storedSecurityToken = sessionStorage.getItem('googleOAuthSecurityToken');
        // console.log(`storedToken: ${storedSecurityToken}`);
        var urlSecurityToken = this.getParameterByName('security_token', state);
        // console.log(`urlToken: ${urlSecurityToken}`);
        if (storedSecurityToken !== urlSecurityToken) {
            this.authorizationMessages.push('Error, security_token doesnt match!');
            return;
        }
        var code = this.getParameterByName('code', queryString);
        // console.log(code);
        var action = this.getParameterByName('action', state);
        switch (action) {
            case ('add'):
                break;
            case ('update'):
                break;
            default:
                this.authorizationMessages.push('Error!');
                return;
        }
        if (this._gmailAccountService.addAccount(code)) {
            this._router.navigate(['/emailAccounts']);
        }
    };
    AuthorizeComponent.prototype.getParameterByName = function (name, url) {
        if (!url) {
            url = window.location.href;
        }
        name = name.replace(/[\[\]]/g, '\\$&');
        var regex = new RegExp('[?&]' + name + '(=([^&#]*)|&|#|$)'), results = regex.exec(url);
        if (!results) {
            return null;
        }
        ;
        if (!results[2]) {
            return '';
        }
        ;
        return decodeURIComponent(results[2]);
    };
    return AuthorizeComponent;
}());
AuthorizeComponent = __decorate([
    core_1.Component({
        selector: 'pfm-authorize',
        templateUrl: 'app/authorize/authorize.component.html'
    }),
    __metadata("design:paramtypes", [router_1.Router,
        http_1.Http,
        store_1.Store,
        email_accounts_1.GmailAccountService])
], AuthorizeComponent);
exports.AuthorizeComponent = AuthorizeComponent;
//# sourceMappingURL=authorize.component.js.map
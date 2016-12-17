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
var http_1 = require("@angular/http");
var store_1 = require("@ngrx/store");
// https://github.com/manfredsteyer/angular2-oauth2/blob/master/oauth-service.ts#L61
var GmailAccountService = (function () {
    function GmailAccountService(_http, _store) {
        this._http = _http;
        this._store = _store;
        this.scopes = [
            'https://www.googleapis.com/auth/userinfo.email',
            'https://www.googleapis.com/auth/gmail.readonly'
        ];
        this.redirectUri = 'http://localhost:3000/authorize';
        this.clientId = '371588315131-giv2qovr6bspahdcnbv0f8d8magm6e9o.apps.googleusercontent.com';
        this.authUri = 'https://accounts.google.com/o/oauth2/auth';
        this._secureBaseUrl = 'https://localhost:44337';
    }
    GmailAccountService.prototype.initServerFlow = function (state) {
        if (state === void 0) { state = ''; }
        this.createLoginUrl(state)
            .then(function (loginUrl) { return window.location.href = loginUrl; })
            .catch(function (error) {
            console.error('Error in initServerFlow');
            console.error(error);
        });
    };
    GmailAccountService.prototype.addAccount = function (authCode) {
        var _this = this;
        var body = JSON.stringify(authCode);
        var token = JSON.parse(localStorage.getItem('userAccountToken'));
        var headers = new http_1.Headers({
            'Authorization': "Bearer " + token.access_token,
            'Content-Type': 'application/json'
        });
        var options = new http_1.RequestOptions({ headers: headers });
        return this._http.post(this._secureBaseUrl + "/api/gmailAccounts", body, options)
            .map(function (response) { return response.json(); })
            .subscribe(function (emailAccount) {
            _this._store.dispatch({ type: 'ADD_EMAIL_ACCOUNT', payload: emailAccount });
            return true;
        }, function (error) {
            console.log(error);
            return false;
        });
    };
    GmailAccountService.prototype.createLoginUrl = function (state) {
        var _this = this;
        if (typeof state === 'undefined') {
            state = '';
        }
        ;
        return this.getAndStoreAntiForgeryToken()
            .then(function (token) {
            sessionStorage.setItem('googleOAuthSecurityToken', token);
            if (state) {
                state = "security_token=" + token + "&" + state;
            }
            else {
                state = "security_token=" + token;
            }
            var params = [
                "scope=" + _this.scopes.join('%20'),
                "redirect_uri=" + _this.redirectUri,
                "response_type=code",
                "state=" + encodeURIComponent(state),
                "client_id=" + _this.clientId,
                "access_type=offline",
                "prompt=" + encodeURIComponent('select_account consent')
            ];
            var url = _this.authUri + "?" + params.join('&');
            return url;
        });
    };
    GmailAccountService.prototype.getAntiForgeryToken = function () {
        var token = JSON.parse(localStorage.getItem('userAccountToken'));
        var headers = new http_1.Headers({ 'Authorization': "Bearer " + token.access_token });
        var options = new http_1.RequestOptions({ headers: headers });
        return this._http
            .get(this._secureBaseUrl + "/api/gmailAccounts/antiForgeryToken", options)
            .toPromise()
            .then(this.extractData)
            .catch(this.handleError);
    };
    GmailAccountService.prototype.getAndStoreAntiForgeryToken = function () {
        return this.getAntiForgeryToken()
            .then(function (token) {
            sessionStorage.setItem('gmailAccountAntiForgeryToken', token);
            return token;
        });
    };
    GmailAccountService.prototype.extractData = function (res) {
        return res.json();
    };
    GmailAccountService.prototype.handleError = function (error) {
        // In a real world app, we might use a remote logging infrastructure
        var errMsg;
        if (error instanceof http_1.Response) {
            var body = error.json() || '';
            var err = body.error || JSON.stringify(body);
            errMsg = error.status + " - " + (error.statusText || '') + " " + err;
        }
        else {
            errMsg = error.message ? error.message : error.toString();
        }
        console.error(errMsg);
        return Promise.reject(errMsg);
    };
    GmailAccountService.prototype.openPopupWindow = function (url) {
        var newwindow = window.open(url, '', 'height=600,width=800');
        if (window.focus) {
            newwindow.focus();
        }
    };
    return GmailAccountService;
}());
GmailAccountService = __decorate([
    core_1.Injectable(),
    __metadata("design:paramtypes", [http_1.Http,
        store_1.Store])
], GmailAccountService);
exports.GmailAccountService = GmailAccountService;
//# sourceMappingURL=gmail-account.service.js.map
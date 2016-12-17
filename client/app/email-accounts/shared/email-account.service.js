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
var EmailAccountService = (function () {
    function EmailAccountService(_http, _store) {
        this._http = _http;
        this._store = _store;
        this._secureBaseUrl = 'https://localhost:44337';
    }
    EmailAccountService.prototype.ngOnInit = function () {
        this.getEmailAccounts();
    };
    EmailAccountService.prototype.loadEmailAccounts = function () {
        var _this = this;
        this.getEmailAccounts()
            .subscribe(function (emailAccounts) {
            _this._store.dispatch({ type: 'LOAD_EMAIL_ACCOUNTS', payload: emailAccounts });
        }, function (error) { return console.log(error); });
    };
    EmailAccountService.prototype.deleteAccount = function (id) {
        var token = JSON.parse(localStorage.getItem('userAccountToken'));
        var headers = new http_1.Headers({ 'Authorization': "Bearer " + token.access_token });
        var options = new http_1.RequestOptions({ headers: headers });
        return this._http
            .delete(this._secureBaseUrl + "/api/emailAccounts/" + id, options)
            .map(function (response) { return response.json(); });
    };
    EmailAccountService.prototype.getEmailAccounts = function () {
        var token = JSON.parse(localStorage.getItem('userAccountToken'));
        var headers = new http_1.Headers({ 'Authorization': "Bearer " + token.access_token });
        var options = new http_1.RequestOptions({ headers: headers });
        return this._http
            .get(this._secureBaseUrl + "/api/emailAccounts", options)
            .map(function (response) { return response.json(); });
    };
    return EmailAccountService;
}());
EmailAccountService = __decorate([
    core_1.Injectable(),
    __metadata("design:paramtypes", [http_1.Http,
        store_1.Store])
], EmailAccountService);
exports.EmailAccountService = EmailAccountService;
//# sourceMappingURL=email-account.service.js.map
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
require("rxjs/add/operator/map");
var UserAccountService = (function () {
    function UserAccountService(_http, _store) {
        this._http = _http;
        this._store = _store;
        this._secureBaseUrl = 'https://localhost:44337';
    }
    UserAccountService.prototype.load = function () {
        var token = this.getStoredToken();
        this._store.dispatch({ type: 'SET_USER_TOKEN', payload: token });
    };
    UserAccountService.prototype.login = function (loginModel) {
        var _this = this;
        console.log(loginModel);
        this.getToken(loginModel)
            .subscribe(function (token) {
            _this._store.dispatch({ type: 'SET_USER_TOKEN', payload: token });
            _this.storeToken(token);
        }, function (error) { return console.log(error); });
    };
    UserAccountService.prototype.logout = function () {
        this._store.dispatch({ type: 'CLEAR_USER_TOKEN' });
        this.clearStoredToken();
    };
    UserAccountService.prototype.getToken = function (loginModel) {
        var body = "grant_type=password&username=" + loginModel.username + "&password=" + loginModel.password;
        var headers = new http_1.Headers({ 'Content-Type': 'application/x-www-form-urlencoded' });
        var options = new http_1.RequestOptions({ headers: headers });
        return this._http
            .post(this._secureBaseUrl + "/token", body, options)
            .map(function (response) { return response.json(); });
    };
    UserAccountService.prototype.storeToken = function (token) {
        localStorage.setItem('userAccountToken', JSON.stringify(token));
    };
    UserAccountService.prototype.clearStoredToken = function () {
        localStorage.removeItem('userAccountToken');
    };
    UserAccountService.prototype.getStoredToken = function () {
        var token = localStorage.getItem('userAccountToken');
        return JSON.parse(token);
    };
    return UserAccountService;
}());
UserAccountService = __decorate([
    core_1.Injectable(),
    __metadata("design:paramtypes", [http_1.Http,
        store_1.Store])
], UserAccountService);
exports.UserAccountService = UserAccountService;
//# sourceMappingURL=user-account.service.js.map
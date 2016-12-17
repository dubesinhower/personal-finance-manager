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
var store_1 = require("@ngrx/store");
var shared_1 = require("../../shared");
var user_account_1 = require("../../user-account");
var NavComponent = (function () {
    function NavComponent(_userAccountService, _store) {
        this._userAccountService = _userAccountService;
        this._store = _store;
        this.loginModel = new shared_1.Login('', null);
    }
    NavComponent.prototype.ngOnInit = function () {
        this._userToken$ = this._store.select('userToken');
    };
    NavComponent.prototype.onLogin = function () {
        this._userAccountService.login(this.loginModel);
    };
    NavComponent.prototype.onLogout = function () {
        this._userAccountService.logout();
    };
    return NavComponent;
}());
NavComponent = __decorate([
    core_1.Component({
        selector: 'pfm-nav',
        templateUrl: 'app/core/nav/nav.component.html'
    }),
    __metadata("design:paramtypes", [user_account_1.UserAccountService,
        store_1.Store])
], NavComponent);
exports.NavComponent = NavComponent;
//# sourceMappingURL=nav.component.js.map
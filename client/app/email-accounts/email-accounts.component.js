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
var email_accounts_1 = require("../email-accounts");
var EmailAccountsComponent = (function () {
    function EmailAccountsComponent(_store, _emailAccountService, _imapService, _gmailAccountService) {
        this._store = _store;
        this._emailAccountService = _emailAccountService;
        this._imapService = _imapService;
        this._gmailAccountService = _gmailAccountService;
    }
    EmailAccountsComponent.prototype.ngOnInit = function () {
        this.emailAccounts$ = this._store.select('emailAccounts');
        this.selectedEmailAccount$ = this._store.select('selectedEmailAccount');
        this._emailAccountService.loadEmailAccounts();
    };
    EmailAccountsComponent.prototype.addImapSettings = function (settings) {
        this._imapService.addSettings(settings)
            .map(function (response) { return response.json(); })
            .subscribe(function (response) { return console.log(response); }, function (error) {
            console.log('settings not added');
            console.log(error);
        });
    };
    EmailAccountsComponent.prototype.addGmailAccount = function (accountId) {
        this._gmailAccountService.initServerFlow('action=add');
    };
    EmailAccountsComponent.prototype.selectEmailAccount = function (accountId) {
        this._store.dispatch({ type: 'SELECT_EMAIL_ACCOUNT', payload: accountId });
    };
    EmailAccountsComponent.prototype.deleteEmailAccount = function (accountId) {
        var _this = this;
        this._emailAccountService
            .deleteAccount(accountId)
            .subscribe(function (response) {
            console.log(response);
            _this._store.dispatch({ type: 'DELETE_EMAIL_ACCOUNT', payload: response });
        }, function (error) {
            console.log('delete error');
            console.log('error');
        });
    };
    return EmailAccountsComponent;
}());
EmailAccountsComponent = __decorate([
    core_1.Component({
        selector: 'pfm-email-accounts',
        templateUrl: 'app/email-accounts/email-accounts.component.html'
    }),
    __metadata("design:paramtypes", [store_1.Store,
        email_accounts_1.EmailAccountService,
        email_accounts_1.ImapService,
        email_accounts_1.GmailAccountService])
], EmailAccountsComponent);
exports.EmailAccountsComponent = EmailAccountsComponent;
//# sourceMappingURL=email-accounts.component.js.map
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
var common_1 = require("@angular/common");
var forms_1 = require("@angular/forms");
var email_account_list_1 = require("./email-account-list");
var imap_settings_form_1 = require("./imap-settings-form");
var shared_1 = require("./shared");
var email_accounts_component_1 = require("./email-accounts.component");
var email_accounts_routing_module_1 = require("./email-accounts-routing.module");
var EmailAccountsModule = (function () {
    function EmailAccountsModule() {
    }
    return EmailAccountsModule;
}());
EmailAccountsModule = __decorate([
    core_1.NgModule({
        imports: [
            common_1.CommonModule,
            forms_1.FormsModule,
            email_accounts_routing_module_1.EmailAccountsRoutingModule
        ],
        declarations: [email_account_list_1.EmailAccountListComponent, imap_settings_form_1.ImapSettingsFormComponent, email_accounts_component_1.EmailAccountsComponent],
        exports: [email_account_list_1.EmailAccountListComponent, imap_settings_form_1.ImapSettingsFormComponent],
        providers: [shared_1.EmailAccountService, shared_1.GmailAccountService, shared_1.ImapService]
    }),
    __metadata("design:paramtypes", [])
], EmailAccountsModule);
exports.EmailAccountsModule = EmailAccountsModule;
//# sourceMappingURL=email-accounts.module.js.map
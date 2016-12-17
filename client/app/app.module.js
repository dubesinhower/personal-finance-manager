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
var platform_browser_1 = require("@angular/platform-browser");
var http_1 = require("@angular/http");
var forms_1 = require("@angular/forms");
var app_component_1 = require("./app.component");
var app_routing_module_1 = require("./app-routing.module");
var store_1 = require("@ngrx/store");
var core_2 = require("./core");
var user_account_1 = require("./user-account");
var shared_1 = require("./shared");
var email_accounts_1 = require("./email-accounts");
var home_1 = require("./home");
var authorize_1 = require("./authorize");
var accounts_1 = require("./accounts");
var AppModule = (function () {
    function AppModule() {
    }
    return AppModule;
}());
AppModule = __decorate([
    core_1.NgModule({
        imports: [
            platform_browser_1.BrowserModule,
            http_1.HttpModule,
            forms_1.FormsModule,
            app_routing_module_1.AppRoutingModule,
            store_1.StoreModule.provideStore({
                userToken: shared_1.userTokenReducer,
                emailAccounts: shared_1.emailAccountsReducer,
                selectedEmailAccount: shared_1.selectedEmailAccountReducer,
                googleOAuthSecurityToken: shared_1.googleOAuthSecurityTokenReducer
            }),
            core_2.CoreModule,
            user_account_1.UserAccountModule,
            shared_1.SharedModule,
            email_accounts_1.EmailAccountsModule
        ],
        declarations: [
            home_1.HomeComponent,
            app_component_1.AppComponent,
            accounts_1.AccountsComponent,
            authorize_1.AuthorizeComponent,
            accounts_1.TransactionTableComponent
        ],
        providers: [
            accounts_1.AccountService,
            user_account_1.UserAccountService
        ],
        bootstrap: [app_component_1.AppComponent]
    }),
    __metadata("design:paramtypes", [])
], AppModule);
exports.AppModule = AppModule;
//# sourceMappingURL=app.module.js.map
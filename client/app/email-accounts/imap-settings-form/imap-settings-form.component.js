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
var shared_1 = require("../shared");
var shared_2 = require("../../shared");
var ImapSettingsFormComponent = (function () {
    function ImapSettingsFormComponent() {
        this.submitSettings = new core_1.EventEmitter();
    }
    ImapSettingsFormComponent.prototype.ngOnInit = function () {
        this.imapSettings = new shared_1.ImapSettings(this.selectedAccount, new shared_1.Socket('', null), new shared_2.Login('', null));
    };
    return ImapSettingsFormComponent;
}());
__decorate([
    core_1.Input(),
    __metadata("design:type", Number)
], ImapSettingsFormComponent.prototype, "selectedAccount", void 0);
__decorate([
    core_1.Input(),
    __metadata("design:type", String)
], ImapSettingsFormComponent.prototype, "errorMessage", void 0);
__decorate([
    core_1.Output(),
    __metadata("design:type", Object)
], ImapSettingsFormComponent.prototype, "submitSettings", void 0);
ImapSettingsFormComponent = __decorate([
    core_1.Component({
        selector: 'pfm-imap-settings-form',
        templateUrl: 'app/email-accounts/imap-settings-form/imap-settings-form.component.html'
    }),
    __metadata("design:paramtypes", [])
], ImapSettingsFormComponent);
exports.ImapSettingsFormComponent = ImapSettingsFormComponent;
//# sourceMappingURL=imap-settings-form.component.js.map
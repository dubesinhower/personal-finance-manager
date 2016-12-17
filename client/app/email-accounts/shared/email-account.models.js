"use strict";
var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var EmailAccount = (function () {
    function EmailAccount(id, name, type, created, lastScanned) {
        this.id = id;
        this.name = name;
        this.type = type;
        this.created = created;
        this.lastScanned = lastScanned;
    }
    return EmailAccount;
}());
exports.EmailAccount = EmailAccount;
var ImapAccount = (function (_super) {
    __extends(ImapAccount, _super);
    function ImapAccount(id, name, type, created, lastScanned, imapCredentials) {
        var _this = _super.call(this, id, name, type, created, lastScanned) || this;
        _this.id = id;
        _this.name = name;
        _this.type = type;
        _this.created = created;
        _this.lastScanned = lastScanned;
        _this.imapCredentials = imapCredentials;
        return _this;
    }
    return ImapAccount;
}(EmailAccount));
exports.ImapAccount = ImapAccount;
//# sourceMappingURL=email-account.models.js.map
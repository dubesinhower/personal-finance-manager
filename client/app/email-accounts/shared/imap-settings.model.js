"use strict";
var ImapSettings = (function () {
    function ImapSettings(emailAccountId, connection, login) {
        this.emailAccountId = emailAccountId;
        this.connection = connection;
        this.login = login;
    }
    return ImapSettings;
}());
exports.ImapSettings = ImapSettings;
//# sourceMappingURL=imap-settings.model.js.map
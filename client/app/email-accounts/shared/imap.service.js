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
var ImapService = (function () {
    function ImapService(_http) {
        this._http = _http;
        this.secureBaseUrl = 'https://localhost:44337';
    }
    ImapService.prototype.addSettings = function (settings) {
        var body = JSON.stringify(settings);
        var token = JSON.parse(localStorage.getItem('userAccountToken'));
        var headers = new http_1.Headers({
            'Authorization': "Bearer " + token.access_token,
            'Content-Type': 'application/json'
        });
        var options = new http_1.RequestOptions({ headers: headers });
        return this._http
            .post(this.secureBaseUrl + "/api/imapSettings", body, options);
    };
    return ImapService;
}());
ImapService = __decorate([
    core_1.Injectable(),
    __metadata("design:paramtypes", [http_1.Http])
], ImapService);
exports.ImapService = ImapService;
//# sourceMappingURL=imap.service.js.map
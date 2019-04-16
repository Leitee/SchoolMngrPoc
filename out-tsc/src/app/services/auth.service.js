import * as tslib_1 from "tslib";
import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from '@angular/common/http';
var AuthService = /** @class */ (function () {
    function AuthService(http) {
        this.http = http;
    }
    AuthService.prototype.login = function (body) {
        var headerReq = new HttpHeaders({ 'Content-Type': 'application/json' });
        var response = this.http.post("http://localhost:3000/api/auth/login", body, { headers: headerReq });
        return response;
    };
    AuthService.prototype.register = function (body) {
        var headerReq = new HttpHeaders({ 'Content-Type': 'application/json' });
        var response = this.http.post("http://localhost:3000/api/auth/register", body, { headers: headerReq });
        return response;
    };
    AuthService = tslib_1.__decorate([
        Injectable(),
        tslib_1.__metadata("design:paramtypes", [HttpClient])
    ], AuthService);
    return AuthService;
}());
export { AuthService };
//# sourceMappingURL=auth.service.js.map
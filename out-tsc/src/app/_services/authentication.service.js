import * as tslib_1 from "tslib";
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'environments/environment';
import * as jwt_decode from 'jwt-decode';
import { BehaviorSubject } from 'rxjs';
import { map } from 'rxjs/operators';
var AuthenticationService = /** @class */ (function () {
    function AuthenticationService(http) {
        this.http = http;
        this.tokenKey = "storedToken";
        this.currentUserSubject = new BehaviorSubject(this.GetUserFromStoredToken(localStorage.getItem(this.tokenKey)));
        this.currentUser = this.currentUserSubject.asObservable();
    }
    Object.defineProperty(AuthenticationService.prototype, "currentUserValue", {
        get: function () {
            return this.currentUserSubject.value;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(AuthenticationService.prototype, "storedToken", {
        get: function () {
            return localStorage.getItem(this.tokenKey);
        },
        enumerable: true,
        configurable: true
    });
    AuthenticationService.prototype.login = function (loginObj) {
        var _this = this;
        return this.http.post(environment.authUrl + "/login", loginObj)
            .pipe(map(function (resp) {
            // login successful if there's a jwt token in the response
            if (resp && !resp.hasError && resp.data.hasToken) {
                // store user details and jwt token in local storage to keep user logged in between page refreshes
                localStorage.setItem(_this.tokenKey, resp.data.token);
                _this.currentUserSubject.next(_this.GetUserFromStoredToken(resp.data.token));
            }
            return resp.data;
        }));
    };
    AuthenticationService.prototype.logout = function () {
        // remove user from local storage to log user out
        localStorage.removeItem(this.tokenKey);
        this.currentUserSubject.next(null);
    };
    AuthenticationService.prototype.GetUserFromStoredToken = function (tokenStr) {
        var userStr = (tokenStr === null) ? tokenStr : jwt_decode(tokenStr).userdata.toLowerCase();
        return JSON.parse(userStr);
    };
    AuthenticationService = tslib_1.__decorate([
        Injectable({ providedIn: 'root' }),
        tslib_1.__metadata("design:paramtypes", [HttpClient])
    ], AuthenticationService);
    return AuthenticationService;
}());
export { AuthenticationService };
//# sourceMappingURL=authentication.service.js.map
import * as tslib_1 from "tslib";
import { Injectable } from '@angular/core';
import { AuthenticationService } from '@/_services';
var JwtInterceptor = /** @class */ (function () {
    function JwtInterceptor(authenticationService) {
        this.authenticationService = authenticationService;
    }
    JwtInterceptor.prototype.intercept = function (request, next) {
        // add authorization header with jwt token if available
        var token = this.authenticationService.storedToken;
        if (token !== null) {
            request = request.clone({
                setHeaders: {
                    Authorization: "Bearer " + token
                }
            });
        }
        return next.handle(request);
    };
    JwtInterceptor = tslib_1.__decorate([
        Injectable(),
        tslib_1.__metadata("design:paramtypes", [AuthenticationService])
    ], JwtInterceptor);
    return JwtInterceptor;
}());
export { JwtInterceptor };
//# sourceMappingURL=jwt.interceptor.js.map
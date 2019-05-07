import * as tslib_1 from "tslib";
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from './_services';
import { RolesEnum } from './_models';
var AppComponent = /** @class */ (function () {
    function AppComponent(router, authenticationService) {
        var _this = this;
        this.router = router;
        this.authenticationService = authenticationService;
        this.authenticationService.currentUser.subscribe(function (u) { return _this.currentUser = u; });
    }
    Object.defineProperty(AppComponent.prototype, "isAdmin", {
        get: function () {
            return this.currentUser && this.currentUser.role.id < RolesEnum.SUPERVISOR;
        },
        enumerable: true,
        configurable: true
    });
    AppComponent.prototype.logout = function () {
        this.authenticationService.logout();
        this.router.navigate(['/login']);
    };
    AppComponent = tslib_1.__decorate([
        Component({ selector: 'app', templateUrl: 'app.component.html' }),
        tslib_1.__metadata("design:paramtypes", [Router,
            AuthenticationService])
    ], AppComponent);
    return AppComponent;
}());
export { AppComponent };
//# sourceMappingURL=app.component.js.map
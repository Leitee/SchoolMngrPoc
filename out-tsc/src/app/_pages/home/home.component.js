import * as tslib_1 from "tslib";
import { AccountService, AuthenticationService } from '@/_services';
import { Component } from '@angular/core';
var HomeComponent = /** @class */ (function () {
    function HomeComponent(userService, authenticationService) {
        this.userService = userService;
        this.authenticationService = authenticationService;
        this.currentUser = this.authenticationService.currentUserValue;
    }
    HomeComponent.prototype.ngOnInit = function () {
        // this.userService.getUserById(this.currentUser.id).pipe(first()).subscribe(user => {
        //     this.userFromApi = user;
        // });
    };
    HomeComponent = tslib_1.__decorate([
        Component({ templateUrl: 'home.component.html', styleUrls: ['../pages.component.scss'] }),
        tslib_1.__metadata("design:paramtypes", [AccountService,
            AuthenticationService])
    ], HomeComponent);
    return HomeComponent;
}());
export { HomeComponent };
//# sourceMappingURL=home.component.js.map
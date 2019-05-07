import * as tslib_1 from "tslib";
import { Component } from '@angular/core';
import { AccountService } from '@/_services';
var AdminComponent = /** @class */ (function () {
    function AdminComponent(userService) {
        this.userService = userService;
        this.users = [];
    }
    AdminComponent.prototype.ngOnInit = function () {
        // this.userService.getAllUsers().pipe(first()).subscribe(users => {
        //     this.users = users;
        // });
    };
    AdminComponent = tslib_1.__decorate([
        Component({ templateUrl: 'admin.component.html', styleUrls: ['../pages.component.scss'] }),
        tslib_1.__metadata("design:paramtypes", [AccountService])
    ], AdminComponent);
    return AdminComponent;
}());
export { AdminComponent };
//# sourceMappingURL=admin.component.js.map
import * as tslib_1 from "tslib";
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
var AccountService = /** @class */ (function (_super) {
    tslib_1.__extends(AccountService, _super);
    function AccountService(http) {
        return _super.call(this, http) || this;
    }
    AccountService.prototype.getAllUsers = function () {
        this.path = 'account/users';
        return this.get();
    };
    AccountService.prototype.getUserById = function (id) {
        this.path = 'account/users';
        return this.getById(id);
    };
    AccountService = tslib_1.__decorate([
        Injectable({ providedIn: 'root' }),
        tslib_1.__metadata("design:paramtypes", [HttpClient])
    ], AccountService);
    return AccountService;
}(BaseService));
export { AccountService };
//# sourceMappingURL=account.service.js.map
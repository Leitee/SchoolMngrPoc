import * as tslib_1 from "tslib";
import { Component } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { Router } from "@angular/router";
var RegisterComponent = /** @class */ (function () {
    function RegisterComponent(auth, router) {
        this.auth = auth;
        this.router = router;
    }
    RegisterComponent.prototype.ngOnInit = function () {
    };
    RegisterComponent.prototype.register = function (form) {
        var _this = this;
        var body = { email: form.value.email, name: form.value.name, password: form.value.password, role: form.value.role };
        var resp = this.auth.register(body);
        resp.subscribe(function (value) {
            if (value) {
                localStorage.setItem('token', value.access_token);
                _this.router.navigate(['/home']);
            }
        });
    };
    RegisterComponent = tslib_1.__decorate([
        Component({
            selector: 'app-register',
            templateUrl: './register.component.html',
            styleUrls: ['./register.component.css'],
            providers: [AuthService]
        }),
        tslib_1.__metadata("design:paramtypes", [AuthService, Router])
    ], RegisterComponent);
    return RegisterComponent;
}());
export { RegisterComponent };
//# sourceMappingURL=register.component.js.map
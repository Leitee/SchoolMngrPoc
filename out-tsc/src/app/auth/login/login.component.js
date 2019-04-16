import * as tslib_1 from "tslib";
import { Component } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';
import { Router } from '@angular/router';
var LoginComponent = /** @class */ (function () {
    function LoginComponent(auth, router) {
        this.auth = auth;
        this.router = router;
    }
    LoginComponent.prototype.ngOnInit = function () {
    };
    LoginComponent.prototype.login = function (form) {
        var _this = this;
        var body = { email: form.value.email, password: form.value.password };
        var resp = this.auth.login(body);
        resp.subscribe(function (value) {
            if (value) {
                localStorage.setItem('token', value.access_token);
                _this.router.navigate(['/home']);
            }
        });
    };
    LoginComponent = tslib_1.__decorate([
        Component({
            selector: 'app-login',
            templateUrl: './login.component.html',
            styleUrls: ['./login.component.css'],
            providers: [AuthService]
        }),
        tslib_1.__metadata("design:paramtypes", [AuthService, Router])
    ], LoginComponent);
    return LoginComponent;
}());
export { LoginComponent };
//# sourceMappingURL=login.component.js.map
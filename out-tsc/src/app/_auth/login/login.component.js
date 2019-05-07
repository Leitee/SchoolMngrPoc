import * as tslib_1 from "tslib";
import { AuthenticationService } from '@/_services';
import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { first } from 'rxjs/operators';
var LoginComponent = /** @class */ (function () {
    function LoginComponent(formBuilder, route, router, authenticationService) {
        this.formBuilder = formBuilder;
        this.route = route;
        this.router = router;
        this.authenticationService = authenticationService;
        this.loading = false;
        this.submitted = false;
        this.error = '';
        // redirect to home if already logged in
        if (this.authenticationService.currentUserValue) {
            this.router.navigate(['/']);
        }
    }
    LoginComponent.prototype.ngOnInit = function () {
        this.loginForm = this.formBuilder.group({
            username: ['', Validators.required],
            password: ['', Validators.required]
        });
        // get return url from route parameters or default to '/'
        this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
    };
    Object.defineProperty(LoginComponent.prototype, "f", {
        // convenience getter for easy access to form fields
        get: function () { return this.loginForm.controls; },
        enumerable: true,
        configurable: true
    });
    LoginComponent.prototype.onSubmit = function () {
        var _this = this;
        this.submitted = true;
        // stop here if form is invalid
        if (this.loginForm.invalid) {
            return;
        }
        var loginObj = { username: this.f.username.value, password: this.f.password.value, rememberMe: false };
        this.loading = true;
        this.authenticationService.login(loginObj)
            .pipe(first())
            .subscribe(function (data) {
            if (data.hasToken)
                _this.router.navigate([_this.returnUrl]);
            else
                _this.error = data.messageResponse;
            _this.loading = false;
        }, function (error) {
            console.error(error);
            _this.error = error;
            _this.loading = false;
        });
    };
    LoginComponent = tslib_1.__decorate([
        Component({ templateUrl: 'login.component.html', styleUrls: ['../auth.component.scss'] }),
        tslib_1.__metadata("design:paramtypes", [FormBuilder,
            ActivatedRoute,
            Router,
            AuthenticationService])
    ], LoginComponent);
    return LoginComponent;
}());
export { LoginComponent };
//# sourceMappingURL=login.component.js.map
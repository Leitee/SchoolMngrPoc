import * as tslib_1 from "tslib";
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { RouterModule } from '@angular/router';
var routes = [
    { path: '', redirectTo: 'login', pathMatch: 'full' },
    { path: 'login', component: LoginComponent },
    { path: 'register', component: RegisterComponent }
];
var AuthModule = /** @class */ (function () {
    function AuthModule() {
    }
    AuthModule = tslib_1.__decorate([
        NgModule({
            declarations: [RegisterComponent, LoginComponent],
            imports: [
                CommonModule,
                FormsModule,
                RouterModule.forChild(routes)
            ],
            exports: [RouterModule]
        })
    ], AuthModule);
    return AuthModule;
}());
export { AuthModule };
//# sourceMappingURL=auth.module.js.map
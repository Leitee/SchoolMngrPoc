import * as tslib_1 from "tslib";
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { MainNavComponent } from './main-nav/main-nav.component';
var routes = [
    { path: 'home', component: MainNavComponent },
    { path: 'auth', loadChildren: './auth/auth.module#AuthModule' },
    {
        path: '',
        redirectTo: 'home',
        pathMatch: 'full'
    }
];
var AppRoutingModule = /** @class */ (function () {
    function AppRoutingModule() {
    }
    AppRoutingModule = tslib_1.__decorate([
        NgModule({
            imports: [RouterModule.forRoot(routes)],
            exports: [RouterModule],
            providers: []
        })
    ], AppRoutingModule);
    return AppRoutingModule;
}());
export { AppRoutingModule };
//# sourceMappingURL=app-routing.module.js.map
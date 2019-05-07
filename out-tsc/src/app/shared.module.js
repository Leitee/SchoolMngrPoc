import * as tslib_1 from "tslib";
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { MaterialModule } from './material.module';
import { MenuComponent } from './_components';
import { ContentWrapperComponent } from './_components/content-wrapper/content-wrapper.component';
var SharedModule = /** @class */ (function () {
    function SharedModule() {
    }
    SharedModule = tslib_1.__decorate([
        NgModule({
            declarations: [
                MenuComponent,
                ContentWrapperComponent
            ],
            imports: [
                CommonModule,
                MaterialModule
            ],
            exports: [
                CommonModule,
                MaterialModule,
                MenuComponent,
                ContentWrapperComponent
            ]
        })
    ], SharedModule);
    return SharedModule;
}());
export { SharedModule };
//# sourceMappingURL=shared.module.js.map
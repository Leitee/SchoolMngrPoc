import * as tslib_1 from "tslib";
import { NgModule } from '@angular/core';
import { MatToolbarModule, MatButtonModule, MatSidenavModule, MatIconModule, MatListModule, MatMenuModule, MatGridListModule, MatCardModule } from '@angular/material';
import { LayoutModule } from '@angular/cdk/layout';
var MaterialModule = /** @class */ (function () {
    function MaterialModule() {
    }
    MaterialModule = tslib_1.__decorate([
        NgModule({
            imports: [
                LayoutModule,
                MatToolbarModule,
                MatButtonModule,
                MatSidenavModule,
                MatIconModule,
                MatListModule,
                MatMenuModule,
                MatGridListModule,
                MatCardModule
            ],
            exports: [
                LayoutModule,
                MatToolbarModule,
                MatButtonModule,
                MatSidenavModule,
                MatIconModule,
                MatListModule,
                MatMenuModule,
                MatGridListModule,
                MatCardModule
            ]
        })
    ], MaterialModule);
    return MaterialModule;
}());
export { MaterialModule };
//# sourceMappingURL=material.module.js.map
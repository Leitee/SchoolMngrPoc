import * as tslib_1 from "tslib";
import { Component, Input } from '@angular/core';
var ContentWrapperComponent = /** @class */ (function () {
    function ContentWrapperComponent() {
    }
    ContentWrapperComponent.prototype.ngOnInit = function () {
    };
    tslib_1.__decorate([
        Input(),
        tslib_1.__metadata("design:type", String)
    ], ContentWrapperComponent.prototype, "headerTitle", void 0);
    ContentWrapperComponent = tslib_1.__decorate([
        Component({
            selector: 'app-content-wrapper',
            templateUrl: './content-wrapper.component.html',
            styleUrls: ['./content-wrapper.component.scss']
        }),
        tslib_1.__metadata("design:paramtypes", [])
    ], ContentWrapperComponent);
    return ContentWrapperComponent;
}());
export { ContentWrapperComponent };
//# sourceMappingURL=content-wrapper.component.js.map
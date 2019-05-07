import * as tslib_1 from "tslib";
import { SchoolService } from '@/_services';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
var MenuComponent = /** @class */ (function () {
    function MenuComponent(schoolSvc, router) {
        this.schoolSvc = schoolSvc;
        this.router = router;
    }
    MenuComponent.prototype.ngOnInit = function () {
        this.gradeListAsync = this.schoolSvc.getGrades();
    };
    MenuComponent.prototype.onGradeSelect = function (grade) {
        this.router.navigate(["grade/" + grade.id], { queryParams: grade });
    };
    MenuComponent = tslib_1.__decorate([
        Component({
            selector: 'app-menu',
            templateUrl: './menu.component.html',
            styleUrls: ['./menu.component.scss'],
            providers: [SchoolService]
        }),
        tslib_1.__metadata("design:paramtypes", [SchoolService, Router])
    ], MenuComponent);
    return MenuComponent;
}());
export { MenuComponent };
//# sourceMappingURL=menu.component.js.map
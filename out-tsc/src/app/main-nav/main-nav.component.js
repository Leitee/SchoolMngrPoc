import * as tslib_1 from "tslib";
import { Component } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { map } from 'rxjs/operators';
import { SchoolService } from '../services/school.service';
var MainNavComponent = /** @class */ (function () {
    function MainNavComponent(breakpointObserver, schoolSvc) {
        var _this = this;
        this.breakpointObserver = breakpointObserver;
        this.schoolSvc = schoolSvc;
        this.isHandset$ = this.breakpointObserver.observe(Breakpoints.Handset)
            .pipe(map(function (result) { return result.matches; }));
        this.schoolSvc.getGrades().subscribe(//suscribe sirve para suscribirse a la respuesta del server
        function (resul) {
            _this.gradesList = resul.grades;
        });
    }
    MainNavComponent.prototype.onItemClick = function (gradeId) {
        var _this = this;
        this.schoolSvc.getClassesByGradeId(gradeId).subscribe(function (resul) {
            _this.classesList = resul.classes;
        });
    };
    MainNavComponent = tslib_1.__decorate([
        Component({
            selector: 'app-main-nav',
            templateUrl: './main-nav.component.html',
            styleUrls: ['./main-nav.component.css'],
            providers: [SchoolService]
        }),
        tslib_1.__metadata("design:paramtypes", [BreakpointObserver, SchoolService])
    ], MainNavComponent);
    return MainNavComponent;
}());
export { MainNavComponent };
//# sourceMappingURL=main-nav.component.js.map
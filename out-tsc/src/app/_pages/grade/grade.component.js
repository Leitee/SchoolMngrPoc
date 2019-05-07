import * as tslib_1 from "tslib";
import { SchoolService } from '@/_services';
import { BreakpointObserver, Breakpoints } from "@angular/cdk/layout";
import { Component } from "@angular/core";
import { map } from 'rxjs/operators';
var GradeComponent = /** @class */ (function () {
    function GradeComponent(breakpointObserver, schoolSvc) {
        this.breakpointObserver = breakpointObserver;
        this.schoolSvc = schoolSvc;
        /** Based on the screen size, switch from standard to one column per row */
        this.cards = this.breakpointObserver.observe(Breakpoints.Handset).pipe(map(function (_a) {
            var matches = _a.matches;
            if (matches) {
                return [
                    { title: 'Card 1', cols: 1, rows: 1 },
                    { title: 'Card 2', cols: 1, rows: 1 },
                    { title: 'Card 3', cols: 1, rows: 1 },
                    { title: 'Card 4', cols: 1, rows: 1 }
                ];
            }
            return [
                { title: 'Card 1', cols: 1, rows: 1 },
                { title: 'Card 2', cols: 1, rows: 1 },
                { title: 'Card 3', cols: 1, rows: 1 },
                { title: 'Card 4', cols: 1, rows: 1 }
            ];
        }));
    }
    GradeComponent.prototype.ngOnInit = function () {
        this.classListSource = this.schoolSvc.getClassesByGradeId(1);
    };
    GradeComponent = tslib_1.__decorate([
        Component({
            templateUrl: './grade.component.html',
            providers: [SchoolService]
        }),
        tslib_1.__metadata("design:paramtypes", [BreakpointObserver, SchoolService])
    ], GradeComponent);
    return GradeComponent;
}());
export { GradeComponent };
//# sourceMappingURL=grade.component.js.map
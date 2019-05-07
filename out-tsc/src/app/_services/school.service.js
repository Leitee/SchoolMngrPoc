import * as tslib_1 from "tslib";
import { HttpClient } from '@angular/common/http';
import { Injectable } from "@angular/core";
import { BaseService } from './base.service';
var SchoolService = /** @class */ (function (_super) {
    tslib_1.__extends(SchoolService, _super);
    function SchoolService(http) {
        return _super.call(this, http) || this;
    }
    SchoolService.prototype.getGrades = function () {
        this.path = "grades";
        return this.get();
    };
    SchoolService.prototype.getClassesByGradeId = function (gradeId) {
        this.path = "grades";
        return this.getById(gradeId);
    };
    SchoolService = tslib_1.__decorate([
        Injectable(),
        tslib_1.__metadata("design:paramtypes", [HttpClient])
    ], SchoolService);
    return SchoolService;
}(BaseService));
export { SchoolService };
//# sourceMappingURL=school.service.js.map
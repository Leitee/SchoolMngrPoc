import * as tslib_1 from "tslib";
import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from '@angular/common/http';
var SchoolService = /** @class */ (function () {
    function SchoolService(http) {
        this.http = http;
    }
    SchoolService.prototype.getGrades = function () {
        var headerReq = new HttpHeaders({ 'Content-Type': 'application/json' }); // se cofiguta el header del request para que el resultado sea del tipo json 
        var response = this.http.get("http://localhost:3000/api/v1/grades", { headers: headerReq }); // get es el metodo que usamos para llamar al server, no tiene body
        return response;
    };
    SchoolService.prototype.getClassesByGradeId = function (gradeId) {
        var headerReq = new HttpHeaders({ 'Content-Type': 'application/json' }); // se cofiguta el header del request para que el resultado sea del tipo json 
        var response = this.http.get("http://localhost:3000/api/v1/classes/" + gradeId, { headers: headerReq }); // get es el metodo que usamos para llamar al server, no tiene body
        return response;
    };
    SchoolService = tslib_1.__decorate([
        Injectable(),
        tslib_1.__metadata("design:paramtypes", [HttpClient])
    ], SchoolService);
    return SchoolService;
}());
export { SchoolService };
//# sourceMappingURL=school.service.js.map
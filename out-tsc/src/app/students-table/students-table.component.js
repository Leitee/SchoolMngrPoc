import * as tslib_1 from "tslib";
import { Component, ViewChild } from '@angular/core';
import { MatPaginator, MatSort } from '@angular/material';
import { StudentsTableDataSource } from './students-table-datasource';
var StudentsTableComponent = /** @class */ (function () {
    function StudentsTableComponent() {
        /** Columns displayed in the table. Columns IDs can be added, removed, or reordered. */
        this.displayedColumns = ['id', 'name'];
    }
    StudentsTableComponent.prototype.ngOnInit = function () {
        this.dataSource = new StudentsTableDataSource(this.paginator, this.sort);
    };
    tslib_1.__decorate([
        ViewChild(MatPaginator),
        tslib_1.__metadata("design:type", MatPaginator)
    ], StudentsTableComponent.prototype, "paginator", void 0);
    tslib_1.__decorate([
        ViewChild(MatSort),
        tslib_1.__metadata("design:type", MatSort)
    ], StudentsTableComponent.prototype, "sort", void 0);
    StudentsTableComponent = tslib_1.__decorate([
        Component({
            selector: 'app-students-table',
            templateUrl: './students-table.component.html',
            styleUrls: ['./students-table.component.css']
        })
    ], StudentsTableComponent);
    return StudentsTableComponent;
}());
export { StudentsTableComponent };
//# sourceMappingURL=students-table.component.js.map
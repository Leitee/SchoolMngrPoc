import * as tslib_1 from "tslib";
import { DataSource } from '@angular/cdk/collections';
import { map } from 'rxjs/operators';
import { of as observableOf, merge } from 'rxjs';
// TODO: replace this with real data from your application
var EXAMPLE_DATA = [
    { id: 16454532, name: 'Sergio almiron' },
    { id: 24651151, name: 'Hernan caire' },
    { id: 38343118, name: 'Lilita carrio' },
    { id: 65151511, name: 'Berisso gil' },
    { id: 56181118, name: 'gimena Baron' },
    { id: 55656155, name: 'Carlos bonzon' },
    { id: 75165165, name: 'Nicolas gomes' },
    { id: 88585231, name: 'Omar polo' },
    { id: 98420248, name: 'Florencia marquz' },
    { id: 17141150, name: 'Neo natal' },
];
/**
 * Data source for the StudentsTable view. This class should
 * encapsulate all logic for fetching and manipulating the displayed data
 * (including sorting, pagination, and filtering).
 */
var StudentsTableDataSource = /** @class */ (function (_super) {
    tslib_1.__extends(StudentsTableDataSource, _super);
    function StudentsTableDataSource(paginator, sort) {
        var _this = _super.call(this) || this;
        _this.paginator = paginator;
        _this.sort = sort;
        _this.data = EXAMPLE_DATA;
        return _this;
    }
    /**
     * Connect this data source to the table. The table will only update when
     * the returned stream emits new items.
     * @returns A stream of the items to be rendered.
     */
    StudentsTableDataSource.prototype.connect = function () {
        var _this = this;
        // Combine everything that affects the rendered data into one update
        // stream for the data-table to consume.
        var dataMutations = [
            observableOf(this.data),
            this.paginator.page,
            this.sort.sortChange
        ];
        // Set the paginator's length
        this.paginator.length = this.data.length;
        return merge.apply(void 0, dataMutations).pipe(map(function () {
            return _this.getPagedData(_this.getSortedData(_this.data.slice()));
        }));
    };
    /**
     *  Called when the table is being destroyed. Use this function, to clean up
     * any open connections or free any held resources that were set up during connect.
     */
    StudentsTableDataSource.prototype.disconnect = function () { };
    /**
     * Paginate the data (client-side). If you're using server-side pagination,
     * this would be replaced by requesting the appropriate data from the server.
     */
    StudentsTableDataSource.prototype.getPagedData = function (data) {
        var startIndex = this.paginator.pageIndex * this.paginator.pageSize;
        return data.splice(startIndex, this.paginator.pageSize);
    };
    /**
     * Sort the data (client-side). If you're using server-side sorting,
     * this would be replaced by requesting the appropriate data from the server.
     */
    StudentsTableDataSource.prototype.getSortedData = function (data) {
        var _this = this;
        if (!this.sort.active || this.sort.direction === '') {
            return data;
        }
        return data.sort(function (a, b) {
            var isAsc = _this.sort.direction === 'asc';
            switch (_this.sort.active) {
                case 'name': return compare(a.name, b.name, isAsc);
                case 'id': return compare(+a.id, +b.id, isAsc);
                default: return 0;
            }
        });
    };
    return StudentsTableDataSource;
}(DataSource));
export { StudentsTableDataSource };
/** Simple sort comparator for example ID/Name columns (for client-side sorting). */
function compare(a, b, isAsc) {
    return (a < b ? -1 : 1) * (isAsc ? 1 : -1);
}
//# sourceMappingURL=students-table-datasource.js.map
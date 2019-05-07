import { HttpHeaders } from '@angular/common/http';
import { environment } from 'environments/environment';
import { map } from "rxjs/operators";
var BaseService = /** @class */ (function () {
    function BaseService(http) {
        this.http = http;
        this.headerReq = new HttpHeaders({ 'Content-Type': 'application/json' });
    }
    BaseService.prototype.get = function () {
        var response = this.http.get(environment.apiUrl + "/" + this.path, { headers: this.headerReq });
        return response.pipe(map(function (a) { return a.data; }));
    };
    BaseService.prototype.getById = function (id) {
        var response = this.http.get(environment.apiUrl + "/" + this.path + "/" + id + "/classes", { headers: this.headerReq });
        return response.pipe(map(function (a) { return a.data; }));
    };
    return BaseService;
}());
export { BaseService };
//# sourceMappingURL=base.service.js.map
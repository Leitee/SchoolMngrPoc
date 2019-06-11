import { ApiResponse } from '@/_commons';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'environments/environment';
import { Observable } from 'rxjs';
import { map } from "rxjs/operators";

export abstract class BaseService {

    /**
     * This param starts and ends with no slash `/`
     */
    protected path: string;
    private headerReq: HttpHeaders;

    constructor(private http: HttpClient) {
        this.headerReq = new HttpHeaders({ 'Content-Type': 'application/json' });
    }

    protected get<T>(): Observable<T[]> {
        let response = this.http.get<ApiResponse<T[]>>(`${environment.apiUrl}/${this.path}`, { headers: this.headerReq });
        return response.pipe(map(a => a.data));
    }

    protected getById<T>(id: number): Observable<T> {
        let response = this.http.get<ApiResponse<T>>(`${environment.apiUrl}/${this.path}/${id}`, { headers: this.headerReq });
        return response.pipe(map(a => a.data));
    }
}
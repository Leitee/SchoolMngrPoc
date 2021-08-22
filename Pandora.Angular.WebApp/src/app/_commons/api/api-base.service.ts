import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from "rxjs/operators";
import { ApiResponse } from './api-response.model';
import { AppConfigService } from '../config';


export abstract class ApiBaseService<T> {

    /**
     * This param starts and ends with no slash `/`
     */
    protected path: string;
    protected headerReq: HttpHeaders;

    constructor(protected http: HttpClient) {
        this.headerReq = new HttpHeaders({ 'Content-Type': 'application/json' });
    }

    protected getAll(): Observable<Array<T>> {
        let response = this.http.get<ApiResponse<Array<T>>>(`${AppConfigService.settings.server.apiUrl}/${this.path}`, { headers: this.headerReq });
        return response.pipe(map(a => a.data));
    }

    protected getListById(id: number): Observable<Array<T>> {
        let response = this.http.get<ApiResponse<Array<T>>>(this.getFullPath(id), { headers: this.headerReq });
        return response.pipe(map(a => a.data));
    }

    protected getSingleById(id: number): Observable<T> {
        let response = this.http.get<ApiResponse<T>>(`${AppConfigService.settings.server.apiUrl}/${this.path}/${id}`, { headers: this.headerReq });
        return response.pipe(map(a => a.data));
    }

    protected post(body: T): Observable<T> {
        let response = this.http.post<ApiResponse<T>>(`${AppConfigService.settings.server.apiUrl}/${this.path}`, body, { headers: this.headerReq });
        return response.pipe(map(a => a.data));
    }

    protected put(objId: number, body: T): Observable<boolean> {
        let response = this.http.put<ApiResponse<boolean>>(`${AppConfigService.settings.server.apiUrl}/${this.path}/${objId}`, body, { headers: this.headerReq });
        return response.pipe(map(a => a.data));
    }

    protected delete(objId: number): Observable<boolean> {
        let response = this.http.delete<ApiResponse<boolean>>(`${AppConfigService.settings.server.apiUrl}/${this.path}/${objId}`, { headers: this.headerReq });
        return response.pipe(map(a => a.data));
    }

    protected getFullPath(id: any = null): string {
        let partial = `${AppConfigService.settings.server.apiUrl}/${this.path}`;
        return id === null ? partial : `${partial}/${id}`;
    }
}
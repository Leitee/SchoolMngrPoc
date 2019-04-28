import { Response } from '@/_helpers';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from "rxjs/operators";
import { IRestService } from './rest.interface';

export abstract class BaseService implements IRestService {

    /**
     * This param starts and ends with no slash `/`
     */
    protected path: string;
    private headerReq: HttpHeaders;

    constructor(private http: HttpClient) {
        this.headerReq = new HttpHeaders({ 'Content-Type': 'application/json' });
    }

    get<T>(): Observable<T[]> {
        let response = this.http.get<Response<T[]>>(`${config.apiUrl}/${this.path}`, { headers: this.headerReq });
        return response.pipe(map(a => a.data));
    }

    getById<T>(id: number): Observable<T> {
        let response = this.http.get<Response<T>>(`${config.apiUrl}/${this.path}/${id}`, { headers: this.headerReq });
        return response.pipe(map(a => a.data));
    }
}
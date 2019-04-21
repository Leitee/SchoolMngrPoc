import { Response } from '@/_helpers';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from "rxjs/operators";
import { IRestService } from './rest.interface';

export abstract class BaseService implements IRestService {

    private headerReq: HttpHeaders = new HttpHeaders({ 'Content-Type': 'application/json' });

    constructor(private http: HttpClient) {
    }

    get<T>(): Observable<T[]> {
        let response = this.http.get<Response<T[]>>(`${config.apiUrl}/grades`, { headers: this.headerReq });
        return response.pipe(map(a => a.data));
    }

    getById<T>(id: number): Observable<T> {
        let response = this.http.get<Response<T>>(`${config.apiUrl}/grades/${id}`, { headers: this.headerReq });
        return response.pipe(map(a => a.data));
    }
}
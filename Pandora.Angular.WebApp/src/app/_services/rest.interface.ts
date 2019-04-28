import { Observable } from 'rxjs';

export interface IRestService {
    get<T>(): Observable<Array<T>>;
    getById<T>(id: number): Observable<T>;
}
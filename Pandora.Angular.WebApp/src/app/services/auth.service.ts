import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class AuthService {
    constructor(private http: HttpClient) {

    }

    public login(body: any): Observable<any> {
        let headerReq = new HttpHeaders({ 'Content-Type': 'application/json' });
        let response = this.http.post("http://localhost:3000/api/auth/login", body, { headers: headerReq });
        return response;
    }

    public register(body: any): Observable<any>{
        let headerReq = new HttpHeaders({ 'Content-Type': 'application/json' });
        let response = this.http.post("http://localhost:3000/api/auth/register", body, { headers: headerReq });
    
return response;
    
    }
}
import { ApiResponse } from '@/_commons';
import { Login, LoginResp, Token, User } from '@/_models';
import { HttpClient } from '@angular/common/http';
import { Injectable, Inject } from '@angular/core';
import * as jwt_decode from 'jwt-decode';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { DOCUMENT } from '@angular/common';
import { AppConfigService } from '@/_services'


@Injectable({ providedIn: 'root' })
export class AuthenticationService {
    private tokenKey = "storedToken";
    private currentUserSubject: BehaviorSubject<User>;
    public currentUser: Observable<User>;

    constructor(@Inject(DOCUMENT) private document: Document, private http: HttpClient) {
        this.currentUserSubject = new BehaviorSubject<User>(this.getUserFromStoredToken(localStorage.getItem(this.tokenKey)));
        this.currentUser = this.currentUserSubject.asObservable();
    }

    public get currentUserValue(): User {
        return this.currentUserSubject.value;
    }

    public get storedToken(): string {
        return localStorage.getItem(this.tokenKey);
    }

    login(loginObj: Login): Observable<LoginResp> {
        return this.http.post<ApiResponse<LoginResp>>(`${AppConfigService.settings.server.authUrl}/login`, loginObj)
            .pipe(

                map(resp => {

                    // login successful if there's a jwt token in the response
                    if (resp && !resp.hasError && resp.data.hasToken) {
                        // store user details and jwt token in local storage to keep user logged in between page refreshes
                        localStorage.setItem(this.tokenKey, resp.data.token);

                        this.currentUserSubject.next(this.getUserFromStoredToken(resp.data.token));
                    }

                    return resp.data;
                })
            );
    }

    googleLogin() {       
        this.document.location.href = `${AppConfigService.settings.server.authUrl}/social/google`;
    }

    logout() {
        // remove user from local storage to log user out
        localStorage.removeItem(this.tokenKey);
        this.http.post(`${AppConfigService.settings.server.authUrl}/logout`, {}).subscribe(() => {
            this.currentUserSubject.next(null);
            location.reload(true);
        });
    }

    private getUserFromStoredToken(tokenStr: string): User {
        let userStr = (tokenStr === null) ? tokenStr : jwt_decode<Token>(tokenStr).userdata.toLowerCase();
        return JSON.parse(userStr);
    }
}
import { ApiResponse } from '@/_commons';
import { Login, LoginResp, Token, User } from '@/_models';
import { HttpClient } from '@angular/common/http';
import { Injectable, Inject } from '@angular/core';
import * as jwt_decode from 'jwt-decode';
import { BehaviorSubject, Observable, of } from 'rxjs';
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

    googleRedirect() {
        this.document.location.href = `${AppConfigService.settings.server.authUrl}/social/google`;
    }

    facebookRedirect() {
        this.document.location.href = `${AppConfigService.settings.server.authUrl}/social/facebook`;
    }

    externalLogin(token: string): Observable<boolean> {
        localStorage.setItem(this.tokenKey, token);
        this.currentUserSubject.next(this.getUserFromStoredToken(token));
        return of(true);
    }

    logout() {
        // remove user from local storage to log user out
        this.currentUserSubject.next(null);
        localStorage.removeItem(this.tokenKey);
        this.http.post(`${AppConfigService.settings.server.authUrl}/logout`, {}).subscribe(() => {
            location.reload(true);
        });
    }

    private getUserFromStoredToken(tokenStr: string): User {
        let userStr: string; let roleStr: string;
        let user: User;

        if (tokenStr !== null) {
            userStr = jwt_decode<Token>(tokenStr).userdata.toLowerCase();
            user = JSON.parse(userStr);;
            roleStr = jwt_decode<Token>(tokenStr).userrole.toLowerCase();
            user.role = JSON.parse(roleStr);
        }
        return user;
    }
}
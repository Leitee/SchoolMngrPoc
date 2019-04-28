import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { User, LoginResp, Login } from '@/_models';
import { Response } from '@/_helpers';
import jwt_decode = require('jwt-decode');

@Injectable({ providedIn: 'root' })
export class AuthenticationService {
    private currentUserSubject: BehaviorSubject<User>;
    public currentUser: Observable<User>;

    constructor(private http: HttpClient) {
        this.currentUserSubject = new BehaviorSubject<User>(JSON.parse(localStorage.getItem('storedToken')));
        this.currentUser = this.currentUserSubject.asObservable();
    }

    public get currentUserValue(): User {
        return this.currentUserSubject.value;
    }

    public get storedToken(): string {
        return localStorage.getItem('storedToken');
    }

    login(loginObj : Login) {
        return this.http.post<Response<LoginResp>>(`${config.authUrl}/auth/vi/login`,  loginObj )
            .pipe(map(resp => {
                // login successful if there's a jwt token in the response
                if (resp && !resp.hasError && resp.data.hasToken) {
                    // store user details and jwt token in local storage to keep user logged in between page refreshes
                    localStorage.setItem('storedToken', JSON.stringify(resp.data.token));

                    let user : User = jwt_decode<User>(resp.data.token)
                    this.currentUserSubject.next(user);
                }

                return resp;
            }));
    }

    logout() {
        // remove user from local storage to log user out
        localStorage.removeItem('storedToken');
        this.currentUserSubject.next(null);
    }
}
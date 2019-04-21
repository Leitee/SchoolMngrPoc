import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { User2 } from '@/_models';

@Injectable({ providedIn: 'root' })
export class UserService {
    constructor(private http: HttpClient) { }

    getAll() {
        return this.http.get<User2[]>(`${config.apiUrl}/users`);
    }

    getById(id: number) {
        return this.http.get<User2>(`${config.apiUrl}/users/${id}`);
    }
}
import { User } from '@/_models';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BaseService } from './base.service';


@Injectable({ providedIn: 'root' })
export class AccountService extends BaseService {

    constructor(http: HttpClient) {
        super(http);
    }

    getAllUsers() {
        this.path = 'account/users';
        return this.get<User>();
    }

    getUserById(id: number) {
        this.path = 'account/users'
        return this.getById<User>(id);
    }
}
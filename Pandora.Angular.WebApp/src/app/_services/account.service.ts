import { User } from '@/_models';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ApiBaseService } from '../_commons/api/api-base.service';


@Injectable({ providedIn: 'root' })
export class AccountService extends ApiBaseService<User> {

    constructor(http: HttpClient) {
        super(http);
    }

    getAllUsers() {
        this.path = 'account/users';
        return this.getAll();
    }

    getUserById(id: number) {
        this.path = 'account/users'
        return this.getSingleById(id);
    }
}
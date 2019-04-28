import { Component, OnInit } from '@angular/core';
import { first } from 'rxjs/operators';

import { User2 } from '@/_models';
import { UserService } from '@/_services';

@Component({ templateUrl: 'admin.component.html' })
export class AdminComponent implements OnInit {
    users: User2[] = [];

    constructor(private userService: UserService) { }

    ngOnInit() {
        this.userService.getAll().pipe(first()).subscribe(users => {
            this.users = users;
        });
    }
}
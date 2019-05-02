import { Component, OnInit } from '@angular/core';
import { first } from 'rxjs/operators';

import { User } from '@/_models';
import { AccountService } from '@/_services';

@Component({ templateUrl: 'admin.component.html', styleUrls: ['../pages.component.scss'] })
export class AdminComponent implements OnInit {
    users: User[] = [];

    constructor(private userService: AccountService) { }

    ngOnInit() {
        this.userService.getAllUsers().pipe(first()).subscribe(users => {
            this.users = users;
        });
    }
}
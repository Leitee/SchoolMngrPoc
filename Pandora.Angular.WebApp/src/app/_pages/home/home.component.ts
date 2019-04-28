import { Component } from '@angular/core';
import { first } from 'rxjs/operators';

import { User2 } from '@/_models';
import { UserService, AuthenticationService } from '@/_services';

@Component({ templateUrl: 'home.component.html' })
export class HomeComponent {
    currentUser: User2;
    userFromApi: User2;

    constructor(
        private userService: UserService,
        private authenticationService: AuthenticationService
    ) {
        this.currentUser = this.authenticationService.currentUserValue;
    }

    ngOnInit() {
        this.userService.getById(this.currentUser.id).pipe(first()).subscribe(user => {
            this.userFromApi = user;
        });
    }
}
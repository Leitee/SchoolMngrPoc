import { Component } from '@angular/core';

import { AuthenticationService } from './_services';
import { User, RolesEnum } from './_models';

@Component({ selector: 'app', templateUrl: 'app.component.html' })
export class AppComponent {
    currentUser: User;

    constructor(private authenticationService: AuthenticationService) {
        this.authenticationService.currentUser.subscribe(u => this.currentUser = u);
    }

    get isAdmin() {
        return this.currentUser && this.currentUser.role.id < RolesEnum.SUPERVISOR;
    }

    logout() {
        this.authenticationService.logout();
    }
}
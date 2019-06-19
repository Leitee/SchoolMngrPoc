import { Component, AfterContentInit, OnInit } from '@angular/core';

import { AuthenticationService } from './_services';
import { User, RolesEnum } from './_models';

@Component({ selector: 'app', templateUrl: 'app.component.html' })
export class AppComponent implements OnInit {
    currentUser: User = null;

    constructor(private authenticationService: AuthenticationService) {
        
    }
    ngOnInit(): void {
        this.currentUser = this.authenticationService.currentUserValue;
    }

    get isAdmin() {
        return this.currentUser && this.currentUser.role.id < RolesEnum.SUPERVISOR;
    }

    logout() {
        this.authenticationService.logout();
    }
}
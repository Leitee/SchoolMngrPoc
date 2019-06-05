import { User } from '@/_models';
import { AuthenticationService } from '@/_services';
import { Component } from '@angular/core';

@Component({ templateUrl: 'home.component.html', styleUrls: ['../pages.component.scss'] })
export class HomeComponent {
    currentUser: User;

    constructor(
        private authenticationService: AuthenticationService
    ) {
        this.currentUser = this.authenticationService.currentUserValue;
    }

    ngOnInit() {
        
    }
}
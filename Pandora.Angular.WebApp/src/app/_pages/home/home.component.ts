import { User } from '@/_models';
import { AuthenticationService } from '@/_commons';
import { Component } from '@angular/core';

@Component({ templateUrl: 'home.component.html', styleUrls: ['../pages.component.scss'] })
export class HomeComponent {
    currentUser: any;//TODO: has to be User

    constructor(
        private authenticationService: AuthenticationService
    ) {
        this.currentUser = this.authenticationService.currentUserValue;
    }

    ngOnInit() {
        
    }
}
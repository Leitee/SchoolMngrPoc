import { User } from '@/_models';
import { AccountService, AuthenticationService } from '@/_services';
import { Component } from '@angular/core';
import { first } from 'rxjs/operators';

@Component({ templateUrl: 'home.component.html', styleUrls: ['../pages.component.scss'] })
export class HomeComponent {
    currentUser: User;
    userFromApi: User;

    constructor(
        private userService: AccountService,
        private authenticationService: AuthenticationService
    ) {
        this.currentUser = this.authenticationService.currentUserValue;
    }

    ngOnInit() {
        // this.userService.getUserById(this.currentUser.id).pipe(first()).subscribe(user => {
        //     this.userFromApi = user;
        // });
    }
}
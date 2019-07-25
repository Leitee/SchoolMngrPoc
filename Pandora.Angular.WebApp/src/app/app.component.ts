import { Component, AfterContentChecked } from '@angular/core';
import { User, RolesEnum } from '@/_models';
import { AuthenticationService } from './_commons';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';


@Component({ selector: 'app', templateUrl: 'app.component.html' })
export class AppComponent implements AfterContentChecked {
    currentUser: User;

    constructor(private authenticationService: AuthenticationService, private brkPointOns: BreakpointObserver) {
        brkPointOns.observe([
            Breakpoints.HandsetLandscape,
            Breakpoints.HandsetPortrait
        ]);
    }
    ngAfterContentChecked(): void {
        this.currentUser = this.authenticationService.currentUserValue;
    }

    get isAdmin() {
        return this.currentUser && this.currentUser.role.id < RolesEnum.SUPERVISOR;
    }

    logout() {
        this.authenticationService.logout();
    }
}
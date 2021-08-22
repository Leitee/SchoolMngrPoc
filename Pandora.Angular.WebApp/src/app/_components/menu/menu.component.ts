import { Grade, User } from '@/_models';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs/internal/Observable';
import { AuthenticationService } from '@/_commons';
import { MenuService } from './menu.service';

@Component({
    selector: 'app-menu',
    templateUrl: './menu.component.html',
    styleUrls: ['./menu.component.scss'],
    providers: [MenuService]
})
export class MenuComponent implements OnInit {

    currentUser: User;
    public gradeListAsync: Observable<Array<Grade>>;

    constructor(
        private router: Router,
        private authenticationService: AuthenticationService,
        private schoolSvc: MenuService
    ) {
        this.authenticationService.currentUser.subscribe(u => this.currentUser = u);
    }

    ngOnInit(): void {
        this.gradeListAsync = this.schoolSvc.getAllGrades();
    }

    onSubjectClick(): void {
        this.router.navigate([`enroll`]);
    }

    onGradeSelect(grade: Grade): void {
        this.router.navigate([`grade`], { queryParams: grade });
    }
}

import { Grade } from '@/_models';
import { SchoolService } from '@/_services';
import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';

@Component({
    selector: 'app-menu',
    templateUrl: './menu.component.html',
    styleUrls: ['./menu.component.scss'],
    providers: [SchoolService]
})
export class MenuComponent implements OnInit {

    public gradeListAsync: Observable<Array<Grade>>;

    constructor(private schoolSvc: SchoolService) { }

    ngOnInit(): void {
        this.gradeListAsync = this.schoolSvc.getGrades();

    }
}

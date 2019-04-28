import { Component, OnInit, Input } from '@angular/core';
import { Grade } from '@/_models';
import { Observable } from 'rxjs/internal/Observable';
import { SchoolService } from '@/_services';

@Component({
    selector: 'app-menu',
    templateUrl: './menu.component.html',
    providers: [SchoolService]
    //styleUrls: ['./menu.component.scss']
})
export class MenuComponent implements OnInit {

    public gradeListAsync: Observable<Array<Grade>>;


    constructor(private schoolSvc: SchoolService) { }

    ngOnInit(): void {
        this.gradeListAsync = this.schoolSvc.getGrades();

    }
}

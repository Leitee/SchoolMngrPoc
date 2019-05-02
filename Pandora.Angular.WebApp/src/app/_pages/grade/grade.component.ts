import { Class } from '@/_models';
import { SchoolService } from '@/_services';
import { BreakpointObserver, Breakpoints } from "@angular/cdk/layout";
import { Component, OnInit } from "@angular/core";
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';

@Component({
    templateUrl: './grade.component.html',
    providers: [SchoolService]
})
export class GradeComponent implements OnInit {
    classListSource: Observable<Array<Class>>;



    /** Based on the screen size, switch from standard to one column per row */
    cards = this.breakpointObserver.observe(Breakpoints.Handset).pipe(
        map(({ matches }) => {
            if (matches) {
                return [
                    { title: 'Card 1', cols: 1, rows: 1 },//its like grid css, defines span 4 each collum
                    { title: 'Card 2', cols: 1, rows: 1 },
                    { title: 'Card 3', cols: 1, rows: 1 },
                    { title: 'Card 4', cols: 1, rows: 1 }
                ];
            }

            return [
                { title: 'Card 1', cols: 1, rows: 1 },
                { title: 'Card 2', cols: 1, rows: 1 },
                { title: 'Card 3', cols: 1, rows: 1 },
                { title: 'Card 4', cols: 1, rows: 1 }
            ];
        })
    );

    constructor(private breakpointObserver: BreakpointObserver, private schoolSvc: SchoolService) { }

    ngOnInit(): void {
        this.classListSource = this.schoolSvc.getClassesByGradeId(1);
    }

}
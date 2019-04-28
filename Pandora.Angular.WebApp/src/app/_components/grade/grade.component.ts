import { Component, OnInit } from "@angular/core";
import { Breakpoints, BreakpointObserver } from "@angular/cdk/layout";
import { map } from 'rxjs/operators';

@Component({
    templateUrl: './grade.component.html'
})
export class GradeComponent implements OnInit {

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

    constructor(private breakpointObserver: BreakpointObserver) { }

    ngOnInit(): void {

    }

}
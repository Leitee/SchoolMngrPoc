import { Component, OnInit } from '@angular/core';
import { SchoolService } from '@/_services';

export interface PeriodicElement {
  materia: string;
  position: number;
  primero: number;
  symbol: string;
}

const ELEMENT_DATA: PeriodicElement[] = [
  { position: 1, materia: 'Hydrogen', primero: 1.0079, symbol: 'H' },
  { position: 2, materia: 'Helium', primero: 4.0026, symbol: 'He' },
  { position: 3, materia: 'Lithium', primero: 6.941, symbol: 'Li' },
  { position: 4, materia: 'Beryllium', primero: 9.0122, symbol: 'Be' },
  { position: 5, materia: 'Boron', primero: 10.811, symbol: 'B' },
  { position: 6, materia: 'Carbon', primero: 12.0107, symbol: 'C' },
  { position: 7, materia: 'Nitrogen', primero: 14.0067, symbol: 'N' },
  { position: 8, materia: 'Oxygen', primero: 15.9994, symbol: 'O' },
  { position: 9, materia: 'Fluorine', primero: 18.9984, symbol: 'F' },
  { position: 10, materia: 'Neon', primero: 20.1797, symbol: 'Ne' },
];

@Component({
  selector: 'page-student',
  templateUrl: './student.component.html',
  styleUrls: ['../pages.component.scss'],
  providers: [SchoolService]
})
export class StudentComponent implements OnInit {

  displayedColumns: string[] = ['Materia', 'Primero', 'Segundo', 'Tercero', 'Recuperatorio', 'Final'];
  columnsToDisplay: string[] = this.displayedColumns.slice();
  data: PeriodicElement[] = ELEMENT_DATA;

  constructor(private schoolSvc: SchoolService) { }

  ngOnInit() {

  }

}

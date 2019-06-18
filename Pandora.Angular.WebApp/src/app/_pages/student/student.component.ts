import { Component, OnInit } from '@angular/core';
import { SchoolService, AuthenticationService } from '@/_services';
import { Subject, User } from '@/_models';
import { DataTableDataSource } from '@/_components';
import { map } from 'rxjs/operators';
import { ExamComponent } from '../exam/exam.component';

export interface ExamTableItem {
  materia: string;
  primero: number;
  segundo: number;
  tercero: number;
  recuperatorio: number
  final: number;
}

// const ELEMENT_DATA: ExamTableItem[] = [
//   { position: 1, materia: 'Hydrogen', primero: 1.0079, symbol: 'H' },
//   { position: 2, materia: 'Helium', primero: 4.0026, symbol: 'He' },
//   { position: 3, materia: 'Lithium', primero: 6.941, symbol: 'Li' },
//   { position: 4, materia: 'Beryllium', primero: 9.0122, symbol: 'Be' },
//   { position: 5, materia: 'Boron', primero: 10.811, symbol: 'B' },
//   { position: 6, materia: 'Carbon', primero: 12.0107, symbol: 'C' },
//   { position: 7, materia: 'Nitrogen', primero: 14.0067, symbol: 'N' },
//   { position: 8, materia: 'Oxygen', primero: 15.9994, symbol: 'O' },
//   { position: 9, materia: 'Fluorine', primero: 18.9984, symbol: 'F' },
//   { position: 10, materia: 'Neon', primero: 20.1797, symbol: 'Ne' },
// ];

@Component({
  selector: 'page-student',
  templateUrl: './student.component.html',
  styleUrls: ['../pages.component.scss'],
  providers: [SchoolService]
})
export class StudentComponent implements OnInit {

  displayedColumns: string[] = ['Materia', 'Primero', 'Segundo', 'Tercero', 'Recuperatorio', 'Final'];
  columnsToDisplay: string[] = ['Materia', 'Primero', 'Segundo', 'Tercero', 'Recuperatorio', 'Final'];// this.displayedColumns.slice();
  dataSource: DataTableDataSource<ExamTableItem>;
  currentUser: User;

  constructor(private schoolSvc: SchoolService, private authSvc: AuthenticationService) {
    this.currentUser = authSvc.currentUserValue;
  }

  ngOnInit() {
    this.schoolSvc.getExamsByCurrentStudent(this.currentUser.id)
      .pipe(map(a => {
        let tableResult: ExamTableItem[] = [];
        a.forEach(el => {
          let aux = <ExamTableItem>{
            materia: el.name,
            primero: 1,
            segundo: 2,
            tercero: 3,
            recuperatorio: 4,
            final: 5
          }          
          tableResult.push(aux);
        })
        console.log(tableResult)
        return tableResult;
      })).subscribe(resul => {
        console.log('resul', resul)
        let ver = new DataTableDataSource<ExamTableItem>(resul);
        console.log('ver', ver)
        this.dataSource = ver;
      })      
  }
}

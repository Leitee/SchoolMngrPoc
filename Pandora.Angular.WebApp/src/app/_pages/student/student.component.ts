import { Component, OnInit } from '@angular/core';
import { SubjectService } from '@/_services';
import { User } from '@/_models';
import { DataTableDataSource, DataTableComponent } from '@/_components';
import { map } from 'rxjs/operators';
import { AuthenticationService } from '@/_commons';

export interface ExamTableItem {
  materia: string;
  primero: string;
  segundo: string;
  tercero: string;
  recuperatorio: string
  final: string;
}

@Component({
  selector: 'page-student',
  templateUrl: './student.component.html',
  styleUrls: ['../pages.component.scss'],
  providers: [SubjectService]
})
export class StudentComponent implements OnInit {

  displayedColumns: string[] = ['Materia', 'Primero', 'Segundo', 'Tercero', 'Recuperatorio', 'Final'];
  dataSource: DataTableDataSource<ExamTableItem>;
  currentUser: User;
  table: DataTableComponent;

  constructor(private schoolSvc: SubjectService, private authSvc: AuthenticationService) {
    this.currentUser = authSvc.currentUserValue;
    this.table = new DataTableComponent();
  }

  ngOnInit() {
    this.schoolSvc.getSubjectsByCurrentStudent(this.currentUser.id)
      .pipe(map(a => {
        let tableResult: ExamTableItem[] = [];
        a.forEach(el => {
          let aux = <ExamTableItem>{
            materia: el.name,
            primero: (el.exams[0]) ? el.exams[0].score.toString() : '',
            segundo: (el.exams[1]) ? el.exams[1].score.toString() : '',
            tercero: (el.exams[2]) ? el.exams[2].score.toString() : '',
            recuperatorio: (el.exams[3]) ? el.exams[3].score.toString() : '',
            final: (el.exams[4]) ? el.exams[4].score.toString() : '',
          }          
          tableResult.push(aux);
        })
        return tableResult;
      })).subscribe(resul => {
        let ver = new DataTableDataSource<ExamTableItem>(resul);
        console.log('ver', ver)
        this.dataSource = ver;
        this.table.loadTable(resul);
      })      
  }
}

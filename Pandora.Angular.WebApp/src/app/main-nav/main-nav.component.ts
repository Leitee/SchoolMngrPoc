import { Component } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { SchoolService } from '../services/school.service';
import { Grade } from '../entities/grade.model';
import { Class } from '../entities/class.model';

@Component({
  selector: 'app-main-nav',
  templateUrl: './main-nav.component.html',
  styleUrls: ['./main-nav.component.css'],
  providers: [SchoolService]
})
export class MainNavComponent {

  public gradesList: Array<Grade>;// public sets the privacy for the data from the server
  public classesList: Array<Class>;

  isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset)
    .pipe(
      map(result => result.matches)
    );

  constructor(private breakpointObserver: BreakpointObserver, private schoolSvc: SchoolService) { //schoolSvc es la variable de un seervicio injectado en esta clase
    this.schoolSvc.getGrades().subscribe(//suscribe sirve para suscribirse a la respuesta del server
      (resul) => { //lo que esta entre {} se ejecuta cuando el server retorna un valor. resul es la variable que tiene los datos del server 
        this.gradesList = resul.grades;
      }

    )

  }

  public onItemClick(gradeId: number) {
    this.schoolSvc.getClassesByGradeId(gradeId).subscribe(
      (resul) => { //lo que esta entre {} se ejecuta cuando el server retorna un valor. resul es la variable que tiene los datos del server 
        this.classesList = resul.classes;
      })
  }
}

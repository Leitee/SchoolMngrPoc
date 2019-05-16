import { Component, OnInit } from '@angular/core';
import { Student, Class } from '@/_models';
import { BreakpointObserver } from '@angular/cdk/layout';
import { SchoolService } from '@/_services';
import { ActivatedRoute } from '@angular/router';
import { Utils } from '@/_commons';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-exam',
  templateUrl: './exam.component.html',
  styleUrls: ['../pages.component.scss'],
  providers: [SchoolService]
})
export class ExamComponent implements OnInit {

  studentListSource: Observable<Array<Student>>;
  class: Class;

  constructor(private breakpointObserver: BreakpointObserver, private schoolSvc: SchoolService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.queryParams
      .subscribe((cl: Class) => {
        this.class = cl;
        this.studentListSource = this.schoolSvc.getStudentsByClassId(cl.id);
      });
  }

  public get util() {
    return Utils;
  }

}

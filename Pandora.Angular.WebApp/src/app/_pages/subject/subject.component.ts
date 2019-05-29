import { Component, OnInit } from '@angular/core';
import { Utils } from '@/_commons';
import { SchoolService } from '@/_services';
import { Observable } from 'rxjs';
import { Subject } from '@/_models';
import { Router } from '@angular/router';

@Component({
  selector: 'app-subject',
  templateUrl: './subject.component.html',
  styleUrls: ['../pages.component.scss'],
  providers: [SchoolService]
})
export class SubjectComponent implements OnInit {
  subjectListAsync: Observable<Array<Subject>>;

  constructor(private schoolSvc: SchoolService, private route: Router) { }

  ngOnInit() {
    this.subjectListAsync = this.schoolSvc.getSubjectsByTeacherId(1);
  }

  navigateToExams(subj: Subject)
  {
    console.log("boton", subj)
    this.route.navigate(['exam', subj]);     
  }

  public get util() {
    return Utils;
  }

}

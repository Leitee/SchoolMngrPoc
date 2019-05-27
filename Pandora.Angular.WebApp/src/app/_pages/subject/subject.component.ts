import { Component, OnInit } from '@angular/core';
import { Utils } from '@/_commons';
import { SchoolService } from '@/_services';
import { Observable } from 'rxjs';
import { Subject } from '@/_models';

@Component({
  selector: 'app-subject',
  templateUrl: './subject.component.html',
  styleUrls: ['./subject.component.scss'],
  providers: [SchoolService]
})
export class SubjectComponent implements OnInit {
  subjectListAsync: Observable<Array<Subject>>;

  constructor(private schoolSvc: SchoolService) { }

  ngOnInit() {
    this.subjectListAsync = this.schoolSvc.getSubjectsByTeacherId(100);
  }

  public get util() {
    return Utils;
  }

}

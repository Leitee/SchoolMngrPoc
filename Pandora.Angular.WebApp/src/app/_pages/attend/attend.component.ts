import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { SchoolService } from '@/_services';
import { Subject, Student } from '@/_models';
import { Observable } from 'rxjs';
import { Utils } from '@/_commons';

@Component({
  selector: 'app-attend',
  templateUrl: './attend.component.html',
  styleUrls: ['../pages.component.scss'],
  providers: [SchoolService]
})
export class AttendComponent implements OnInit {

  studentListSource: Observable<Array<Student>>;
  subject: Subject;
  
  constructor(private schoolSvc: SchoolService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.queryParams
      .subscribe((subj: Subject) => {
        this.subject = subj;
        this.studentListSource = this.schoolSvc.getStudentsAttendsBySubjectId(subj.id);
      });
  }

  public get util() {
    return Utils;
  }
}

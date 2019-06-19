import { Component, OnInit } from '@angular/core';
import { Utils } from '@/_commons';
import { SchoolService, AuthenticationService } from '@/_services';
import { Observable } from 'rxjs';
import { Subject, User } from '@/_models';
import { Router } from '@angular/router';

@Component({
  selector: 'page-teacher',
  templateUrl: './teacher.component.html',
  styleUrls: ['../pages.component.scss'],
  providers: [SchoolService]
})
export class TeacherComponent implements OnInit {
  subjectListAsync: Observable<Array<Subject>>;
  currentUser: User;

  constructor(private schoolSvc: SchoolService, private route: Router, private authSvc: AuthenticationService) {
    this.currentUser = authSvc.currentUserValue;
   }

  ngOnInit() {
    this.subjectListAsync = this.schoolSvc.getSubjectsByTeacherId(this.currentUser.id);
  }

  navigateToExams(subj: Subject)
  {
    this.route.navigate(['exam', subj]);     
  }

  public get util() {
    return Utils;
  }

}

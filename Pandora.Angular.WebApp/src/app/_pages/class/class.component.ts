import { Component, OnInit } from '@angular/core';
import { Student, Class } from '@/_models';
import { BreakpointObserver } from '@angular/cdk/layout';
import { SchoolService } from '@/_services';
import { ActivatedRoute } from '@angular/router';
import { Utils } from '@/_commons';

@Component({
  selector: 'app-class',
  templateUrl: './class.component.html',
  styleUrls: ['../pages.component.scss'],
  providers: [SchoolService]
})
export class ClassComponent implements OnInit {

  students = [{},{},{},{}];
  class: Class;

  constructor(private breakpointObserver: BreakpointObserver, private schoolSvc: SchoolService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.queryParams
        .subscribe((cl: Class) => {
            this.class = cl;
            //this.classListSource = this.schoolSvc.getClassesByGradeId(cl.id);
        });
}

public get util() {
  return Utils;
}

}

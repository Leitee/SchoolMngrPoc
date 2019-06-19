import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { SchoolService } from '@/_services';
import { Subject, Student } from '@/_models';
import { Utils } from '@/_commons';
import { FormBuilder, FormGroup, FormArray, Validators } from '@angular/forms';

@Component({
  selector: 'app-attend',
  templateUrl: './attend.component.html',
  styleUrls: ['../pages.component.scss'],
  providers: [SchoolService]
})
export class AttendComponent implements OnInit {

  studentListSource: Array<Student>;
  subject: Subject;
  date = new Date();

  groupFrom: FormGroup;

  arrayItems: {
    id: number;
    title: string;
  }[];

  constructor(private schoolSvc: SchoolService, private route: ActivatedRoute, private formBuilder: FormBuilder) {
    this.groupFrom = this.formBuilder.group({
      arrayForm: this.formBuilder.array([])
    });
  }

  ngOnInit(): void {
    this.arrayItems = [];

    this.route.queryParams
      .subscribe((subj: Subject) => {
        this.subject = subj;
        this.schoolSvc.getStudentsAttendsBySubjectId(subj.id).subscribe(resul => {
          this.createArrayFormControl(resul.length);
          this.studentListSource = resul;
        })
      });
  }

  createArrayFormControl(count: number){
    for (let index = 0; index < count; index++) {
      this.arrayForm.push(this.formBuilder.group({
        valud: [false, Validators.required],
        obs: ['', Validators.required]
      }));     
    }
    console.log(this.arrayForm)
  }

  public get util() {
    return Utils;
  }

  public get arrayForm() {
    return this.groupFrom.get('arrayForm') as FormArray;
  }

  onSaveAttends(studs: Student[]) {
    console.log(studs, this.arrayForm)
  }
}

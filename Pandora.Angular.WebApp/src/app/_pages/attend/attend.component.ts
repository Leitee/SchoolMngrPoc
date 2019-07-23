import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { StudentService } from '@/_services';
import { Subject, Student } from '@/_models';
import { Utils } from '@/_commons';
import { FormBuilder, FormGroup, FormArray, Validators, FormControl } from '@angular/forms';

@Component({
  selector: 'app-attend',
  templateUrl: './attend.component.html',
  styleUrls: ['../pages.component.scss'],
  providers: [StudentService]
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

  constructor(
    private schoolSvc: StudentService,
    private route: ActivatedRoute,
    private formBuilder: FormBuilder
  ) {
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
          this.createArrayFormControl(resul);
          this.studentListSource = resul;
        })
      });
  }

  createArrayFormControl(studs: Student[]) {

    studs.forEach(stud => {
      this.getArrayForm.push(this.formBuilder.group({
        studId: new FormControl(stud.id),
        choice: ['', Validators.required],
        obs: ['']
      }));
    });
  }

  public get util() {
    return Utils;
  }

  public get getArrayForm() {
    return this.groupFrom.get('arrayForm') as FormArray;
  }

  onSaveAttends() {
    this.getArrayForm.controls.forEach(ctrl => {
      
    });
  }
}

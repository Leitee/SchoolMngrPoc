import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { StudentService, SubjectService } from '@/_services';
import { Subject, Student, Attend } from '@/_models';
import { Utils } from '@/_commons';
import { FormBuilder, FormGroup, FormArray, Validators, FormControl } from '@angular/forms';

@Component({
  selector: 'app-attend',
  templateUrl: './attend.component.html',
  styleUrls: ['../pages.component.scss'],
  providers: [StudentService, SubjectService]
})
export class AttendComponent implements OnInit {

  date = Date();
  studentListSource: Array<Student>;
  subject: Subject;
  groupFrom: FormGroup;

  constructor(
    private studSvc: StudentService,
    private subjSvc: SubjectService,
    private route: ActivatedRoute,
    private router: Router,
    private formBuilder: FormBuilder
  ) {
    this.groupFrom = this.formBuilder.group({
      arrayForm: this.formBuilder.array([])
    });
  }

  ngOnInit(): void {
    this.route.queryParams
      .subscribe((subj: Subject) => {
        this.subject = subj;
        this.studSvc.getStudentsAttendsBySubjectId(subj.id).subscribe(resul => {
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
    let studList: Student[] = [];
    this.getArrayForm.controls.forEach(ctrl => {
      let attend = {
        attendance: ctrl.value.choice,
        obs: ctrl.value.obs
      } as Attend;

      let student = {
        id: ctrl.value.studId,
        todayAttend: attend,
      } as Student;

      studList.push(student);
    });

    this.subjSvc.saveAttendsBySubject(this.subject.id, studList)
      .subscribe(resp => {
        if (resp) {
          this.router.navigate(['/']);
        }
      }
    )
  }
}

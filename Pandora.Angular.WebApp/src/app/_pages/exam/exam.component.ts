import { Component, OnInit } from '@angular/core';
import { Student, Subject, Exam, ExamTypeEnum } from '@/_models';
import { SubjectService, StudentService } from '@/_services';
import { ActivatedRoute, Router } from '@angular/router';
import { Utils } from '@/_commons';
import { Observable } from 'rxjs';
import { FormGroup, FormBuilder, FormArray, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-exam',
  templateUrl: './exam.component.html',
  styleUrls: ['../pages.component.scss'],
  providers: [SubjectService, StudentService]
})
export class ExamComponent implements OnInit {

  studentListSourceAsync: Observable<Array<Student>>;
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
    this.route.queryParams.subscribe((subj: Subject) => {
      this.subject = subj;
      this.studentListSourceAsync = this.studSvc.getStudentsExamsBySubjectId(subj.id);
    });

    this.studentListSourceAsync.subscribe(studs => {
      this.createArrayFormControl(studs);
    });
  }

  createArrayFormControl(studs: Student[]) {
    studs.forEach(stud => {
      if (stud.exams) {
        this.getArrayForm.push(this.formBuilder.group({
          studId: new FormControl(stud.id),
          first: new FormControl(this.getScoreByExamType(stud.exams, ExamTypeEnum.FIRST),
            [Validators.max(10), Validators.min(0)]),
          second: new FormControl(this.getScoreByExamType(stud.exams, ExamTypeEnum.SECOND),
            [Validators.max(10), Validators.min(0)]),
          third: new FormControl(this.getScoreByExamType(stud.exams, ExamTypeEnum.THIRD),
            [Validators.max(10), Validators.min(0)]),
          retry: new FormControl(this.getScoreByExamType(stud.exams, ExamTypeEnum.RETRY),
            [Validators.max(10), Validators.min(0)]),
          final: new FormControl(this.getScoreByExamType(stud.exams, ExamTypeEnum.FINAL),
            [Validators.max(10), Validators.min(0)])
        }));
      }
    });
  }

  getScoreByExamType(exams: Exam[], examType: ExamTypeEnum) {
    let exam = exams.find(e => e.examType == examType)
    return exam ? exam.score : '';
  }

  getArrayFormValue(id: number) {
    return this.getArrayForm.controls[id].value;
  }

  onSubmit(value: any) {
    let exams: Exam[] = [];

    if (value.first) {
      exams.push({
        examType: ExamTypeEnum.FIRST,
        score: value.first
      } as Exam)
    }
    if (value.second) {
      exams.push({
        examType: ExamTypeEnum.SECOND,
        score: value.second
      } as Exam)
    }
    if (value.third) {
      exams.push({
        examType: ExamTypeEnum.THIRD,
        score: value.third
      } as Exam)
    }
    if (value.retry) {
      exams.push({
        examType: ExamTypeEnum.RETRY,
        score: value.retry
      } as Exam)
    }
    if (value.final) {
      exams.push({
        examType: ExamTypeEnum.FINAL,
        score: value.final
      } as Exam)
    }

    let student = {
      id: value.studId,
      exams: exams
    } as Student;

    this.subjSvc.saveStudentExams(this.subject.id, student)
      .subscribe(resp => {
        if (resp) {
          this.router.navigate(['/']);
        }
      });
  }

  public get util() {
    return Utils;
  }

  public get getArrayForm() {
    return this.groupFrom.get('arrayForm') as FormArray;
  }

}

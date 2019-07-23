import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { Observable } from 'rxjs';
import { Subject, User } from '@/_models';
import { SubjectService, StudentService } from '@/_services';
import { MatIconRegistry } from '@angular/material';
import { DomSanitizer } from '@angular/platform-browser';
import { Router } from '@angular/router';
import { AuthenticationService } from '@/_commons';

@Component({
  selector: 'app-enroll',
  templateUrl: './enroll.component.html',
  styleUrls: ['../pages.component.scss'],
  providers: [SubjectService, StudentService]
})
export class EnrollComponent implements OnInit { 

  firstFormGroup: FormGroup;
  secondFormGroup: FormGroup;
  subjectsListAsync: Observable<Array<Subject>>;
  available: boolean;
  currentUser: User;

  constructor(private _formBuilder: FormBuilder, 
    private studSvc: StudentService, 
    private subjSvc: SubjectService, 
    iconRegistry: MatIconRegistry, 
    sanitizer: DomSanitizer, 
    private authSvc: AuthenticationService,
    private router : Router) {
    this.currentUser = authSvc.currentUserValue;

    iconRegistry.addSvgIcon(
      'check_circle',
      sanitizer.bypassSecurityTrustResourceUrl('assets/img/check_circle.svg'));
    iconRegistry.addSvgIcon(
      'highlight_off',
      sanitizer.bypassSecurityTrustResourceUrl('assets/img/highlight_off.svg'));
  }

  ngOnInit() {
    this.firstFormGroup = this._formBuilder.group({
      firstCtrl: ['', Validators.required]
    });
    this.secondFormGroup = this._formBuilder.group({
      secondCtrl: ['', Validators.required]
    });

    this.subjectsListAsync = this.subjSvc.getAllSubbjects();
    this.firstFormGroup.valueChanges.subscribe(() => {
      //TODO: create an as-you-type filter
    });
  }

  onConfirmar() {
    this.studSvc.enrollStudent(this.selectedSubject.id, this.currentUser.id).subscribe(resul => {
      if (resul) {
        this.router.navigate(['/']);
        //TODO: show confirmation pop up
      }
      else {
        //show error msg
      }
    });
  }

  selectionChange(event) {
    if (event.selectedIndex === 0) {
      this.available = undefined;
    }
    if (event.selectedIndex === 1) {
      this.studSvc.tryEnrollStudent(this.selectedSubject.id, this.currentUser.id).subscribe(resul => {
        this.available = resul;
        if (this.available) {
          this.secondFormGroup.setValue({
            secondCtrl: new FormControl()
          });
        }
        else {
          this.secondFormGroup.setErrors({ error: true });
        }
      });
    }
  }

  displayFn(subj?: Subject): string | undefined {
    return subj ? subj.name : undefined;
  }

  // convenience getter for easy access to form fields
  get selectedSubject(): Subject { return this.firstFormGroup.controls['firstCtrl'].value; }

}

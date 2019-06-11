import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { Subject } from '@/_models';
import { SchoolService } from '@/_services';
import { startWith, map } from 'rxjs/operators';
import { MatIconRegistry } from '@angular/material';
import { DomSanitizer } from '@angular/platform-browser';

@Component({
  selector: 'app-enroll',
  templateUrl: './enroll.component.html',
  styleUrls: ['../pages.component.scss'],
  providers: [SchoolService]
})
export class EnrollComponent implements OnInit {

  firstFormGroup: FormGroup;
  secondFormGroup: FormGroup;
  subjectsListAsync: Observable<Array<Subject>>;
  available: boolean = false;

  constructor(private _formBuilder: FormBuilder, private schoolSvc: SchoolService, iconRegistry: MatIconRegistry, sanitizer: DomSanitizer) {

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

    this.subjectsListAsync = this.schoolSvc.getAll<Subject>("subjects");
    this.firstFormGroup.valueChanges.subscribe(() => {
      //TODO: create an as you type filter
    });
  }

  onConfirmar() {

  }

  selectionChange(event) {
    console.log(this.secondFormGroup);
    if (event.selectedIndex === 1) {
      this.available = true;
      this.secondFormGroup.setValue({
        secondCtrl: [true, Validators.required]
      })
    }
  }

  displayFn(subj?: Subject): string | undefined {
    return subj ? subj.name : undefined;
  }

}

import { Injectable } from '@angular/core';
import { ApiBaseService } from '@/_commons';
import { Class, Grade } from '@/_models';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class MenuService extends ApiBaseService<Class> {

    constructor(http: HttpClient) {
        super(http);
    }

    public getAllGrades(): Observable<Grade[]> {
        this.path = "grades";
        return this.getAll();
    }

    public getClassesByGradeId(gradeId: number): Observable<Class[]> {
        this.path = "classes/GetByGrade";
        return null; // this.getById(gradeId);
    }
}
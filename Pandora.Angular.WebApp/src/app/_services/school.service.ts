import { Grade, Class } from "@/_models";
import { BaseService } from "@/_services";
import { HttpClient } from '@angular/common/http';
import { Injectable } from "@angular/core";
import { Observable } from 'rxjs';
import { map } from "rxjs/operators";

@Injectable()
export class SchoolService extends BaseService {

    constructor(http: HttpClient) {
        super(http);
    }
    
    public getGrades(): Observable<Grade[]> {
        this.path = "grades";
        return this.get<Grade>();
    }

    public getClassesByGradeId(gradeId: number): Observable<Class[]> {
        this.path = "classes";
        return this.getById<Class[]>(gradeId);
    }
}
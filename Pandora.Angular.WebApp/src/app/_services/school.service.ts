import { Grade } from "@/_models";
import { BaseService } from "@/_services";
import { HttpClient } from '@angular/common/http';
import { Injectable } from "@angular/core";
import { Observable } from 'rxjs';

@Injectable()
export class SchoolService extends BaseService {

    constructor(http: HttpClient) {
        super(http);
    }

    public getGrades() {
        return super.get<Grade>();
    }

    public getClassesByGradeId(gradeId: number) {
        return this.getById<Grade>(gradeId);
    }
}
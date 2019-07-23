import { Subject } from "@/_models";
import { HttpClient } from '@angular/common/http';
import { Injectable } from "@angular/core";
import { Observable } from 'rxjs';
import { ApiBaseService } from '@/_commons';

@Injectable()
export class SubjectService extends ApiBaseService<Subject> {

    constructor(http: HttpClient) {
        super(http);
    }

    public getAllSubbjects(): Observable<Array<Subject>> {
        this.path = "subject";
        return this.getAll();
    }

    public getSubjectsByTeacherId(teacherId: number): Observable<Subject[]> {
        this.path = "subjects/GetByTeacher";
        return this.getListById(teacherId);
    }

    public getExamsByCurrentStudent(userId: number): Observable<Subject[]> {
        this.path = "subjects/GetByStudent";
        return this.getListById(userId);
    }
}
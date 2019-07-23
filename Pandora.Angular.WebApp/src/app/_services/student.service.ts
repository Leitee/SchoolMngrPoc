import { Student } from "@/_models";
import { HttpClient } from '@angular/common/http';
import { Injectable } from "@angular/core";
import { Observable } from 'rxjs';
import { ApiBaseService } from '../_commons/api/api-base.service';

@Injectable()
export class StudentService extends ApiBaseService<Student> {

    constructor(http: HttpClient) {
        super(http);
    }

    public getAllStudents(): Observable<Array<Student>> {
        this.path = "student";
        return this.getAll();
    }

    public getStudentsExamsBySubjectId(classId: number): Observable<Student[]> {
        this.path = "students/GetExamsBySubject";
        return this.getListById(classId);
    }

    public getStudentsAttendsBySubjectId(classId: number): Observable<Student[]> {
        this.path = "students/GetAttendsBySubject";
        return this.getListById(classId);
    }

    public tryEnrollStudent(subjectId: number, studentId: number): Observable<boolean> {
        this.path = "subjects/TryEnroll";
        return null; // this.put(subjectId, {studentId: studentId});
    }
    public enrollStudent(subjectId: number, studentId: number): Observable<boolean> {
        this.path = "subjects/EnrollStudent";
        return null; // this.put(subjectId, studentId);
    }
}
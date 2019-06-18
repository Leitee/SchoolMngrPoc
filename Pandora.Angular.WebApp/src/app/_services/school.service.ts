import { Grade, Class, Student, Subject } from "@/_models";
import { HttpClient } from '@angular/common/http';
import { Injectable } from "@angular/core";
import { Observable } from 'rxjs';
import { BaseService } from './base.service';

@Injectable()
export class SchoolService extends BaseService {

    constructor(http: HttpClient) {
        super(http);
    }

    public getAll<TEntiy>(urlSuffix: string): Observable<Array<TEntiy>> {
        this.path = urlSuffix;
        return this.get<TEntiy>();
    }

    public getGrades(): Observable<Grade[]> {
        this.path = "grades";
        return this.get<Grade>();
    }

    public getClassesByGradeId(gradeId: number): Observable<Class[]> {
        this.path = "classes/GetByGrade";
        return this.getById<Class[]>(gradeId);
    }

    public getSubjectsByTeacherId(teacherId: number): Observable<Subject[]> {
        this.path = "subjects/GetByTeacher";
        return this.getById<Subject[]>(teacherId);
    }

    public getStudentsExamsBySubjectId(classId: number): Observable<Student[]> {
        this.path = "students/GetExamsBySubject";
        return this.getById<Student[]>(classId);
    }

    public getExamsByCurrentStudent(userId: number): Observable<Subject[]> {
        this.path = "subjects/GetByStudent";
        return this.getById<Subject[]>(userId);
    }

    public getStudentsAttendsBySubjectId(classId: number): Observable<Student[]> {
        this.path = "students/GetAttendsBySubject";
        return this.getById<Student[]>(classId);
    }

    public tryEnrollStudent(subjectId: number, studentId: number): Observable<boolean> {
        this.path = "subjects/TryEnroll";
        return this.put<boolean>(subjectId, studentId);
    }
    public enrollStudent(subjectId: number, studentId: number): Observable<boolean> {
        this.path = "subjects/EnrollStudent";
        return this.put<boolean>(subjectId, studentId);
    }
}
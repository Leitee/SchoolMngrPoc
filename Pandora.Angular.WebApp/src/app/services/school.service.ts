import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class SchoolService
{
    constructor(private http: HttpClient) // it's a special kind of method that is fired when u invoke the class.
    {

    }

    public getGrades() : Observable<any>//public es el modificador de acceso. Array<Grades> estamos condicionando el tipo de la raespuesta
    {   
        let headerReq = new HttpHeaders({'Content-Type': 'application/json'});// se cofiguta el header del request para que el resultado sea del tipo json 
        let response = this.http.get("http://localhost:3000/api/v1/grades", {headers: headerReq} );// get es el metodo que usamos para llamar al server, no tiene body
        
        return response;
    }

    public getClassesByGradeId( gradeId:number) : Observable<any>//public es el modificador de acceso. Array<Grades> esta condicionando el tipo de la raespuesta
    {   
        let headerReq = new HttpHeaders({'Content-Type': 'application/json'});// se cofiguta el header del request para que el resultado sea del tipo json 
        let response = this.http.get("http://localhost:3000/api/v1/classes/" + gradeId, {headers: headerReq} );// get es el metodo que usamos para llamar al server, no tiene body
        
        return response;
    }
  
}
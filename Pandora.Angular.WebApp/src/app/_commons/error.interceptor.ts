import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor, HttpErrorResponse, HttpResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { ApiResponse } from "@/_commons";

import { AuthenticationService } from '@/_services/authentication.service';
import { DialogService } from '@/_services/dialog.service';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
    constructor(private authenticationService: AuthenticationService, private dialogService: DialogService) { }

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        return next.handle(request).pipe(
            map((event: HttpEvent<ApiResponse<any>>) => {
                if (event instanceof HttpResponse) {
                    if (event.body.hasError)
                    {
                        let data = {title: "Error", message: "Ocurrio un error en el servidor."};
                        this.dialogService.openErrorDialog(data);                     
                    }

                    if ([204].indexOf(event.body.responseCode) !== -1) {
                        let data = {title: "Error", message: "No hay resultados."};
                        this.dialogService.openErrorDialog(data);
                    }
                }
                return event;
            }),
            catchError((err: HttpErrorResponse) => {
                if ([401, 403].indexOf(err.status) !== -1) {
                    // auto logout if 401 Unauthorized or 403 Forbidden response returned from api
                    this.authenticationService.logout();
                    location.reload(true);
                }
                
                console.error(err)

                let data = {title: "Error", message: "No hay conexion con el servidor."};
                this.dialogService.openErrorDialog(data);
                
                const errorMsg = err.error.message || err.statusText;
                return throwError(errorMsg);
            })
        )
    }
}
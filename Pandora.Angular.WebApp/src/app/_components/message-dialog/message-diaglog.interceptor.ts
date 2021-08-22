import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor, HttpErrorResponse, HttpResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { ApiResponse } from "@/_commons";
import { DialogService } from './message-dialog.service';

@Injectable()
export class MessageDialogInterceptor implements HttpInterceptor {
    constructor(private dialogService: DialogService) { }

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        return next.handle(request).pipe(
            map((event: HttpEvent<ApiResponse<any>>) => {
                if (event instanceof HttpResponse) {
                    if (event.body.hasError) {
                        let message = event.body.errors.join('\n');
                        this.dialogService.openErrorDialog(message);
                    }

                    if ([204].indexOf(event.body.responseCode) !== -1) {
                        let message = "No hay resultados para mostrar.";
                        this.dialogService.openErrorDialog(message);
                    }
                }
                return event;
            }),
            catchError((err: HttpErrorResponse) => {
                let message: string;
                if ([401, 403].indexOf(err.status) !== -1) {
                    // auto logout if 401 Unauthorized or 403 Forbidden response returned from api
                    message = "Necesita iniciar sesión para realizar esta acción.";
                }
                else if ([500].indexOf(err.status) !== -1) {
                    message = "Ocurrio un error en el servidor.";
                }
                else {
                    message = "No hay conexion con el servidor.";
                }

                this.dialogService.openErrorDialog(message);
                console.error(err)

                const errorMsg = err.error.message || err.statusText;
                return throwError(errorMsg);
            })
        )
    }
}
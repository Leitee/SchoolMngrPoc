import { Injectable } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material';
import { DialogData, DialogIconEnum } from './message-dialog.model';
import { Observable } from 'rxjs';
import { MessageDialogComponent } from './message-dialog.component';

@Injectable({ providedIn: 'root' })
export class DialogService {

    constructor(public dialog: MatDialog) { }

    openErrorDialog(msg: string): void {

        let data: DialogData = { title: "Error", message: msg, icon: DialogIconEnum.ERROR };

        this.dialog.open(MessageDialogComponent, {
            width: '300px',
            data: data
        });
    }

    openQuestionDialog(msg: string): Observable<boolean> {
        let data: DialogData = { title: "Atención", message: msg, icon: DialogIconEnum.WARN };

        let dialogRef: MatDialogRef<MessageDialogComponent, boolean>;
        dialogRef = this.dialog.open(MessageDialogComponent, {
            width: '500px',
            data: data
        });

        return dialogRef.afterClosed();
    }
}
import { Injectable } from '@angular/core';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { ErrorDialogComponent } from '@/_components';
import { DialogData } from '@/_models';

@Injectable({ providedIn: 'root' })
export class DialogService {

    constructor(public dialog: MatDialog) { }
    openErrorDialog(data: DialogData): void {
        let dialogRef: MatDialogRef<ErrorDialogComponent, DialogData>;
        dialogRef = this.dialog.open(ErrorDialogComponent, {
            width: '300px',
            data: data
        });

        dialogRef.afterClosed().subscribe(result => {
            console.log('The dialog was closed');
            let animal;
            animal = result;
        });
    }
}
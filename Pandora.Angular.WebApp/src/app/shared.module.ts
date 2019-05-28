import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { MaterialModule } from './material.module';
import { MenuComponent, ErrorDialogComponent, ContentWrapperComponent } from './_components';

@NgModule({
  entryComponents: [ErrorDialogComponent],
  declarations: [
    MenuComponent,
    ContentWrapperComponent,
    ErrorDialogComponent
  ],
  imports: [
    CommonModule,
    MaterialModule
  ],
  exports: [
    CommonModule,
    MaterialModule,
    MenuComponent,
    ContentWrapperComponent
  ]
})
export class SharedModule { }

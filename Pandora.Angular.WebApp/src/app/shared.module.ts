import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { MaterialModule } from './material.module';
import { MenuComponent, ErrorDialogComponent, ContentWrapperComponent, LoaderComponent } from './_components';

@NgModule({
  entryComponents: [ErrorDialogComponent],
  declarations: [
    MenuComponent,
    ContentWrapperComponent,
    ErrorDialogComponent,
    LoaderComponent
  ],
  imports: [
    CommonModule,
    MaterialModule
  ],
  exports: [
    CommonModule,
    MaterialModule,
    MenuComponent,
    ContentWrapperComponent,
    LoaderComponent
  ]
})
export class SharedModule { }

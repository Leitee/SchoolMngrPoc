import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { MaterialModule } from './material.module';
import { MenuComponent } from './_components';
import { ContentWrapperComponent } from './_components/content-wrapper/content-wrapper.component';

@NgModule({
  declarations: [
    MenuComponent,
    ContentWrapperComponent
  ],
  imports: [
    CommonModule,
    MaterialModule  
  ],
  exports: [
    CommonModule,
    MaterialModule,
    MenuComponent,
    ContentWrapperComponent]
})
export class SharedModule { }

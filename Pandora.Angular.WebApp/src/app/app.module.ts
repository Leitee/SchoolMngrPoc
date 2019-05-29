import { AppComponent } from '@/app.component';
import { routing } from '@/app.routing';
import { SharedModule } from '@/shared.module';
import { ErrorInterceptor, JwtInterceptor } from '@/_commons';
import { AdminComponent, HomeComponent, GradeComponent, ExamComponent, SubjectComponent } from '@/_pages';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LoaderInterceptor } from './_commons/loader.interceptor';
import { AttendComponent } from './_pages/attend/attend.component';

@NgModule({
    imports: [
        BrowserModule,
        ReactiveFormsModule,
        HttpClientModule,
        routing,
        BrowserAnimationsModule,
        SharedModule
    ],
    declarations: [
        AppComponent,
        HomeComponent,
        AdminComponent,
        SubjectComponent,
        GradeComponent,
        ExamComponent,
        AttendComponent
    ],
    providers: [
        { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
        { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
        { provide: HTTP_INTERCEPTORS, useClass: LoaderInterceptor, multi: true }
    ],
    bootstrap: [AppComponent]
})

export class AppModule { }
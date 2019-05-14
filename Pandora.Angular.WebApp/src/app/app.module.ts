import { AppComponent } from '@/app.component';
import { routing } from '@/app.routing';
import { SharedModule } from '@/shared.module';
import { ErrorInterceptor, JwtInterceptor } from '@/_commons';
import { AdminComponent, HomeComponent, GradeComponent } from '@/_pages';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ClassComponent } from './_pages/class/class.component';

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
        GradeComponent,
        ClassComponent
    ],
    providers: [
        { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
        { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
    ],
    bootstrap: [AppComponent]
})

export class AppModule { }
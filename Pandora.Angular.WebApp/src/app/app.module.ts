import { AppComponent } from '@/app.component';
import { routing } from '@/app.routing';
import { SharedModule } from '@/shared.module';
import { JwtInterceptor, AppConfigService } from '@/_commons';
import { AdminComponent, HomeComponent, GradeComponent, ExamComponent, AttendComponent, TeacherComponent, StudentComponent } from '@/_pages';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule, APP_INITIALIZER } from '@angular/core';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { EnrollComponent } from './_pages/enroll/enroll.component';
import { LoaderInterceptor, MessageDialogInterceptor } from './_components';
;

export function initConfig(config: AppConfigService) {
    return () => config.load();
}

@NgModule({
    imports: [
        BrowserModule,
        ReactiveFormsModule,
        FormsModule,
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
        ExamComponent,
        AttendComponent,
        TeacherComponent,
        StudentComponent,
        EnrollComponent
    ],
    providers: [
        AppConfigService,
        {
            provide: APP_INITIALIZER,
            useFactory: initConfig,
            deps: [AppConfigService],
            multi: true
        },
        { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
        { provide: HTTP_INTERCEPTORS, useClass: MessageDialogInterceptor, multi: true },
        { provide: HTTP_INTERCEPTORS, useClass: LoaderInterceptor, multi: true }
    ],
    bootstrap: [AppComponent]
})

export class AppModule { }
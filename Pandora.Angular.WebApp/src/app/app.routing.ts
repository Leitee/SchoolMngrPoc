import { AuthGuard } from '@/_commons';
import { RolesEnum } from '@/_models';
import { AdminComponent, HomeComponent, GradeComponent, ExamComponent, TeacherComponent, AttendComponent, StudentComponent } from '@/_pages';
import { RouterModule, Routes } from '@angular/router';
import { EnrollComponent } from './_pages/enroll/enroll.component';

const appRoutes: Routes = [
    {
        path: '', pathMatch: 'full',
        component: HomeComponent,
        canActivate: [AuthGuard]
    },
    {
        path: 'admin',
        component: AdminComponent,
        canActivate: [AuthGuard],
        data: { roles: [RolesEnum.DEBUG, RolesEnum.ADMINISTRADOR] }
    },
    {
        path: 'grade',
        component: GradeComponent,
        canActivate: [AuthGuard],
        data: { roles: [RolesEnum.DEBUG, RolesEnum.ADMINISTRADOR] }
    },
    {
        path: 'exam',
        component: ExamComponent,
        canActivate: [AuthGuard],
        data: { roles: [RolesEnum.DEBUG, RolesEnum.TEACHER] }
    },
    {
        path: 'attend',
        component: AttendComponent,
        canActivate: [AuthGuard],
        data: { roles: [RolesEnum.DEBUG, RolesEnum.TEACHER] }
    },
    {
        path: 'teacher',
        component: TeacherComponent,
        canActivate: [AuthGuard],
        data: { roles: [RolesEnum.DEBUG, RolesEnum.TEACHER] }
    },
    {
        path: 'enroll',
        component: EnrollComponent,
        canActivate: [AuthGuard],
        data: { roles: [RolesEnum.DEBUG, RolesEnum.STUDENT] }
    },
    {
        path: 'student',
        component: StudentComponent,
        canActivate: [AuthGuard],
        data: { roles: [RolesEnum.DEBUG, RolesEnum.STUDENT] }
    },
    {
        path: 'auth',
        loadChildren: () => import('./_auth/auth.module').then(m => m.AuthModule)
    },

    // otherwise redirect to home
    { path: '**', redirectTo: '' }
];

export const routing = RouterModule.forRoot(appRoutes);
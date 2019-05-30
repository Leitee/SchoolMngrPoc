import { AuthGuard } from '@/_commons';
import { RolesEnum } from '@/_models';
import { AdminComponent, HomeComponent, GradeComponent, ExamComponent, SubjectComponent } from '@/_pages';
import { RouterModule, Routes } from '@angular/router';
import { AttendComponent } from './_pages/attend/attend.component';

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
        canActivate: [AuthGuard]
    },
    {
        path: 'attend',
        component: AttendComponent,
        canActivate: [AuthGuard]
    },
    {
        path: 'subject',
        component: SubjectComponent,
        canActivate: [AuthGuard]
    },
    {
        path: 'auth',
        loadChildren: () => import('./_auth/auth.module').then(m => m.AuthModule)
    },

    // otherwise redirect to home
    { path: '**', redirectTo: '' }
];

export const routing = RouterModule.forRoot(appRoutes);
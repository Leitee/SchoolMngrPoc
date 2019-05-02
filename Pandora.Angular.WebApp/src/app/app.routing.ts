import { AuthGuard } from '@/_commons';
import { RolesEnum } from '@/_models';
import { AdminComponent, HomeComponent } from '@/_pages';
import { RouterModule, Routes } from '@angular/router';

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
        path: 'auth',
        loadChildren: './_auth/auth.module#AuthModule'//lazy loading
    },

    // otherwise redirect to home
    { path: '**', redirectTo: '' }
];

export const routing = RouterModule.forRoot(appRoutes);
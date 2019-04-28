import { Routes, RouterModule } from '@angular/router';

import { LoginComponent } from './_auth';
import { AuthGuard } from './_guards';
import { RolesEnum } from './_models';
import { HomeComponent, AdminComponent } from './_pages';

const appRoutes: Routes = [
    {
        path: '',
        component: HomeComponent,
        canActivate: [AuthGuard]
    },
    {
        path: 'admin',
        component: AdminComponent,
        canActivate: [AuthGuard],
        data: { roles: [RolesEnum.ADMINISTRADOR] }
    },
    {
        path: 'login',
        component: LoginComponent
    },

    // otherwise redirect to home
    { path: '**', redirectTo: '' }
];

export const routing = RouterModule.forRoot(appRoutes);
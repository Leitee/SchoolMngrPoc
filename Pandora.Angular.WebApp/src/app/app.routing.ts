import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './_components/home';
import { AdminComponent } from './_components/admin';
import { LoginComponent } from './_auth';
import { AuthGuard } from './_guards';
import { Role2 } from './_models';

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
        data: { roles: [Role2.Admin] }
    },
    {
        path: 'login',
        component: LoginComponent
    },

    // otherwise redirect to home
    { path: '**', redirectTo: '' }
];

export const routing = RouterModule.forRoot(appRoutes);
import { AuthGuard } from '@/_commons';
import { RolesEnum } from '@/_models';
import { AdminComponent, HomeComponent, GradeComponent } from '@/_pages';
import { RouterModule } from '@angular/router';
var appRoutes = [
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
        path: 'grade/:id',
        component: GradeComponent,
        canActivate: [AuthGuard]
    },
    {
        path: 'auth',
        loadChildren: './_auth/auth.module#AuthModule' //lazy loading
    },
    // otherwise redirect to home
    { path: '**', redirectTo: '' }
];
export var routing = RouterModule.forRoot(appRoutes);
//# sourceMappingURL=app.routing.js.map
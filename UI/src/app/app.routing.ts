import { Routes, RouterModule } from '@angular/router';

import { AuthGuard } from './_guards';
import { HomeComponent } from './home';
import { LoginComponent } from './login';
import { PolicyComponent } from './policy';

const appRoutes: Routes = [
    { path: '', component: HomeComponent, canActivate: [AuthGuard] },
    { path: 'login', component: LoginComponent },
    { path: 'policy', component: PolicyComponent, canActivate: [AuthGuard] },
    { path: '**', redirectTo: '' }
];

export const routing = RouterModule.forRoot(appRoutes);
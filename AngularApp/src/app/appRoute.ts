import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './home/login/login.component';
import { RegisterComponent } from './home/register/register.component';
import { ForgetComponent } from './home/forget/forget.component';
import { AccountComponent } from './account/account.component';
import { DashboardComponent } from './account/dashboard/dashboard.component';

export class appRoute {
    static globalRoutes: Routes = [
        {
            path: 'home', children: [
                { path: 'login', component: LoginComponent },
                { path: 'register', component: RegisterComponent },
                { path: 'forget', component: ForgetComponent }
            ]
        },
        {
            path: 'account', component: AccountComponent, children: [
                { path: 'dashboard', component: DashboardComponent }
            ]
        },
        { path: '', redirectTo: '/home', pathMatch: 'full' },
        { path: '**', redirectTo: '/home', pathMatch: 'full' }
    ]
}
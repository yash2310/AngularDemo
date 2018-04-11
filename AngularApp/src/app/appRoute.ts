import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './home/login/login.component';
import { RegisterComponent } from './home/register/register.component';
import { ForgetComponent } from './home/forget/forget.component';
import { AccountComponent } from './account/account.component';
import { DashboardComponent } from './account/dashboard/dashboard.component';
import { HomeHeaderComponent } from './home-header/home-header.component';
import { FooterComponent } from './footer/footer.component';
import { AccountHeaderComponent } from './account-header/account-header.component';
import { ReporteesComponent } from './account/reportees/reportees.component';
import { ReporteeGoalComponent } from './account/reportee-goal/reportee-goal.component';

export class appRoute {
    static globalRoutes: Routes = [
        {
            path: 'home', component: HomeComponent, children: [
                { path: 'login', component: LoginComponent },
                { path: 'register', component: RegisterComponent },
                { path: 'forget', component: ForgetComponent },
                { path: '', component: HomeHeaderComponent, outlet: 'headheader' },
                { path: '', component: FooterComponent, outlet: 'headfooter' }
            ]
        },
        {
            path: 'account', component: AccountComponent, children: [
                { path: 'dashboard', component: DashboardComponent },
                { path: 'reportees', component: ReporteesComponent },
                { path: 'reporteegoal', component: ReporteeGoalComponent },
                { path: '', component: AccountHeaderComponent, outlet: 'accountheader' },
                { path: '', component: FooterComponent, outlet: 'accountfooter' }
            ]
        },
        { path: '', redirectTo: '/home', pathMatch: 'full' },
        { path: '**', redirectTo: '/home', pathMatch: 'full' }
    ]
}
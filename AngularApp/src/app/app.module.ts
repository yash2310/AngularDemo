import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { HttpModule } from '@angular/http';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { AccountComponent } from './account/account.component';
import { LoginComponent } from './home/login/login.component';
import { RegisterComponent } from './home/register/register.component';
import { ForgetComponent } from './home/forget/forget.component';
import { DashboardComponent } from './account/dashboard/dashboard.component';
import { ReporteesComponent } from './account/reportees/reportees.component';
import { RouterModule } from '@angular/router';
import { appRoute } from './appRoute';
import { HomeHeaderComponent } from './home-header/home-header.component';
import { FooterComponent } from './footer/footer.component';
import { AccountHeaderComponent } from './account-header/account-header.component';
import { HomeService } from './home/home.service';
import { AccountService } from './account/account.service';
import { ReporteeGoalComponent } from './account/reportee-goal/reportee-goal.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    AccountComponent,
    LoginComponent,
    RegisterComponent,
    ForgetComponent,
    DashboardComponent,
    ReporteesComponent,
    HomeHeaderComponent,
    FooterComponent,
    AccountHeaderComponent,
    ReporteeGoalComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    HttpModule,
    FormsModule,
    NgbModule.forRoot(),
    RouterModule.forRoot(appRoute.globalRoutes),
    ReactiveFormsModule
  ],
  providers: [
    HomeService,
    AccountService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

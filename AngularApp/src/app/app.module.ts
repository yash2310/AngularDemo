import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

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
    AccountHeaderComponent
  ],
  imports: [
    BrowserModule,
    NgbModule.forRoot(),
    RouterModule.forRoot(appRoute.globalRoutes)
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

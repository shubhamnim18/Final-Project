import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { FormsModule } from '@angular/forms';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { AdminComponent } from './admin/admin.component';
import { HeaderComponent } from './admin/header/header.component';
import { SideNavComponent } from './admin/side-nav/side-nav.component';
import { MainComponent } from './admin/main/main.component';
import { ProfileComponent } from './admin/profile/profile.component';
import { ReportComponent } from './admin/report/report.component';
import { ServicesComponent } from './admin/services/services.component';
import { UsersComponent } from './admin/users/users.component';
import { SubscriptionComponent } from './admin/subscription/subscription.component';
import { AddServiceComponent } from './admin/add-service/add-service.component';
@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    LoginComponent,
    AdminComponent,
    HeaderComponent,
    SideNavComponent,
    MainComponent,
    ProfileComponent,
    ReportComponent,
    ServicesComponent,
    UsersComponent,
    SubscriptionComponent,
    AddServiceComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    FontAwesomeModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { HomeComponent } from './home/home.component';
import { AdminComponent } from './admin/admin.component';
import { MainComponent } from './admin/main/main.component';
import { UsersComponent } from './admin/users/users.component';
import { ServicesComponent } from './admin/services/services.component';
import { ReportComponent } from './admin/report/report.component';
import { ProfileComponent } from './admin/profile/profile.component';
import { SubscriptionComponent } from './admin/subscription/subscription.component';

const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: 'admin', redirectTo: 'admin/dashboard', pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  { path: 'home', component: HomeComponent },
  {
    path: 'admin', component: AdminComponent,
    children: [
      { path: 'dashboard', component: MainComponent },
      { path: 'user', component: UsersComponent },
      { path: 'service', component: ServicesComponent },
      { path: 'report', component: ReportComponent },
      { path: 'profile', component: ProfileComponent },
      { path: 'subscription', component: SubscriptionComponent },
    ]
  }


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}

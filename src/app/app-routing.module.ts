import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LandingComponent } from './pages/landing/landing.component';
import { LoginComponent } from './pages/login/login.component';
import { AboutUsComponent } from './pages/about-us/about-us.component';
import { RegisterComponent } from './pages/register/register.component';
import { LastmovementsComponent } from './pages/lastmovements/lastmovements.component';
import { DepositComponent } from './pages/operations/deposit/deposit.component';
import { DrawoutComponent } from './pages/operations/drawout/drawout.component';
import { DashboardComponent } from './pages/dashboard/dashboard.component';


const routes: Routes = [
  {path: 'landing', component: LandingComponent},
  {path: '', redirectTo: '/landing', pathMatch: 'full'},
  {path: 'login', component: LoginComponent},
  {path: 'about-us', component: AboutUsComponent},
  {path: 'register', component: RegisterComponent},
  {path: 'dashboard', component:DashboardComponent,
  children:[
    {path: 'lastmovements', component: LastmovementsComponent},
    {path:'operations/deposit', component: DepositComponent},
    {path:'operations/drawout', component: DrawoutComponent}
  ]},
  // {path: '**', pathMatch: 'full', redirectTo: ''}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

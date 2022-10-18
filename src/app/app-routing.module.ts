import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LandingComponent } from './pages/landing/landing.component';
import { LoginComponent } from './pages/login/login.component';
import { RegisterComponent } from './pages/register/register.component';
import { LastmovementsComponent } from './pages/lastmovements/lastmovements.component';
import { DepositComponent } from './pages/operations/deposit/deposit.component';
import { DrawoutComponent } from './pages/operations/drawout/drawout.component';

const routes: Routes = [
  {path: '', component: LandingComponent},
  {path: 'landing', component: LandingComponent},
  {path: 'login', component: LoginComponent},
  {path: 'register', component: RegisterComponent},
  {path: 'lastmovements', component: LastmovementsComponent},
  {path:'operations/deposit', component: DepositComponent},
  {path:'operations/drawout', component: DrawoutComponent},
  // {path: '**', pathMatch: 'full', redirectTo: ''}
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {useHash: true})],
  exports: [RouterModule]
})
export class AppRoutingModule { }

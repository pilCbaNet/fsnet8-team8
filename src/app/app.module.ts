import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';



import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './layout/header/header.component';
import { FooterComponent } from './layout/footer/footer.component';
import { LandingComponent } from './pages/landing/landing.component';
import { LoginComponent } from './pages/login/login.component';
import { RegisterComponent } from './pages/register/register.component';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { LastmovementsComponent } from './pages/lastmovements/lastmovements.component';
import { OperationsComponent } from './pages/operations/operations.component';
import { DepositComponent } from './pages/operations/deposit/deposit.component';
import { DrawoutComponent } from './pages/operations/drawout/drawout.component';
import { AboutUsComponent } from './pages/about-us/about-us.component';
import { HttpClientModule } from '@angular/common/http';




@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    LandingComponent,
    LoginComponent,
    RegisterComponent,
    LastmovementsComponent,
    OperationsComponent,
    DepositComponent,
    DrawoutComponent,
    AboutUsComponent,
    DashboardComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

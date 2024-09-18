import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { ForgotPasswordComponent } from './forgot-password/forgot-password.component';
import { DangKyThanhCongComponent } from './dang-ky-thanh-cong/dang-ky-thanh-cong.component';
import { KhoiPhucMatKhauComponent } from './khoi-phuc-mat-khau/khoi-phuc-mat-khau.component';

const routes: Routes = [  
  { path: '', redirectTo: '/Login', pathMatch: 'full' },
  {
    path: 'Login', component: LoginComponent,
  }, 
  {
    path: 'Register', component: RegisterComponent,
  }, 
  {
    path: 'ForgotPassword', component: ForgotPasswordComponent,
  }, 
  {
    path: 'DangKyThanhCong', component: DangKyThanhCongComponent,
  }, 
  {
    path: 'KhoiPhucMatKhau', component: KhoiPhucMatKhauComponent,
  }, 
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { useHash: true, initialNavigation: 'enabled' })],
  exports: [RouterModule]
})
export class AppRoutingModule { }


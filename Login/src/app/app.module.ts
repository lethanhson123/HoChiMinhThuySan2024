import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from './material/material.module';
import { CKEditorModule } from 'ngx-ckeditor';
import { NotificationService } from './shared/Notification.service';
import { CookieService } from 'ngx-cookie-service';
import { ChartsModule } from 'ng2-charts';
import { MAT_DATE_LOCALE } from '@angular/material/core';

import { AppComponent } from './app.component';
import { LoadingComponent } from './loading/loading.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { ForgotPasswordComponent } from './forgot-password/forgot-password.component';
import { DangKyThanhCongComponent } from './dang-ky-thanh-cong/dang-ky-thanh-cong.component';
import { KhoiPhucMatKhauComponent } from './khoi-phuc-mat-khau/khoi-phuc-mat-khau.component';


@NgModule({
  declarations: [
    AppComponent,
    LoadingComponent,    
    LoginComponent, RegisterComponent, ForgotPasswordComponent, DangKyThanhCongComponent, KhoiPhucMatKhauComponent   
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'serverApp' }),
    FormsModule,
    HttpClientModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MaterialModule,
    ChartsModule,
    CKEditorModule,
  ],
  providers: [   
    CookieService,  
    NotificationService,
    {provide: MAT_DATE_LOCALE, useValue: 'en-GB'}
  ],
  bootstrap: [AppComponent],
  entryComponents:[]
})
export class AppModule { }

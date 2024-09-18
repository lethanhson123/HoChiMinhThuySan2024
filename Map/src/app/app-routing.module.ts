import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { HomepageComponent } from './homepage/homepage.component';


const routes: Routes = [
  { path: '', redirectTo: '/Login', pathMatch: 'full' },
  {
    path: 'Homepage/:ID', component: HomepageComponent,
  },
  {
    path: 'Login', component: LoginComponent,
  },  
  

];

@NgModule({
  imports: [RouterModule.forRoot(routes, { useHash: true, initialNavigation: 'enabled' })],
  exports: [RouterModule]
})
export class AppRoutingModule { }










































































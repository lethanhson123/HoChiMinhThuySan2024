import { Component, OnInit, Renderer2 } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router, NavigationEnd } from '@angular/router';
import { environment } from 'src/environments/environment';
import { DownloadService } from 'src/app/shared/Download.service';
import { NotificationService } from 'src/app/shared/Notification.service';
import { ThanhVien } from 'src/app/shared/ThanhVien.model';
import { ThanhVienService } from 'src/app/shared/ThanhVien.service';



@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {    
  constructor(
    private renderer: Renderer2,
    public DownloadService: DownloadService,
    public NotificationService: NotificationService,

    public ThanhVienService: ThanhVienService,  
  ) {
    
  }
  ngOnInit() {
    this.BodyListener();
    this.GetByQueryString();
  }
  BodyListener() {
    this.renderer.listen(
      document.body,
      'keyup',
      (event) => {
        if (event) {
          if (event["keyCode"] == 13) {
            this.Login();
          }
        }
      }
    );
  }
  GetByQueryString() {
    this.ThanhVienService.IsShowLoading = true;
    this.ThanhVienService.BaseParameter.ID = environment.InitializationNumber
    this.ThanhVienService.GetByIDAsync().subscribe(
      res => {
        this.ThanhVienService.FormDataLogin = res as ThanhVien;
        this.ThanhVienService.FormData = res as ThanhVien;
        this.ThanhVienService.IsShowLoading = false;
      },
      err => {
        this.ThanhVienService.IsShowLoading = false;
      }
    );
  }
  Login() {
    this.ThanhVienService.IsShowLoading = true;
    this.ThanhVienService.AuthenticationAsync().subscribe(
      res => {
        this.ThanhVienService.IsShowLoading = false;
        this.ThanhVienService.FormDataLogin = res as ThanhVien;
        if (this.ThanhVienService.FormDataLogin) {
          if (this.ThanhVienService.FormDataLogin.Active == true) {
            window.location.href = this.ThanhVienService.FormDataLogin.Note;
          }
          else {
            this.NotificationService.warn(environment.UserNameActive);
          }
        }
        else {
          this.NotificationService.warn(environment.LoginNotSuccess);
          this.ThanhVienService.IsShowLoading = false;
        }
      },
      err => {
        this.NotificationService.warn(environment.LoginNotSuccess);
        this.ThanhVienService.IsShowLoading = false;
      }
    );
  }  
}

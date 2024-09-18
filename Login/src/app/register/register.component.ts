import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { environment } from 'src/environments/environment';
import { Router, NavigationEnd } from '@angular/router';
import { DownloadService } from 'src/app/shared/Download.service';
import { NotificationService } from 'src/app/shared/Notification.service';
import { ThanhVien } from 'src/app/shared/ThanhVien.model';
import { ThanhVienService } from 'src/app/shared/ThanhVien.service';
import { DanhMucThanhVien } from 'src/app/shared/DanhMucThanhVien.model';
import { DanhMucThanhVienService } from 'src/app/shared/DanhMucThanhVien.service';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  constructor(
    public router: Router,
    public ThanhVienService: ThanhVienService,
    public DanhMucThanhVienService: DanhMucThanhVienService,
    public DownloadService: DownloadService,
    public NotificationService: NotificationService,
  ) {
  }
  ngOnInit() {
    
  }  
  Save() {
    this.ThanhVienService.IsShowLoading = true;    
    this.ThanhVienService.FormData.Active = false;
    this.ThanhVienService.SaveAsync().subscribe(
      res => {        
        this.router.navigate(['/DangKyThanhCong']);
      },
      err => {
        this.NotificationService.warn(environment.RegisterNotSuccess);
        this.ThanhVienService.IsShowLoading = false;
      }
    );
  }  
}
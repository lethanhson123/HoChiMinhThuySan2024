import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { environment } from 'src/environments/environment';
import { DownloadService } from 'src/app/shared/Download.service';
import { NotificationService } from 'src/app/shared/Notification.service';

@Component({
  selector: 'app-dang-ky-thanh-cong',
  templateUrl: './dang-ky-thanh-cong.component.html',
  styleUrls: ['./dang-ky-thanh-cong.component.css']
})
export class DangKyThanhCongComponent implements OnInit {  
  constructor(
    public DownloadService: DownloadService,
    public NotificationService: NotificationService,
  ) { }

  ngOnInit(): void {
  }
  onChangeLanguage() {
    this.DownloadService.LanguageID = !this.DownloadService.LanguageID;
    this.DownloadService.ChangeLanguage();
  }
}

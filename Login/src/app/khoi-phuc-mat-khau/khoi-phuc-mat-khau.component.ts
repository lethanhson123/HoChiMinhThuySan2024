import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { environment } from 'src/environments/environment';
import { DownloadService } from 'src/app/shared/Download.service';
import { NotificationService } from 'src/app/shared/Notification.service';

@Component({
  selector: 'app-khoi-phuc-mat-khau',
  templateUrl: './khoi-phuc-mat-khau.component.html',
  styleUrls: ['./khoi-phuc-mat-khau.component.css']
})
export class KhoiPhucMatKhauComponent implements OnInit {

  constructor(
    public DownloadService: DownloadService,
    public NotificationService: NotificationService,
  ) { }

  ngOnInit(): void {
  }  
}
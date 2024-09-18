import { Component, OnInit, Inject, ElementRef, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { environment } from 'src/environments/environment';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { NotificationService } from 'src/app/shared/Notification.service';

import { ThanhVien } from 'src/app/shared/ThanhVien.model';
import { ThanhVienService } from 'src/app/shared/ThanhVien.service';

@Component({
  selector: 'app-upload',
  templateUrl: './upload.component.html',
  styleUrls: ['./upload.component.css']
})
export class UploadComponent implements OnInit {

  IsThanhVien: boolean = false;
  URLExcelThanhVien: string = environment.APIRootURL + environment.Download + "/ThanhVien.xlsx"; 

  IsThanhVien001: boolean = false;
  URLExcelThanhVien001: string = environment.APIRootURL + environment.Download + "/ThanhVien001.xlsx"; 

  IsThanhVien002: boolean = false;
  URLExcelThanhVien002: string = environment.APIRootURL + environment.Download + "/ThanhVien002.xlsx"; 

  constructor(
    public NotificationService: NotificationService,

    public ThanhVienService: ThanhVienService,
  ) { }

  ngOnInit(): void {
  }
  ChangeFileThanhVien(files: FileList) {
    if (files) {
      this.ThanhVienService.FileToUpload = files;
      this.IsThanhVien = true;
    }
  }
  ThanhVienUpload() {
    this.ThanhVienService.IsShowLoading = true;    
    this.ThanhVienService.PostThanhVienDanhMucXaPhuongNameByExcelFileAsync().subscribe(
      res => {        
        this.NotificationService.warn(environment.UploadSuccess);
        this.ThanhVienService.IsShowLoading = false;
      },
      err => {
        this.NotificationService.warn(environment.UploadNotSuccess);
        this.ThanhVienService.IsShowLoading = false;
      }
    );
  }

  ChangeFileThanhVien001(files: FileList) {
    if (files) {
      this.ThanhVienService.FileToUpload = files;
      this.IsThanhVien001 = true;
    }
  }
  ThanhVienUpload001() {
    this.ThanhVienService.IsShowLoading = true;    
    this.ThanhVienService.PostThanhVien001ByExcelFileAsync().subscribe(
      res => {        
        this.NotificationService.warn(environment.UploadSuccess);
        this.ThanhVienService.IsShowLoading = false;
      },
      err => {
        this.NotificationService.warn(environment.UploadNotSuccess);
        this.ThanhVienService.IsShowLoading = false;
      }
    );
  }

  ChangeFileThanhVien002(files: FileList) {
    if (files) {
      this.ThanhVienService.FileToUpload = files;
      this.IsThanhVien002 = true;
    }
  }
  ThanhVienUpload002() {
    this.ThanhVienService.IsShowLoading = true;    
    this.ThanhVienService.PostThanhVien002ByExcelFileAsync().subscribe(
      res => {        
        this.NotificationService.warn(environment.UploadSuccess);
        this.ThanhVienService.IsShowLoading = false;
      },
      err => {
        this.NotificationService.warn(environment.UploadNotSuccess);
        this.ThanhVienService.IsShowLoading = false;
      }
    );
  }
}

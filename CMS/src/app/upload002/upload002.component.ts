import { Component, OnInit, Inject, ElementRef, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { environment } from 'src/environments/environment';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { NotificationService } from 'src/app/shared/Notification.service';


import { UploadService } from 'src/app/shared/Upload.service';

@Component({
  selector: 'app-upload002',
  templateUrl: './upload002.component.html',
  styleUrls: ['./upload002.component.css']
})
export class Upload002Component implements OnInit {

  IsFile: boolean = false;
  URLExcel: string = environment.APIUploadRootURL + environment.Download + "/ToChucHoNuoi.xlsx"; 

  constructor(
    public NotificationService: NotificationService,

    public UploadService: UploadService,
  ) { }

  ngOnInit(): void {
  }

  ChangeFile(files: FileList) {
    if (files) {
      this.UploadService.FileToUpload = files;
      this.IsFile = true;
    }
  }
  Upload() {
    this.UploadService.IsShowLoading = true;    
    this.UploadService.PostToChucHoNuoiByExcelFile().subscribe(
      res => {        
        this.NotificationService.warn(environment.UploadSuccess);
       
      },
      err => {
        this.NotificationService.warn(environment.UploadNotSuccess);
       
      },
      ()=>{
        this.UploadService.IsShowLoading = false;
      }
    );
  }

}

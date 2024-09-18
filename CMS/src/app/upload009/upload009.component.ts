import { Component, OnInit, Inject, ElementRef, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { environment } from 'src/environments/environment';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { NotificationService } from 'src/app/shared/Notification.service';
import { UploadService } from 'src/app/shared/Upload.service';

import { DanhMucQuanHuyen } from 'src/app/shared/DanhMucQuanHuyen.model';
import { DanhMucQuanHuyenService } from 'src/app/shared/DanhMucQuanHuyen.service';
import { DanhMucXaPhuong } from 'src/app/shared/DanhMucXaPhuong.model';
import { DanhMucXaPhuongService } from 'src/app/shared/DanhMucXaPhuong.service';

@Component({
  selector: 'app-upload009',
  templateUrl: './upload009.component.html',
  styleUrls: ['./upload009.component.css']
})
export class Upload009Component implements OnInit {

  IsFile: boolean = false;
  URLExcel: string = environment.APIUploadRootURL + environment.Download + "/ToChucNuoiNhuyenThe002.xlsx"; 

  constructor(
    public NotificationService: NotificationService,
    public UploadService: UploadService,

    public DanhMucQuanHuyenService: DanhMucQuanHuyenService,
    public DanhMucXaPhuongService: DanhMucXaPhuongService,
  ) { }

  ngOnInit(): void {
    this.DanhMucQuanHuyenSearch();
  }
  
  ChangeFile(files: FileList) {
    if (files) {
      this.UploadService.FileToUpload = files;
      this.IsFile = true;
    }
  }
  Upload() {
    this.UploadService.IsShowLoading = true;    
    this.UploadService.PostToChucNuoiNhuyenThe002ByExcelFileAsync().subscribe(
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

  DanhMucQuanHuyenSearch() {
    if (this.DanhMucQuanHuyenService.List) {
      if (this.DanhMucQuanHuyenService.List.length == 0) {
        this.UploadService.IsShowLoading = true;
        this.DanhMucQuanHuyenService.GetAllToListAsync().subscribe(
          res => {
            this.DanhMucQuanHuyenService.List = (res as DanhMucQuanHuyen[]).sort((a, b) => (a.Name > b.Name ? 1 : -1));
            this.DanhMucQuanHuyenService.ListFilter = this.DanhMucQuanHuyenService.List;
            this.DanhMucXaPhuongSearch();
          },
          err => {
          },
          () => {
            this.UploadService.IsShowLoading = false;
          }
        );
      }
    }
  }
  DanhMucXaPhuongSearch() {
    this.UploadService.IsShowLoading = true;
    this.DanhMucXaPhuongService.BaseParameter.ParentID = this.UploadService.BaseParameter.DanhMucQuanHuyenID;
    this.DanhMucXaPhuongService.GetByParentIDToListAsync().subscribe(
      res => {
        this.DanhMucXaPhuongService.List = (res as DanhMucXaPhuong[]).sort((a, b) => (a.Name > b.Name ? 1 : -1));
        if (this.DanhMucXaPhuongService.List.length > 0) {
          this.UploadService.BaseParameter.DanhMucXaPhuongID = this.DanhMucXaPhuongService.List[0].ID;
        }
      },
      err => {
      },
      () => {
        this.UploadService.IsShowLoading = false;
      }
    );
  }

}
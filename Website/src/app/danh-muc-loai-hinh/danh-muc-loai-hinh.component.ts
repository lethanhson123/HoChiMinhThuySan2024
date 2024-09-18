import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { environment } from 'src/environments/environment';
import { NotificationService } from 'src/app/shared/Notification.service';
import { DownloadService } from 'src/app/shared/Download.service';


import { DanhMucLoaiHinh } from 'src/app/shared/DanhMucLoaiHinh.model';
import { DanhMucLoaiHinhService } from 'src/app/shared/DanhMucLoaiHinh.service';
@Component({
  selector: 'app-danh-muc-loai-hinh',
  templateUrl: './danh-muc-loai-hinh.component.html',
  styleUrls: ['./danh-muc-loai-hinh.component.css']
})
export class DanhMucLoaiHinhComponent implements OnInit {

  @ViewChild('DanhMucLoaiHinhSort') DanhMucLoaiHinhSort: MatSort;
  @ViewChild('DanhMucLoaiHinhPaginator') DanhMucLoaiHinhPaginator: MatPaginator;

  constructor(
    private dialog: MatDialog,
    public NotificationService: NotificationService,
    public DownloadService: DownloadService,

    public DanhMucLoaiHinhService: DanhMucLoaiHinhService,
  ) { }

  ngOnInit(): void {    
  }

  DanhMucLoaiHinhSearch() {
    this.DanhMucLoaiHinhService.SearchAll(this.DanhMucLoaiHinhSort, this.DanhMucLoaiHinhPaginator);
  }
  DanhMucLoaiHinhSave(element: DanhMucLoaiHinh) {
    this.DanhMucLoaiHinhService.FormData = element;
    this.NotificationService.warn(this.DanhMucLoaiHinhService.ComponentSaveAll(this.DanhMucLoaiHinhSort, this.DanhMucLoaiHinhPaginator));
  }
  DanhMucLoaiHinhDelete(element: DanhMucLoaiHinh) {
    this.DanhMucLoaiHinhService.BaseParameter.ID = element.ID;
    this.NotificationService.warn(this.DanhMucLoaiHinhService.ComponentDeleteAll(this.DanhMucLoaiHinhSort, this.DanhMucLoaiHinhPaginator));
  }  
}
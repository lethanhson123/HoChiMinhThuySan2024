import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { environment } from 'src/environments/environment';
import { NotificationService } from 'src/app/shared/Notification.service';
import { DownloadService } from 'src/app/shared/Download.service';


import { DanhMucLoaiGiong } from 'src/app/shared/DanhMucLoaiGiong.model';
import { DanhMucLoaiGiongService } from 'src/app/shared/DanhMucLoaiGiong.service';

@Component({
  selector: 'app-danh-muc-loai-giong',
  templateUrl: './danh-muc-loai-giong.component.html',
  styleUrls: ['./danh-muc-loai-giong.component.css']
})
export class DanhMucLoaiGiongComponent implements OnInit {

  @ViewChild('DanhMucLoaiGiongSort') DanhMucLoaiGiongSort: MatSort;
  @ViewChild('DanhMucLoaiGiongPaginator') DanhMucLoaiGiongPaginator: MatPaginator;

  constructor(
    private dialog: MatDialog,
    public NotificationService: NotificationService,
    public DownloadService: DownloadService,

    public DanhMucLoaiGiongService: DanhMucLoaiGiongService,
  ) { }

  ngOnInit(): void {    
  }

  DanhMucLoaiGiongSearch() {
    this.DanhMucLoaiGiongService.SearchAll(this.DanhMucLoaiGiongSort, this.DanhMucLoaiGiongPaginator);
  }
  DanhMucLoaiGiongSave(element: DanhMucLoaiGiong) {
    this.DanhMucLoaiGiongService.FormData = element;
    this.NotificationService.warn(this.DanhMucLoaiGiongService.ComponentSaveAll(this.DanhMucLoaiGiongSort, this.DanhMucLoaiGiongPaginator));
  }
  DanhMucLoaiGiongDelete(element: DanhMucLoaiGiong) {
    this.DanhMucLoaiGiongService.BaseParameter.ID = element.ID;
    this.NotificationService.warn(this.DanhMucLoaiGiongService.ComponentDeleteAll(this.DanhMucLoaiGiongSort, this.DanhMucLoaiGiongPaginator));
  }  
}
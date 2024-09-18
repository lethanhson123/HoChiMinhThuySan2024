import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { environment } from 'src/environments/environment';
import { NotificationService } from 'src/app/shared/Notification.service';
import { DownloadService } from 'src/app/shared/Download.service';


import { DanhMucChiTieuMoiTruong } from 'src/app/shared/DanhMucChiTieuMoiTruong.model';
import { DanhMucChiTieuMoiTruongService } from 'src/app/shared/DanhMucChiTieuMoiTruong.service';

@Component({
  selector: 'app-danh-muc-chi-tieu-moi-truong',
  templateUrl: './danh-muc-chi-tieu-moi-truong.component.html',
  styleUrls: ['./danh-muc-chi-tieu-moi-truong.component.css']
})
export class DanhMucChiTieuMoiTruongComponent implements OnInit {

  @ViewChild('DanhMucChiTieuMoiTruongSort') DanhMucChiTieuMoiTruongSort: MatSort;
  @ViewChild('DanhMucChiTieuMoiTruongPaginator') DanhMucChiTieuMoiTruongPaginator: MatPaginator;

  constructor(
    private dialog: MatDialog,
    public NotificationService: NotificationService,
    public DownloadService: DownloadService,

    public DanhMucChiTieuMoiTruongService: DanhMucChiTieuMoiTruongService,
  ) { }

  ngOnInit(): void {    
  }

  DanhMucChiTieuMoiTruongSearch() {
    this.DanhMucChiTieuMoiTruongService.SearchAll(this.DanhMucChiTieuMoiTruongSort, this.DanhMucChiTieuMoiTruongPaginator);
  }
  DanhMucChiTieuMoiTruongSave(element: DanhMucChiTieuMoiTruong) {
    this.DanhMucChiTieuMoiTruongService.FormData = element;
    this.NotificationService.warn(this.DanhMucChiTieuMoiTruongService.ComponentSaveAll(this.DanhMucChiTieuMoiTruongSort, this.DanhMucChiTieuMoiTruongPaginator));
  }
  DanhMucChiTieuMoiTruongDelete(element: DanhMucChiTieuMoiTruong) {
    this.DanhMucChiTieuMoiTruongService.BaseParameter.ID = element.ID;
    this.NotificationService.warn(this.DanhMucChiTieuMoiTruongService.ComponentDeleteAll(this.DanhMucChiTieuMoiTruongSort, this.DanhMucChiTieuMoiTruongPaginator));
  }  
}
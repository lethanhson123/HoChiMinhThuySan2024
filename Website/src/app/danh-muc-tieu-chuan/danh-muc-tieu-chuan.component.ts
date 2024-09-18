import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { environment } from 'src/environments/environment';
import { NotificationService } from 'src/app/shared/Notification.service';
import { DownloadService } from 'src/app/shared/Download.service';


import { DanhMucTieuChuan } from 'src/app/shared/DanhMucTieuChuan.model';
import { DanhMucTieuChuanService } from 'src/app/shared/DanhMucTieuChuan.service';

@Component({
  selector: 'app-danh-muc-tieu-chuan',
  templateUrl: './danh-muc-tieu-chuan.component.html',
  styleUrls: ['./danh-muc-tieu-chuan.component.css']
})
export class DanhMucTieuChuanComponent implements OnInit {

  @ViewChild('DanhMucTieuChuanSort') DanhMucTieuChuanSort: MatSort;
  @ViewChild('DanhMucTieuChuanPaginator') DanhMucTieuChuanPaginator: MatPaginator;

  constructor(
    private dialog: MatDialog,
    public NotificationService: NotificationService,
    public DownloadService: DownloadService,

    public DanhMucTieuChuanService: DanhMucTieuChuanService,
  ) { }

  ngOnInit(): void {    
  }

  DanhMucTieuChuanSearch() {
    this.DanhMucTieuChuanService.SearchAll(this.DanhMucTieuChuanSort, this.DanhMucTieuChuanPaginator);
  }
  DanhMucTieuChuanSave(element: DanhMucTieuChuan) {
    this.DanhMucTieuChuanService.FormData = element;
    this.NotificationService.warn(this.DanhMucTieuChuanService.ComponentSaveAll(this.DanhMucTieuChuanSort, this.DanhMucTieuChuanPaginator));
  }
  DanhMucTieuChuanDelete(element: DanhMucTieuChuan) {
    this.DanhMucTieuChuanService.BaseParameter.ID = element.ID;
    this.NotificationService.warn(this.DanhMucTieuChuanService.ComponentDeleteAll(this.DanhMucTieuChuanSort, this.DanhMucTieuChuanPaginator));
  }  
}
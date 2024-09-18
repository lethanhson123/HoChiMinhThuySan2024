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

import { ToChuc } from 'src/app/shared/ToChuc.model';
import { ToChucService } from 'src/app/shared/ToChuc.service';

import { ChiTieuMoiTruong } from 'src/app/shared/ChiTieuMoiTruong.model';
import { ChiTieuMoiTruongService } from 'src/app/shared/ChiTieuMoiTruong.service';

@Component({
  selector: 'app-chi-tieu-moi-truong',
  templateUrl: './chi-tieu-moi-truong.component.html',
  styleUrls: ['./chi-tieu-moi-truong.component.css']
})
export class ChiTieuMoiTruongComponent implements OnInit {

  @ViewChild('ChiTieuMoiTruongSort') ChiTieuMoiTruongSort: MatSort;
  @ViewChild('ChiTieuMoiTruongPaginator') ChiTieuMoiTruongPaginator: MatPaginator;

  constructor(
    private dialog: MatDialog,
    public NotificationService: NotificationService,
    public DownloadService: DownloadService,
    public DanhMucChiTieuMoiTruongService: DanhMucChiTieuMoiTruongService,

    public ToChucService: ToChucService,

    public ChiTieuMoiTruongService: ChiTieuMoiTruongService,

  ) { }

  ngOnInit(): void {
    this.ToChucSearch();
    this.DanhMucChiTieuMoiTruongSearch();
  }
  DateBatDau(value) {
    this.ChiTieuMoiTruongService.BaseParameter.BatDau = new Date(value);
  }
  DateKetThuc(value) {
    this.ChiTieuMoiTruongService.BaseParameter.KetThuc = new Date(value);
  }
  DateNgayGhiNhan(element: ChiTieuMoiTruong, value) {
    element.NgayGhiNhan = new Date(value);
  }
  DanhMucChiTieuMoiTruongSearch() {
    this.DanhMucChiTieuMoiTruongService.ComponentGetAllToListAsync(this.ChiTieuMoiTruongService);
  }
  ToChucSearch() {
    this.ToChucService.BaseParameter.ParentID = environment.DanhMucToChucIDTramQuanTrac;
    this.ToChucService.ComponentGetByParentIDToListAsync(this.ChiTieuMoiTruongService);
  }

  ChiTieuMoiTruongSearch() {
    this.ChiTieuMoiTruongService.IsShowLoading = true;
    this.ChiTieuMoiTruongService.GetByBatDau_KetThucAndEmptyToListAsync().subscribe(
      res => {
        this.ChiTieuMoiTruongService.List = (res as [ChiTieuMoiTruong]).sort((a, b) => (a.NgayGhiNhan < b.NgayGhiNhan ? 1 : -1));        
        this.ChiTieuMoiTruongService.DataSource = new MatTableDataSource(this.ChiTieuMoiTruongService.List);
        this.ChiTieuMoiTruongService.DataSource.sort = this.ChiTieuMoiTruongSort;
        this.ChiTieuMoiTruongService.DataSource.paginator = this.ChiTieuMoiTruongPaginator;
      },
      err => {
      },
      () => {
        this.ChiTieuMoiTruongService.IsShowLoading = false;
      }
    );
  }
  ChiTieuMoiTruongSave(element: ChiTieuMoiTruong) {
    this.ChiTieuMoiTruongService.FormData = element;
    this.NotificationService.warn(this.ChiTieuMoiTruongService.ComponentSaveAll(this.ChiTieuMoiTruongSort, this.ChiTieuMoiTruongPaginator));
  }
  ChiTieuMoiTruongDelete(element: ChiTieuMoiTruong) {
    this.ChiTieuMoiTruongService.BaseParameter.ID = element.ID;
    this.NotificationService.warn(this.ChiTieuMoiTruongService.ComponentDeleteAll(this.ChiTieuMoiTruongSort, this.ChiTieuMoiTruongPaginator));
  }
}

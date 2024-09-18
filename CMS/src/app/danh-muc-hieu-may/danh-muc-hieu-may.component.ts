import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { environment } from 'src/environments/environment';
import { NotificationService } from 'src/app/shared/Notification.service';
import { DownloadService } from 'src/app/shared/Download.service';


import { DanhMucHieuMay } from 'src/app/shared/DanhMucHieuMay.model';
import { DanhMucHieuMayService } from 'src/app/shared/DanhMucHieuMay.service';

@Component({
  selector: 'app-danh-muc-hieu-may',
  templateUrl: './danh-muc-hieu-may.component.html',
  styleUrls: ['./danh-muc-hieu-may.component.css']
})
export class DanhMucHieuMayComponent implements OnInit {

  @ViewChild('DanhMucHieuMaySort') DanhMucHieuMaySort: MatSort;
  @ViewChild('DanhMucHieuMayPaginator') DanhMucHieuMayPaginator: MatPaginator;

  constructor(
    private dialog: MatDialog,
    public NotificationService: NotificationService,
    public DownloadService: DownloadService,

    public DanhMucHieuMayService: DanhMucHieuMayService,
  ) { }

  ngOnInit(): void {    
  }

  DanhMucHieuMaySearch() {
    this.DanhMucHieuMayService.SearchAll(this.DanhMucHieuMaySort, this.DanhMucHieuMayPaginator);
  }
  DanhMucHieuMaySave(element: DanhMucHieuMay) {
    this.DanhMucHieuMayService.FormData = element;
    this.NotificationService.warn(this.DanhMucHieuMayService.ComponentSaveAll(this.DanhMucHieuMaySort, this.DanhMucHieuMayPaginator));
  }
  DanhMucHieuMayDelete(element: DanhMucHieuMay) {
    this.DanhMucHieuMayService.BaseParameter.ID = element.ID;
    this.NotificationService.warn(this.DanhMucHieuMayService.ComponentDeleteAll(this.DanhMucHieuMaySort, this.DanhMucHieuMayPaginator));
  }  
}
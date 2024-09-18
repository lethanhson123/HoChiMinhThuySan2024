import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { environment } from 'src/environments/environment';
import { NotificationService } from 'src/app/shared/Notification.service';
import { DownloadService } from 'src/app/shared/Download.service';


import { DanhMucTinhThanh } from 'src/app/shared/DanhMucTinhThanh.model';
import { DanhMucTinhThanhService } from 'src/app/shared/DanhMucTinhThanh.service';
import { DanhMucTinhThanhToaDoDetailComponent } from '../danh-muc-tinh-thanh-toa-do-detail/danh-muc-tinh-thanh-toa-do-detail.component';

@Component({
  selector: 'app-danh-muc-tinh-thanh',
  templateUrl: './danh-muc-tinh-thanh.component.html',
  styleUrls: ['./danh-muc-tinh-thanh.component.css']
})
export class DanhMucTinhThanhComponent implements OnInit {

  @ViewChild('DanhMucTinhThanhSort') DanhMucTinhThanhSort: MatSort;
  @ViewChild('DanhMucTinhThanhPaginator') DanhMucTinhThanhPaginator: MatPaginator;

  constructor(
    private dialog: MatDialog,
    public NotificationService: NotificationService,
    public DownloadService: DownloadService,

    public DanhMucTinhThanhService: DanhMucTinhThanhService,
  ) { }

  ngOnInit(): void {
  }

  DanhMucTinhThanhSearch() {
    this.DanhMucTinhThanhService.SearchAll(this.DanhMucTinhThanhSort, this.DanhMucTinhThanhPaginator);
  }
  DanhMucTinhThanhSave(element: DanhMucTinhThanh) {
    this.DanhMucTinhThanhService.FormData = element;
    this.NotificationService.warn(this.DanhMucTinhThanhService.ComponentSaveAll(this.DanhMucTinhThanhSort, this.DanhMucTinhThanhPaginator));
  }
  DanhMucTinhThanhDelete(element: DanhMucTinhThanh) {
    this.DanhMucTinhThanhService.BaseParameter.ID = element.ID;
    this.NotificationService.warn(this.DanhMucTinhThanhService.ComponentDeleteAll(this.DanhMucTinhThanhSort, this.DanhMucTinhThanhPaginator));
  }
  DanhMucTinhThanhToaDoAdd(element: DanhMucTinhThanh) {
    this.DanhMucTinhThanhService.BaseParameter.ID = element.ID;
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = environment.DialogConfigWidth;
    dialogConfig.data = { ID: element.ID };
    const dialog = this.dialog.open(DanhMucTinhThanhToaDoDetailComponent, dialogConfig);
    dialog.afterClosed().subscribe(() => {
    });
  }
}
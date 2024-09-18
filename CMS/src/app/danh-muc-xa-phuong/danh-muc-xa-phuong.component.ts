import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { environment } from 'src/environments/environment';
import { NotificationService } from 'src/app/shared/Notification.service';
import { DownloadService } from 'src/app/shared/Download.service';

import { DanhMucXaPhuong } from 'src/app/shared/DanhMucXaPhuong.model';
import { DanhMucXaPhuongService } from 'src/app/shared/DanhMucXaPhuong.service';



import { DanhMucQuanHuyen } from 'src/app/shared/DanhMucQuanHuyen.model';
import { DanhMucQuanHuyenService } from 'src/app/shared/DanhMucQuanHuyen.service';
import { DanhMucTinhThanhToaDoDetail002Component } from '../danh-muc-tinh-thanh-toa-do-detail002/danh-muc-tinh-thanh-toa-do-detail002.component';


@Component({
  selector: 'app-danh-muc-xa-phuong',
  templateUrl: './danh-muc-xa-phuong.component.html',
  styleUrls: ['./danh-muc-xa-phuong.component.css']
})
export class DanhMucXaPhuongComponent implements OnInit {

  @ViewChild('DanhMucXaPhuongSort') DanhMucXaPhuongSort: MatSort;
  @ViewChild('DanhMucXaPhuongPaginator') DanhMucXaPhuongPaginator: MatPaginator;

  constructor(
    private dialog: MatDialog,
    public NotificationService: NotificationService,
    public DownloadService: DownloadService,

    public DanhMucXaPhuongService: DanhMucXaPhuongService,

    public DanhMucQuanHuyenService: DanhMucQuanHuyenService,
  ) { }

  ngOnInit(): void {  
    this.DanhMucQuanHuyenSearch();
  } 
 
  DanhMucQuanHuyenSearch() {
    this.DanhMucQuanHuyenService.ComponentGetAllToListSortByNameAsync(this.DanhMucXaPhuongService);
  }
  DanhMucXaPhuongSearch() {
    this.DanhMucXaPhuongService.ComponentGetByParentID_SearchString_EmptyToListAsync(this.DanhMucXaPhuongSort, this.DanhMucXaPhuongPaginator);
  }
  DanhMucXaPhuongSave(element: DanhMucXaPhuong) {
    this.DanhMucXaPhuongService.FormData = element;
    this.NotificationService.warn(this.DanhMucXaPhuongService.ComponentSaveByParentID_SearchString(this.DanhMucXaPhuongSort, this.DanhMucXaPhuongPaginator));
  }
  DanhMucXaPhuongDelete(element: DanhMucXaPhuong) {
    this.DanhMucXaPhuongService.BaseParameter.ID = element.ID;
    this.NotificationService.warn(this.DanhMucXaPhuongService.ComponentDeleteByParentID_SearchString(this.DanhMucXaPhuongSort, this.DanhMucXaPhuongPaginator));
  }
  DanhMucTinhThanhToaDoAdd(element: DanhMucXaPhuong) {
    this.DanhMucXaPhuongService.BaseParameter.ID = element.ID;
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = environment.DialogConfigWidth;
    dialogConfig.data = { ID: element.ID };
    const dialog = this.dialog.open(DanhMucTinhThanhToaDoDetail002Component, dialogConfig);
    dialog.afterClosed().subscribe(() => {
    });
  }
}
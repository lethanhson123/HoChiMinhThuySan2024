import { Component, OnInit, Inject, ElementRef, ViewChild } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { environment } from 'src/environments/environment';
import { NotificationService } from 'src/app/shared/Notification.service';
import { DownloadService } from 'src/app/shared/Download.service';

import { DanhMucQuanHuyen } from 'src/app/shared/DanhMucQuanHuyen.model';
import { DanhMucQuanHuyenService } from 'src/app/shared/DanhMucQuanHuyen.service';
import { DanhMucTinhThanhToaDo } from 'src/app/shared/DanhMucTinhThanhToaDo.model';
import { DanhMucTinhThanhToaDoService } from 'src/app/shared/DanhMucTinhThanhToaDo.service';

@Component({
  selector: 'app-danh-muc-tinh-thanh-toa-do-detail001',
  templateUrl: './danh-muc-tinh-thanh-toa-do-detail001.component.html',
  styleUrls: ['./danh-muc-tinh-thanh-toa-do-detail001.component.css']
})
export class DanhMucTinhThanhToaDoDetail001Component implements OnInit {

  @ViewChild('DanhMucTinhThanhToaDoSort') DanhMucTinhThanhToaDoSort: MatSort;
  @ViewChild('DanhMucTinhThanhToaDoPaginator') DanhMucTinhThanhToaDoPaginator: MatPaginator;

  constructor(
    private dialog: MatDialog,
    public dialogRef: MatDialogRef<DanhMucTinhThanhToaDoDetail001Component>,
    @Inject(MAT_DIALOG_DATA) public data: any,

    public NotificationService: NotificationService,
    public DownloadService: DownloadService,

    public DanhMucQuanHuyenService: DanhMucQuanHuyenService,
    public DanhMucTinhThanhToaDoService: DanhMucTinhThanhToaDoService,
  ) { }

  ngOnInit(): void {
    this.DanhMucTinhThanhSearch();
  }
  DanhMucTinhThanhSearch() {
    this.DanhMucTinhThanhToaDoService.IsShowLoading = true;    
    this.DanhMucQuanHuyenService.GetByIDAsync().subscribe(
      res => {
        this.DanhMucQuanHuyenService.FormData = res as DanhMucQuanHuyen;    
        this.DanhMucTinhThanhToaDoSearch();    
      },
      err => {
      },
      () => {
        this.DanhMucTinhThanhToaDoService.IsShowLoading = false;
      }
    );
  }
  DanhMucTinhThanhToaDoSearch() {
    this.DanhMucTinhThanhToaDoService.BaseParameter.ParentID = this.DanhMucQuanHuyenService.FormData.ID;
    this.DanhMucTinhThanhToaDoService.SearchAll(this.DanhMucTinhThanhToaDoSort, this.DanhMucTinhThanhToaDoPaginator);
  }
  DanhMucTinhThanhToaDoSave(element: DanhMucTinhThanhToaDo) {
    this.DanhMucTinhThanhToaDoService.FormData = element;
    this.NotificationService.warn(this.DanhMucTinhThanhToaDoService.ComponentSaveAll(this.DanhMucTinhThanhToaDoSort, this.DanhMucTinhThanhToaDoPaginator));
  }
  DanhMucTinhThanhToaDoDelete(element: DanhMucTinhThanhToaDo) {
    this.DanhMucTinhThanhToaDoService.BaseParameter.ID = element.ID;
    this.NotificationService.warn(this.DanhMucTinhThanhToaDoService.ComponentDeleteAll(this.DanhMucTinhThanhToaDoSort, this.DanhMucTinhThanhToaDoPaginator));
  } 
  Close() {
    this.dialogRef.close();
  }
}

import { Component, OnInit, Inject, ElementRef, ViewChild } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { environment } from 'src/environments/environment';
import { NotificationService } from 'src/app/shared/Notification.service';
import { DownloadService } from 'src/app/shared/Download.service';

import { DanhMucTinhThanh } from 'src/app/shared/DanhMucTinhThanh.model';
import { DanhMucTinhThanhService } from 'src/app/shared/DanhMucTinhThanh.service';
import { DanhMucTinhThanhToaDo } from 'src/app/shared/DanhMucTinhThanhToaDo.model';
import { DanhMucTinhThanhToaDoService } from 'src/app/shared/DanhMucTinhThanhToaDo.service';

@Component({
  selector: 'app-danh-muc-tinh-thanh-toa-do-detail',
  templateUrl: './danh-muc-tinh-thanh-toa-do-detail.component.html',
  styleUrls: ['./danh-muc-tinh-thanh-toa-do-detail.component.css']
})
export class DanhMucTinhThanhToaDoDetailComponent implements OnInit {

  @ViewChild('DanhMucTinhThanhToaDoSort') DanhMucTinhThanhToaDoSort: MatSort;
  @ViewChild('DanhMucTinhThanhToaDoPaginator') DanhMucTinhThanhToaDoPaginator: MatPaginator;

  constructor(
    private dialog: MatDialog,
    public dialogRef: MatDialogRef<DanhMucTinhThanhToaDoDetailComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,

    public NotificationService: NotificationService,
    public DownloadService: DownloadService,

    public DanhMucTinhThanhService: DanhMucTinhThanhService,
    public DanhMucTinhThanhToaDoService: DanhMucTinhThanhToaDoService,
  ) { }

  ngOnInit(): void {
    this.DanhMucTinhThanhSearch();
  }
  DanhMucTinhThanhSearch() {
    this.DanhMucTinhThanhToaDoService.IsShowLoading = true;    
    this.DanhMucTinhThanhService.GetByIDAsync().subscribe(
      res => {
        this.DanhMucTinhThanhService.FormData = res as DanhMucTinhThanh;    
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
    this.DanhMucTinhThanhToaDoService.BaseParameter.ParentID = this.DanhMucTinhThanhService.FormData.ID;
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
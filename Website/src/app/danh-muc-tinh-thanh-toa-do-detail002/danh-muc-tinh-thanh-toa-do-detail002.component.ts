import { Component, OnInit, Inject, ElementRef, ViewChild } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { environment } from 'src/environments/environment';
import { NotificationService } from 'src/app/shared/Notification.service';
import { DownloadService } from 'src/app/shared/Download.service';

import { DanhMucXaPhuong } from 'src/app/shared/DanhMucXaPhuong.model';
import { DanhMucXaPhuongService } from 'src/app/shared/DanhMucXaPhuong.service';
import { DanhMucTinhThanhToaDo } from 'src/app/shared/DanhMucTinhThanhToaDo.model';
import { DanhMucTinhThanhToaDoService } from 'src/app/shared/DanhMucTinhThanhToaDo.service';

@Component({
  selector: 'app-danh-muc-tinh-thanh-toa-do-detail002',
  templateUrl: './danh-muc-tinh-thanh-toa-do-detail002.component.html',
  styleUrls: ['./danh-muc-tinh-thanh-toa-do-detail002.component.css']
})
export class DanhMucTinhThanhToaDoDetail002Component implements OnInit {

  @ViewChild('DanhMucTinhThanhToaDoSort') DanhMucTinhThanhToaDoSort: MatSort;
  @ViewChild('DanhMucTinhThanhToaDoPaginator') DanhMucTinhThanhToaDoPaginator: MatPaginator;

  constructor(
    private dialog: MatDialog,
    public dialogRef: MatDialogRef<DanhMucTinhThanhToaDoDetail002Component>,
    @Inject(MAT_DIALOG_DATA) public data: any,

    public NotificationService: NotificationService,
    public DownloadService: DownloadService,

    public DanhMucXaPhuongService: DanhMucXaPhuongService,
    public DanhMucTinhThanhToaDoService: DanhMucTinhThanhToaDoService,
  ) { }

  ngOnInit(): void {
    this.DanhMucTinhThanhSearch();
  }
  DanhMucTinhThanhSearch() {
    this.DanhMucTinhThanhToaDoService.IsShowLoading = true;    
    this.DanhMucXaPhuongService.GetByIDAsync().subscribe(
      res => {
        this.DanhMucXaPhuongService.FormData = res as DanhMucXaPhuong;            
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
    this.DanhMucTinhThanhToaDoService.BaseParameter.ParentID = this.DanhMucXaPhuongService.FormData.ID;    
    this.DanhMucTinhThanhToaDoService.SearchByParentID(this.DanhMucTinhThanhToaDoSort, this.DanhMucTinhThanhToaDoPaginator, this.DanhMucTinhThanhToaDoService);
  }
  DanhMucTinhThanhToaDoSave(element: DanhMucTinhThanhToaDo) {
    this.DanhMucTinhThanhToaDoService.FormData = element;
    this.NotificationService.warn(this.DanhMucTinhThanhToaDoService.ComponentSaveByParentID(this.DanhMucTinhThanhToaDoSort, this.DanhMucTinhThanhToaDoPaginator, this.DanhMucTinhThanhToaDoService));
  }
  DanhMucTinhThanhToaDoDelete(element: DanhMucTinhThanhToaDo) {
    this.DanhMucTinhThanhToaDoService.BaseParameter.ID = element.ID;
    this.NotificationService.warn(this.DanhMucTinhThanhToaDoService.ComponentDeleteByParentID(this.DanhMucTinhThanhToaDoSort, this.DanhMucTinhThanhToaDoPaginator, this.DanhMucTinhThanhToaDoService));
  } 
  Close() {
    this.dialogRef.close();
  }
}
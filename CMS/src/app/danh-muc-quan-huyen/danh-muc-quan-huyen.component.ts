import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { environment } from 'src/environments/environment';
import { NotificationService } from 'src/app/shared/Notification.service';
import { DownloadService } from 'src/app/shared/Download.service';

import { DanhMucQuanHuyen } from 'src/app/shared/DanhMucQuanHuyen.model';
import { DanhMucQuanHuyenService } from 'src/app/shared/DanhMucQuanHuyen.service';
import { DanhMucTinhThanhToaDoDetail001Component } from '../danh-muc-tinh-thanh-toa-do-detail001/danh-muc-tinh-thanh-toa-do-detail001.component';


@Component({
  selector: 'app-danh-muc-quan-huyen',
  templateUrl: './danh-muc-quan-huyen.component.html',
  styleUrls: ['./danh-muc-quan-huyen.component.css']
})
export class DanhMucQuanHuyenComponent implements OnInit {

  @ViewChild('DanhMucQuanHuyenSort') DanhMucQuanHuyenSort: MatSort;
  @ViewChild('DanhMucQuanHuyenPaginator') DanhMucQuanHuyenPaginator: MatPaginator;

  constructor(
    private dialog: MatDialog,
    public NotificationService: NotificationService,
    public DownloadService: DownloadService,

    public DanhMucQuanHuyenService: DanhMucQuanHuyenService,

    
  ) { }

  ngOnInit(): void {
    
  }
  
  DanhMucQuanHuyenSearch() {
    this.DanhMucQuanHuyenService.SearchAll(this.DanhMucQuanHuyenSort, this.DanhMucQuanHuyenPaginator);
  }
  DanhMucQuanHuyenSave(element: DanhMucQuanHuyen) {
    this.DanhMucQuanHuyenService.FormData = element;
    this.NotificationService.warn(this.DanhMucQuanHuyenService.ComponentSaveAll(this.DanhMucQuanHuyenSort, this.DanhMucQuanHuyenPaginator));
  }
  DanhMucQuanHuyenDelete(element: DanhMucQuanHuyen) {
    this.DanhMucQuanHuyenService.BaseParameter.ID = element.ID;
    this.NotificationService.warn(this.DanhMucQuanHuyenService.ComponentDeleteAll(this.DanhMucQuanHuyenSort, this.DanhMucQuanHuyenPaginator));
  }
  DanhMucTinhThanhToaDoAdd(element: DanhMucQuanHuyen) {
    this.DanhMucQuanHuyenService.BaseParameter.ID = element.ID;
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = environment.DialogConfigWidth;
    dialogConfig.data = { ID: element.ID };
    const dialog = this.dialog.open(DanhMucTinhThanhToaDoDetail001Component, dialogConfig);
    dialog.afterClosed().subscribe(() => {
    });
  }
}

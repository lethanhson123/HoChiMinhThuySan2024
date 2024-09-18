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
import { DanhMucXaPhuong } from 'src/app/shared/DanhMucXaPhuong.model';
import { DanhMucXaPhuongService } from 'src/app/shared/DanhMucXaPhuong.service';

import { ToChuc } from 'src/app/shared/ToChuc.model';
import { ToChucService } from 'src/app/shared/ToChuc.service';
import { ToChucPhuongTienKhaiThacDetailComponent } from '../to-chuc-phuong-tien-khai-thac-detail/to-chuc-phuong-tien-khai-thac-detail.component';

@Component({
  selector: 'app-to-chuc-phuong-tien-khai-thac001',
  templateUrl: './to-chuc-phuong-tien-khai-thac001.component.html',
  styleUrls: ['./to-chuc-phuong-tien-khai-thac001.component.css']
})
export class ToChucPhuongTienKhaiThac001Component implements OnInit {

  @ViewChild('ToChucSort') ToChucSort: MatSort;
  @ViewChild('ToChucPaginator') ToChucPaginator: MatPaginator;

  constructor(
    private dialog: MatDialog,
    public NotificationService: NotificationService,
    public DownloadService: DownloadService,
    public DanhMucQuanHuyenService: DanhMucQuanHuyenService,
    public DanhMucXaPhuongService: DanhMucXaPhuongService,

    public ToChucService: ToChucService,
  ) { }

  ngOnInit(): void {
    this.DanhMucQuanHuyenSearch();
  }
  DanhMucQuanHuyenSearch() {
    if (this.DanhMucQuanHuyenService.List) {
      if (this.DanhMucQuanHuyenService.List.length == 0) {
        this.ToChucService.IsShowLoading = true;
        this.DanhMucQuanHuyenService.GetAllToListAsync().subscribe(
          res => {
            this.DanhMucQuanHuyenService.List = (res as DanhMucQuanHuyen[]).sort((a, b) => (a.Name > b.Name ? 1 : -1));
            this.DanhMucQuanHuyenService.ListFilter = this.DanhMucQuanHuyenService.List;
            this.DanhMucXaPhuongSearch();
          },
          err => {
          },
          () => {
            this.ToChucService.IsShowLoading = false;
          }
        );
      }
    }
  }
  DanhMucXaPhuongSearch() {
    this.ToChucService.IsShowLoading = true;
    this.DanhMucXaPhuongService.BaseParameter.ParentID = this.ToChucService.BaseParameter.DanhMucQuanHuyenID;
    this.DanhMucXaPhuongService.GetByParentIDToListAsync().subscribe(
      res => {
        this.DanhMucXaPhuongService.List = (res as DanhMucXaPhuong[]).sort((a, b) => (a.Name > b.Name ? 1 : -1));
        if (this.DanhMucXaPhuongService.List.length > 0) {
          this.ToChucService.BaseParameter.DanhMucXaPhuongID = this.DanhMucXaPhuongService.List[0].ID;
        }
        this.ToChucSearch();
      },
      err => {
      },
      () => {
        this.ToChucService.IsShowLoading = false;
      }
    );
  }
  ToChucSearch() {    
    this.ToChucService.IsShowLoading = true;
    this.ToChucService.BaseParameter.ParentID = environment.DanhMucToChucIDPhuongTienKhaiThac;
    this.ToChucService.GetByParentIDAndSearchString_DanhMucQuanHuyenID_DanhMucXaPhuongIDAsync().subscribe(
      res => {
        this.ToChucService.List = (res as ToChuc[]).sort((a, b) => (a.Name > b.Name ? 1 : -1));
        this.ToChucService.DataSource = new MatTableDataSource(this.ToChucService.List);
        this.ToChucService.DataSource.sort = this.ToChucSort;
        this.ToChucService.DataSource.paginator = this.ToChucPaginator;
      },
      err => {
      },
      () => {
        this.ToChucService.IsShowLoading = false;
      }
    );
  }
  ToChucDelete(element: ToChuc) {
    this.ToChucService.BaseParameter.ID = element.ID;
    this.NotificationService.warn(this.ToChucService.ComponentDeleteByParentIDNotEmpty(this.ToChucSort, this.ToChucPaginator));
  }
  ToChucAdd(ID: number) {
    this.ToChucService.BaseParameter.ID = ID;
    this.ToChucService.GetByIDAsync().subscribe(
      res => {
        this.ToChucService.FormData = res as ToChuc;
        const dialogConfig = new MatDialogConfig();
        dialogConfig.disableClose = true;
        dialogConfig.autoFocus = true;
        dialogConfig.width = environment.DialogConfigWidth;
        dialogConfig.data = { ID: ID };
        const dialog = this.dialog.open(ToChucPhuongTienKhaiThacDetailComponent, dialogConfig);
        dialog.afterClosed().subscribe(() => {
          this.ToChucSearch();
        });
      },
      err => {
      }
    );
  }
}
import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { environment } from 'src/environments/environment';
import { NotificationService } from 'src/app/shared/Notification.service';
import { DownloadService } from 'src/app/shared/Download.service';
import { DanhMucLoaiGiong } from 'src/app/shared/DanhMucLoaiGiong.model';
import { DanhMucLoaiGiongService } from 'src/app/shared/DanhMucLoaiGiong.service';
import { DanhMucGiong } from 'src/app/shared/DanhMucGiong.model';
import { DanhMucGiongService } from 'src/app/shared/DanhMucGiong.service';

import { ToChuc } from 'src/app/shared/ToChuc.model';
import { ToChucService } from 'src/app/shared/ToChuc.service';
import { ToChucNuoiNhuyenTheDetailComponent } from '../to-chuc-nuoi-nhuyen-the-detail/to-chuc-nuoi-nhuyen-the-detail.component';
import { ToChucHoNuoiDetailComponent } from '../to-chuc-ho-nuoi-detail/to-chuc-ho-nuoi-detail.component';

@Component({
  selector: 'app-to-chuc-nuoi-nhuyen-the',
  templateUrl: './to-chuc-nuoi-nhuyen-the.component.html',
  styleUrls: ['./to-chuc-nuoi-nhuyen-the.component.css']
})
export class ToChucNuoiNhuyenTheComponent implements OnInit {

  @ViewChild('ToChucSort') ToChucSort: MatSort;
  @ViewChild('ToChucPaginator') ToChucPaginator: MatPaginator;

  constructor(
    private dialog: MatDialog,
    public NotificationService: NotificationService,
    public DownloadService: DownloadService,
    public DanhMucLoaiGiongService: DanhMucLoaiGiongService,
    public DanhMucGiongService: DanhMucGiongService,

    public ToChucService: ToChucService,
  ) { }

  ngOnInit(): void {
    this.DanhMucGiongSearch();
  }
  DanhMucLoaiGiongSearch() {
    this.DanhMucLoaiGiongService.ComponentGetAllToListAsync(this.ToChucService);
  }
  DanhMucGiongSearch() {
    this.DanhMucGiongService.ComponentGetAllToListAsync(this.ToChucService);
    this.ToChucService.BaseParameter.DanhMucGiongID = environment.DanhMucGiongIDNgheu;
  }
  ToChucSearch() {
    if (this.ToChucService.BaseParameter.SearchString.length > 0) {
      this.ToChucService.BaseParameter.SearchString = this.ToChucService.BaseParameter.SearchString.trim();
      if (this.ToChucService.DataSource) {
        this.ToChucService.DataSource.filter = this.ToChucService.BaseParameter.SearchString.toLowerCase();
      }
    }
    else {
      this.ToChucService.IsShowLoading = true;
      this.ToChucService.GetSQLByDanhMucGiongIDToListAsync().subscribe(
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
  }
  ToChucDelete(element: ToChuc) {
    this.ToChucService.IsShowLoading = true;
    this.ToChucService.BaseParameter.ID = element.ID;
    this.ToChucService.RemoveAsync().subscribe(
      res => {
        this.ToChucSearch();
        this.NotificationService.warn(environment.DeleteSuccess);
      },
      err => {
        this.NotificationService.warn(environment.DeleteNotSuccess);
      },
      () => {
        this.ToChucService.IsShowLoading = false;
      }
    );
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
        const dialog = this.dialog.open(ToChucHoNuoiDetailComponent, dialogConfig);
        dialog.afterClosed().subscribe(() => {
          this.ToChucSearch();
        });
      },
      err => {
      }
    );
  }
  ToChucDownload() {
    this.ToChucService.IsShowLoading = true;
    this.DownloadService.BaseParameter.DanhMucGiongID = this.ToChucService.BaseParameter.DanhMucGiongID;
    this.DownloadService.ExportToChucDanhMucGiongToExcelAsync().subscribe(
      res => {
        window.open(res.toString(), "_blank");
      },
      err => {
      },
      () => {
        this.ToChucService.IsShowLoading = false;
      }
    );
  }
}
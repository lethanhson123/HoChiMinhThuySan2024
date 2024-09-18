import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { environment } from 'src/environments/environment';
import { NotificationService } from 'src/app/shared/Notification.service';
import { DownloadService } from 'src/app/shared/Download.service';


import { ToChuc } from 'src/app/shared/ToChuc.model';
import { ToChucService } from 'src/app/shared/ToChuc.service';
import { ToChucTramQuanTracDetailComponent } from '../to-chuc-tram-quan-trac-detail/to-chuc-tram-quan-trac-detail.component';

@Component({
  selector: 'app-to-chuc-tram-quan-trac',
  templateUrl: './to-chuc-tram-quan-trac.component.html',
  styleUrls: ['./to-chuc-tram-quan-trac.component.css']
})
export class ToChucTramQuanTracComponent implements OnInit {

  @ViewChild('ToChucSort') ToChucSort: MatSort;
  @ViewChild('ToChucPaginator') ToChucPaginator: MatPaginator;

  constructor(
    private dialog: MatDialog,
    public NotificationService: NotificationService,
    public DownloadService: DownloadService,

    public ToChucService: ToChucService,
  ) { }

  ngOnInit(): void {
    this.ToChucSearch();
  }

  ToChucSearch() {
    this.ToChucService.BaseParameter.ParentID = environment.DanhMucToChucIDTramQuanTrac;
    this.ToChucService.SearchByParentIDNotEmpty(this.ToChucSort, this.ToChucPaginator);
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
        const dialog = this.dialog.open(ToChucTramQuanTracDetailComponent, dialogConfig);
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
    this.DownloadService.BaseParameter.ParentID = this.ToChucService.BaseParameter.ParentID;
    this.DownloadService.ExportToChucTramQuanTracToExcelAsync().subscribe(
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
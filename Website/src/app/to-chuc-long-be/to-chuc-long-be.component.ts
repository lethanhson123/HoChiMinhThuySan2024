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
import { ToChucLongBeDetailComponent } from '../to-chuc-long-be-detail/to-chuc-long-be-detail.component';

@Component({
  selector: 'app-to-chuc-long-be',
  templateUrl: './to-chuc-long-be.component.html',
  styleUrls: ['./to-chuc-long-be.component.css']
})
export class ToChucLongBeComponent implements OnInit {

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
    this.ToChucService.BaseParameter.ParentID = environment.DanhMucToChucIDLongBe;
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
        const dialog = this.dialog.open(ToChucLongBeDetailComponent, dialogConfig);
        dialog.afterClosed().subscribe(() => {
          this.ToChucSearch();
        });
      },
      err => {
      }
    );
  }
}
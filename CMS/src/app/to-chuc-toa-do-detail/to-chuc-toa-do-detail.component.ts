import { Component, OnInit, Inject, ElementRef, ViewChild } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { environment } from 'src/environments/environment';
import { NotificationService } from 'src/app/shared/Notification.service';
import { DownloadService } from 'src/app/shared/Download.service';


import { ToChucToaDo } from 'src/app/shared/ToChucToaDo.model';
import { ToChucToaDoService } from 'src/app/shared/ToChucToaDo.service';

@Component({
  selector: 'app-to-chuc-toa-do-detail',
  templateUrl: './to-chuc-toa-do-detail.component.html',
  styleUrls: ['./to-chuc-toa-do-detail.component.css']
})
export class ToChucToaDoDetailComponent implements OnInit {

  @ViewChild('ToChucToaDoSort') ToChucToaDoSort: MatSort;
  @ViewChild('ToChucToaDoPaginator') ToChucToaDoPaginator: MatPaginator;

  constructor(
    private dialog: MatDialog,
    public dialogRef: MatDialogRef<ToChucToaDoDetailComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,

    public NotificationService: NotificationService,
    public DownloadService: DownloadService,

    public ToChucToaDoService: ToChucToaDoService,
  ) { }

  ngOnInit(): void {
    this.ToChucToaDoSearch();
  }
  ToChucToaDoSearch() {
    this.ToChucToaDoService.IsShowLoading = true;
    this.ToChucToaDoService.GetByToChucVungNuoiIDAndEmptyToListAsync().subscribe(
      res => {
        this.ToChucToaDoService.List = (res as ToChucToaDo[]);
        this.ToChucToaDoService.DataSource = new MatTableDataSource(this.ToChucToaDoService.List);
        this.ToChucToaDoService.DataSource.sort = this.ToChucToaDoSort;
        this.ToChucToaDoService.DataSource.paginator = this.ToChucToaDoPaginator;
      },
      err => {
      },
      () => {
        this.ToChucToaDoService.IsShowLoading = false;
      }
    );
  }
  ToChucToaDoSave(element: ToChucToaDo) {
    element.ParentID = this.ToChucToaDoService.BaseParameter.ParentID;
    element.ParentName = this.ToChucToaDoService.BaseParameter.ParentName;
    element.ToChucVungNuoiID = this.ToChucToaDoService.BaseParameter.ToChucVungNuoiID;
    element.ToChucVungNuoiName = this.ToChucToaDoService.BaseParameter.ToChucVungNuoiName;
    this.ToChucToaDoService.FormData = element;
    this.ToChucToaDoService.IsShowLoading = true;
    this.ToChucToaDoService.SaveAsync().subscribe(
      res => {
        this.NotificationService.warn(environment.SaveSuccess);
      },
      err => {
        this.NotificationService.warn(environment.SaveNotSuccess);
      },
      () => {
        this.ToChucToaDoService.IsShowLoading = false;
      }
    );
  }
  ToChucToaDoDelete(element: ToChucToaDo) {
    this.ToChucToaDoService.BaseParameter.ID = element.ID;
    this.ToChucToaDoService.IsShowLoading = true;
    this.ToChucToaDoService.RemoveAsync().subscribe(
      res => {
        this.NotificationService.warn(environment.DeleteSuccess);
      },
      err => {
        this.NotificationService.warn(environment.DeleteNotSuccess);
      },
      () => {
        this.ToChucToaDoService.IsShowLoading = false;
      }
    );
  }
  Close() {
    this.dialogRef.close();
  }
}
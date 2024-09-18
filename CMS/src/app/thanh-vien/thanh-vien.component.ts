import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { environment } from 'src/environments/environment';
import { NotificationService } from 'src/app/shared/Notification.service';
import { DownloadService } from 'src/app/shared/Download.service';

import { ThanhVien } from 'src/app/shared/ThanhVien.model';
import { ThanhVienService } from 'src/app/shared/ThanhVien.service';

import { ThanhVienDetailComponent } from '../thanh-vien-detail/thanh-vien-detail.component';


@Component({
  selector: 'app-thanh-vien',
  templateUrl: './thanh-vien.component.html',
  styleUrls: ['./thanh-vien.component.css']
})
export class ThanhVienComponent implements OnInit {

  @ViewChild('ThanhVienSort') ThanhVienSort: MatSort;
  @ViewChild('ThanhVienPaginator') ThanhVienPaginator: MatPaginator;

  constructor(
    private dialog: MatDialog,
    public NotificationService: NotificationService,
    public DownloadService: DownloadService,

    public ThanhVienService: ThanhVienService,



  ) { }

  ngOnInit(): void {

  }
  ThanhVienSearch() {
    this.ThanhVienService.SearchAllNotEmpty(this.ThanhVienSort, this.ThanhVienPaginator);
  }
  ThanhVienAdd(ID: number) {
    this.ThanhVienService.BaseParameter.ID = ID;
    this.ThanhVienService.GetByIDAsync().subscribe(
      res => {
        this.ThanhVienService.FormData = res as ThanhVien;
        const dialogConfig = new MatDialogConfig();
        dialogConfig.disableClose = true;
        dialogConfig.autoFocus = true;
        dialogConfig.width = environment.DialogConfigWidth;
        dialogConfig.data = { ID: ID };
        const dialog = this.dialog.open(ThanhVienDetailComponent, dialogConfig);
        dialog.afterClosed().subscribe(() => {
          this.ThanhVienSearch();
        });
      },
      err => {
      }
    );
  }
  ThanhVienSyncFromToChuc() {
    this.ThanhVienService.IsShowLoading = true;
    this.ThanhVienService.SyncFromToChucAsync().subscribe(
      res => {
      },
      err => {
      },
      () => {
        this.ThanhVienService.IsShowLoading = false;
      }
    );
  }
}
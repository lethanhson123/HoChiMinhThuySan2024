import { Component, OnInit, ViewChild } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { environment } from 'src/environments/environment';
import { NotificationService } from 'src/app/shared/Notification.service';
import { DownloadService } from 'src/app/shared/Download.service';

import { ThanhVienLichSuTruyCap } from 'src/app/shared/ThanhVienLichSuTruyCap.model';
import { ThanhVienLichSuTruyCapService } from 'src/app/shared/ThanhVienLichSuTruyCap.service';

@Component({
  selector: 'app-thanh-vien-lich-su-truy-cap',
  templateUrl: './thanh-vien-lich-su-truy-cap.component.html',
  styleUrls: ['./thanh-vien-lich-su-truy-cap.component.css']
})
export class ThanhVienLichSuTruyCapComponent implements OnInit {

  @ViewChild('ThanhVienLichSuTruyCapSort') ThanhVienLichSuTruyCapSort: MatSort;
  @ViewChild('ThanhVienLichSuTruyCapPaginator') ThanhVienLichSuTruyCapPaginator: MatPaginator;

  constructor(
    private dialog: MatDialog,
    public NotificationService: NotificationService,
    public DownloadService: DownloadService,

    public ThanhVienLichSuTruyCapService: ThanhVienLichSuTruyCapService,
  

  ) { }

  ngOnInit(): void {    
  }
  DateBatDau(value) {
    this.ThanhVienLichSuTruyCapService.BaseParameter.BatDau = new Date(value);
  }
  DateKetThuc(value) {
    this.ThanhVienLichSuTruyCapService.BaseParameter.KetThuc = new Date(value);
  }
  ThanhVienLichSuTruyCapSearch() {
    this.ThanhVienLichSuTruyCapService.IsShowLoading = true;    
    this.ThanhVienLichSuTruyCapService.GetBySearchString_BatDau_KetThucToListAsync().subscribe(
      res => {
        this.ThanhVienLichSuTruyCapService.List = (res as ThanhVienLichSuTruyCap[]).sort((a, b) => (a.NgayGhiNhan < b.NgayGhiNhan ? 1 : -1));
        this.ThanhVienLichSuTruyCapService.DataSource = new MatTableDataSource(this.ThanhVienLichSuTruyCapService.List);
        this.ThanhVienLichSuTruyCapService.DataSource.sort = this.ThanhVienLichSuTruyCapSort;
        this.ThanhVienLichSuTruyCapService.DataSource.paginator = this.ThanhVienLichSuTruyCapPaginator;
        this.ThanhVienLichSuTruyCapService.IsShowLoading = false;
      },
      err => {
        this.ThanhVienLichSuTruyCapService.IsShowLoading = false;
      }
    );
  }
}
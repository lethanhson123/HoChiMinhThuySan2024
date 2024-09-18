import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { environment } from 'src/environments/environment';
import { NotificationService } from 'src/app/shared/Notification.service';
import { DownloadService } from 'src/app/shared/Download.service';


import { DanhMucNganhNghe } from 'src/app/shared/DanhMucNganhNghe.model';
import { DanhMucNganhNgheService } from 'src/app/shared/DanhMucNganhNghe.service';

@Component({
  selector: 'app-danh-muc-nganh-nghe',
  templateUrl: './danh-muc-nganh-nghe.component.html',
  styleUrls: ['./danh-muc-nganh-nghe.component.css']
})
export class DanhMucNganhNgheComponent implements OnInit {

  @ViewChild('DanhMucNganhNgheSort') DanhMucNganhNgheSort: MatSort;
  @ViewChild('DanhMucNganhNghePaginator') DanhMucNganhNghePaginator: MatPaginator;

  constructor(
    private dialog: MatDialog,
    public NotificationService: NotificationService,
    public DownloadService: DownloadService,

    public DanhMucNganhNgheService: DanhMucNganhNgheService,
  ) { }

  ngOnInit(): void {    
  }

  DanhMucNganhNgheSearch() {
    this.DanhMucNganhNgheService.SearchAll(this.DanhMucNganhNgheSort, this.DanhMucNganhNghePaginator);
  }
  DanhMucNganhNgheSave(element: DanhMucNganhNghe) {
    this.DanhMucNganhNgheService.FormData = element;
    this.NotificationService.warn(this.DanhMucNganhNgheService.ComponentSaveAll(this.DanhMucNganhNgheSort, this.DanhMucNganhNghePaginator));
  }
  DanhMucNganhNgheDelete(element: DanhMucNganhNghe) {
    this.DanhMucNganhNgheService.BaseParameter.ID = element.ID;
    this.NotificationService.warn(this.DanhMucNganhNgheService.ComponentDeleteAll(this.DanhMucNganhNgheSort, this.DanhMucNganhNghePaginator));
  }  
}
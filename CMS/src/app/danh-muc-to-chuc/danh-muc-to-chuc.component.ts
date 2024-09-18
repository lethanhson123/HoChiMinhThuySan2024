import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { environment } from 'src/environments/environment';
import { NotificationService } from 'src/app/shared/Notification.service';
import { DownloadService } from 'src/app/shared/Download.service';


import { DanhMucToChuc } from 'src/app/shared/DanhMucToChuc.model';
import { DanhMucToChucService } from 'src/app/shared/DanhMucToChuc.service';

@Component({
  selector: 'app-danh-muc-to-chuc',
  templateUrl: './danh-muc-to-chuc.component.html',
  styleUrls: ['./danh-muc-to-chuc.component.css']
})
export class DanhMucToChucComponent implements OnInit {

  @ViewChild('DanhMucToChucSort') DanhMucToChucSort: MatSort;
  @ViewChild('DanhMucToChucPaginator') DanhMucToChucPaginator: MatPaginator;

  constructor(
    private dialog: MatDialog,
    public NotificationService: NotificationService,
    public DownloadService: DownloadService,

    public DanhMucToChucService: DanhMucToChucService,
  ) { }

  ngOnInit(): void {    
  }

  DanhMucToChucSearch() {
    this.DanhMucToChucService.SearchAll(this.DanhMucToChucSort, this.DanhMucToChucPaginator);
  }
  DanhMucToChucSave(element: DanhMucToChuc) {
    this.DanhMucToChucService.FormData = element;
    this.NotificationService.warn(this.DanhMucToChucService.ComponentSaveAll(this.DanhMucToChucSort, this.DanhMucToChucPaginator));
  }
  DanhMucToChucDelete(element: DanhMucToChuc) {
    this.DanhMucToChucService.BaseParameter.ID = element.ID;
    this.NotificationService.warn(this.DanhMucToChucService.ComponentDeleteAll(this.DanhMucToChucSort, this.DanhMucToChucPaginator));
  }  
}
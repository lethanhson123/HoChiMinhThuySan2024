import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { environment } from 'src/environments/environment';
import { NotificationService } from 'src/app/shared/Notification.service';
import { DownloadService } from 'src/app/shared/Download.service';


import { DanhMucGiong } from 'src/app/shared/DanhMucGiong.model';
import { DanhMucGiongService } from 'src/app/shared/DanhMucGiong.service';

@Component({
  selector: 'app-danh-muc-giong',
  templateUrl: './danh-muc-giong.component.html',
  styleUrls: ['./danh-muc-giong.component.css']
})
export class DanhMucGiongComponent implements OnInit {

  @ViewChild('DanhMucGiongSort') DanhMucGiongSort: MatSort;
  @ViewChild('DanhMucGiongPaginator') DanhMucGiongPaginator: MatPaginator;

  constructor(
    private dialog: MatDialog,
    public NotificationService: NotificationService,
    public DownloadService: DownloadService,

    public DanhMucGiongService: DanhMucGiongService,
  ) { }

  ngOnInit(): void {    
  }

  DanhMucGiongSearch() {
    this.DanhMucGiongService.SearchAll(this.DanhMucGiongSort, this.DanhMucGiongPaginator);
  }
  DanhMucGiongSave(element: DanhMucGiong) {
    this.DanhMucGiongService.FormData = element;
    this.NotificationService.warn(this.DanhMucGiongService.ComponentSaveAll(this.DanhMucGiongSort, this.DanhMucGiongPaginator));
  }
  DanhMucGiongDelete(element: DanhMucGiong) {
    this.DanhMucGiongService.BaseParameter.ID = element.ID;
    this.NotificationService.warn(this.DanhMucGiongService.ComponentDeleteAll(this.DanhMucGiongSort, this.DanhMucGiongPaginator));
  }  
}
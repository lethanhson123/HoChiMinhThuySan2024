import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { environment } from 'src/environments/environment';
import { NotificationService } from 'src/app/shared/Notification.service';
import { DownloadService } from 'src/app/shared/Download.service';


import { DanhMucAPI } from 'src/app/shared/DanhMucAPI.model';
import { DanhMucAPIService } from 'src/app/shared/DanhMucAPI.service';

@Component({
  selector: 'app-danh-muc-api',
  templateUrl: './danh-muc-api.component.html',
  styleUrls: ['./danh-muc-api.component.css']
})
export class DanhMucAPIComponent implements OnInit {

  @ViewChild('DanhMucAPISort') DanhMucAPISort: MatSort;
  @ViewChild('DanhMucAPIPaginator') DanhMucAPIPaginator: MatPaginator;

  constructor(
    private dialog: MatDialog,
    public NotificationService: NotificationService,
    public DownloadService: DownloadService,

    public DanhMucAPIService: DanhMucAPIService,
  ) { }

  ngOnInit(): void {    
  }

  DanhMucAPISearch() {
    this.DanhMucAPIService.SearchAll(this.DanhMucAPISort, this.DanhMucAPIPaginator);
  }
  DanhMucAPISave(element: DanhMucAPI) {
    this.DanhMucAPIService.FormData = element;
    this.NotificationService.warn(this.DanhMucAPIService.ComponentSaveAll(this.DanhMucAPISort, this.DanhMucAPIPaginator));
  }
  DanhMucAPIDelete(element: DanhMucAPI) {
    this.DanhMucAPIService.BaseParameter.ID = element.ID;
    this.NotificationService.warn(this.DanhMucAPIService.ComponentDeleteAll(this.DanhMucAPISort, this.DanhMucAPIPaginator));
  }  
}
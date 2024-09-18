import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { environment } from 'src/environments/environment';
import { NotificationService } from 'src/app/shared/Notification.service';
import { DownloadService } from 'src/app/shared/Download.service';


import { DanhMucNgonNgu } from 'src/app/shared/DanhMucNgonNgu.model';
import { DanhMucNgonNguService } from 'src/app/shared/DanhMucNgonNgu.service';

@Component({
  selector: 'app-danh-muc-ngon-ngu',
  templateUrl: './danh-muc-ngon-ngu.component.html',
  styleUrls: ['./danh-muc-ngon-ngu.component.css']
})
export class DanhMucNgonNguComponent implements OnInit {

  @ViewChild('DanhMucNgonNguSort') DanhMucNgonNguSort: MatSort;
  @ViewChild('DanhMucNgonNguPaginator') DanhMucNgonNguPaginator: MatPaginator;

  constructor(
    private dialog: MatDialog,
    public NotificationService: NotificationService,
    public DownloadService: DownloadService,

    public DanhMucNgonNguService: DanhMucNgonNguService,
  ) { }

  ngOnInit(): void {    
  }

  DanhMucNgonNguSearch() {
    this.DanhMucNgonNguService.SearchAll(this.DanhMucNgonNguSort, this.DanhMucNgonNguPaginator);
  }
  DanhMucNgonNguSave(element: DanhMucNgonNgu) {
    this.DanhMucNgonNguService.FormData = element;
    this.NotificationService.warn(this.DanhMucNgonNguService.ComponentSaveAll(this.DanhMucNgonNguSort, this.DanhMucNgonNguPaginator));
  }
  DanhMucNgonNguDelete(element: DanhMucNgonNgu) {
    this.DanhMucNgonNguService.BaseParameter.ID = element.ID;
    this.NotificationService.warn(this.DanhMucNgonNguService.ComponentDeleteAll(this.DanhMucNgonNguSort, this.DanhMucNgonNguPaginator));
  }  
}
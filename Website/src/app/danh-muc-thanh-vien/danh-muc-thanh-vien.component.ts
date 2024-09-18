import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { environment } from 'src/environments/environment';
import { NotificationService } from 'src/app/shared/Notification.service';
import { DownloadService } from 'src/app/shared/Download.service';


import { DanhMucThanhVien } from 'src/app/shared/DanhMucThanhVien.model';
import { DanhMucThanhVienService } from 'src/app/shared/DanhMucThanhVien.service';

@Component({
  selector: 'app-danh-muc-thanh-vien',
  templateUrl: './danh-muc-thanh-vien.component.html',
  styleUrls: ['./danh-muc-thanh-vien.component.css']
})
export class DanhMucThanhVienComponent implements OnInit {

  @ViewChild('DanhMucThanhVienSort') DanhMucThanhVienSort: MatSort;
  @ViewChild('DanhMucThanhVienPaginator') DanhMucThanhVienPaginator: MatPaginator;

  constructor(
    private dialog: MatDialog,
    public NotificationService: NotificationService,
    public DownloadService: DownloadService,

    public DanhMucThanhVienService: DanhMucThanhVienService,
  ) { }

  ngOnInit(): void {    
  }

  DanhMucThanhVienSearch() {
    this.DanhMucThanhVienService.SearchAll(this.DanhMucThanhVienSort, this.DanhMucThanhVienPaginator);
  }
  DanhMucThanhVienSave(element: DanhMucThanhVien) {
    this.DanhMucThanhVienService.FormData = element;
    this.NotificationService.warn(this.DanhMucThanhVienService.ComponentSaveAll(this.DanhMucThanhVienSort, this.DanhMucThanhVienPaginator));
  }
  DanhMucThanhVienDelete(element: DanhMucThanhVien) {
    this.DanhMucThanhVienService.BaseParameter.ID = element.ID;
    this.NotificationService.warn(this.DanhMucThanhVienService.ComponentDeleteAll(this.DanhMucThanhVienSort, this.DanhMucThanhVienPaginator));
  }  
}
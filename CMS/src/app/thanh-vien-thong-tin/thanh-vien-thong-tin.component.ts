import { Component, OnInit, Inject, ElementRef, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { environment } from 'src/environments/environment';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { NotificationService } from 'src/app/shared/Notification.service';
import { DanhMucThanhVien } from 'src/app/shared/DanhMucThanhVien.model';
import { DanhMucThanhVienService } from 'src/app/shared/DanhMucThanhVien.service';

import { DanhMucNgonNgu } from 'src/app/shared/DanhMucNgonNgu.model';
import { DanhMucNgonNguService } from 'src/app/shared/DanhMucNgonNgu.service';

import { ThanhVien } from 'src/app/shared/ThanhVien.model';
import { ThanhVienService } from 'src/app/shared/ThanhVien.service';


@Component({
  selector: 'app-thanh-vien-thong-tin',
  templateUrl: './thanh-vien-thong-tin.component.html',
  styleUrls: ['./thanh-vien-thong-tin.component.css']
})
export class ThanhVienThongTinComponent implements OnInit {

  @ViewChild('ThanhVienTapTinDinhKemSort') ThanhVienTapTinDinhKemSort: MatSort;
  @ViewChild('ThanhVienTapTinDinhKemPaginator') ThanhVienTapTinDinhKemPaginator: MatPaginator;

  MatKhauIsActive: boolean = true;

  constructor(
    public NotificationService: NotificationService,

    public DanhMucThanhVienService: DanhMucThanhVienService,
    public DanhMucNgonNguService: DanhMucNgonNguService,

    public ThanhVienService: ThanhVienService,
  ) { }

  ngOnInit(): void {
    this.GetByQueryString();
  }
  MatKhauChangeType() {
    this.MatKhauIsActive = !this.MatKhauIsActive;
  }
  
  DanhMucThanhVienSearch() {
    this.DanhMucThanhVienService.ComponentGetAllToListAsync(this.ThanhVienService);
  }
  DanhMucNgonNguSearch() {
    this.DanhMucNgonNguService.ComponentGetAllToListAsync(this.ThanhVienService);
  }
  GetByQueryString() {
    this.ThanhVienService.IsShowLoading = true;
    this.ThanhVienService.GetLogin();
    if (this.ThanhVienService.FormDataLogin) {
      if (this.ThanhVienService.FormDataLogin.ID > 0) {
        this.ThanhVienService.BaseParameter.ID = this.ThanhVienService.FormDataLogin.ID;
        this.ThanhVienService.GetByIDAsync().subscribe(res => {
          this.ThanhVienService.FormDataLogin = res as ThanhVien;
          this.ThanhVienService.IsShowLoading = false;
          this.DanhMucThanhVienSearch();
          this.DanhMucNgonNguSearch();
        },
          err => {
            this.NotificationService.warn(environment.SaveNotSuccess);
          }
        );
      }
    }
  }
  ThanhVienSave() {
    this.ThanhVienService.IsShowLoading = true;
    this.ThanhVienService.FormData = this.ThanhVienService.FormDataLogin;
    this.ThanhVienService.SaveAsync().subscribe(
      res => {
        this.ThanhVienService.FormDataLogin = res as ThanhVien;
        this.NotificationService.warn(environment.SaveSuccess);
        this.ThanhVienService.IsShowLoading = false;
      },
      err => {
        this.NotificationService.warn(environment.SaveNotSuccess);
        this.ThanhVienService.IsShowLoading = false;
      }
    );
  }  
}
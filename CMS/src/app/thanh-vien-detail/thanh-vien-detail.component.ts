import { Component, OnInit, Inject, ElementRef, ViewChild } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { environment } from 'src/environments/environment';
import { NotificationService } from 'src/app/shared/Notification.service';
import { DownloadService } from 'src/app/shared/Download.service';
import { from } from 'rxjs';
import { distinct } from 'rxjs/operators';

import { ThanhVien } from 'src/app/shared/ThanhVien.model';
import { ThanhVienService } from 'src/app/shared/ThanhVien.service';
import { ThanhVienChucNang } from 'src/app/shared/ThanhVienChucNang.model';
import { ThanhVienChucNangService } from 'src/app/shared/ThanhVienChucNang.service';

import { DanhMucThanhVien } from 'src/app/shared/DanhMucThanhVien.model';
import { DanhMucThanhVienService } from 'src/app/shared/DanhMucThanhVien.service';


@Component({
  selector: 'app-thanh-vien-detail',
  templateUrl: './thanh-vien-detail.component.html',
  styleUrls: ['./thanh-vien-detail.component.css']
})
export class ThanhVienDetailComponent implements OnInit {

  @ViewChild('ThanhVienChucNangSort') ThanhVienChucNangSort: MatSort;
  @ViewChild('ThanhVienChucNangPaginator') ThanhVienChucNangPaginator: MatPaginator;

 
  ActiveAllThanhVienChucNang: boolean = false;

  MatKhauIsActive: boolean = true;

  constructor(
    private dialog: MatDialog,
    public dialogRef: MatDialogRef<ThanhVienDetailComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,

    public NotificationService: NotificationService,
    public DownloadService: DownloadService,

    public DanhMucThanhVienService: DanhMucThanhVienService,
 
    public ThanhVienService: ThanhVienService,
    public ThanhVienChucNangService: ThanhVienChucNangService,
 
  ) { }

  ngOnInit(): void {    
    this.ThanhVienSearch();
  }
  MatKhauChangeType() {
    this.MatKhauIsActive = !this.MatKhauIsActive;
  }
  DanhMucThanhVienSearch() {
    this.DanhMucThanhVienService.ComponentGetAllToListAsync(this.ThanhVienService);
  }
  ThanhVienSearch() {
    this.ThanhVienService.BaseParameter.ID = this.ThanhVienService.FormData.ID;
    this.ThanhVienService.GetByIDAsync().subscribe(
      res => {
        this.ThanhVienService.FormData = res as ThanhVien;
        if (this.ThanhVienService.FormData.ID == environment.InitializationNumber) {
          this.ThanhVienService.FormData.DanhMucQuocGiaID = environment.DanhMucQuocGiaIDVietNam;
          this.ThanhVienService.FormData.DanhMucTinhThanhID = environment.DanhMucTinhThanhID;
          this.ThanhVienService.FormData.DanhMucQuanHuyenID = environment.DanhMucQuanHuyenID;
        }
        this.DanhMucThanhVienSearch();
      },
      err => {
      }
    );
  }

  
  ThanhVienChucNangSearch() {
    if (this.ThanhVienChucNangService.BaseParameter.SearchString.length > 0) {
      this.ThanhVienChucNangService.DataSource.filter = this.ThanhVienChucNangService.BaseParameter.SearchString.toLowerCase();
    }
    else {
      this.ThanhVienService.IsShowLoading = true;
      this.ThanhVienChucNangService.BaseParameter.ParentID = this.ThanhVienService.FormData.ID;
      this.ThanhVienChucNangService.GetSQLByParentIDToListAsync().subscribe(
        res => {
          this.ThanhVienChucNangService.List = (res as ThanhVienChucNang[]);
          this.ThanhVienChucNangService.DataSource = new MatTableDataSource(this.ThanhVienChucNangService.List);
          this.ThanhVienChucNangService.DataSource.sort = this.ThanhVienChucNangSort;
          this.ThanhVienChucNangService.DataSource.paginator = this.ThanhVienChucNangPaginator;          
        },
        err => {          
        },
        ()=>{
          this.ThanhVienService.IsShowLoading = false;
        }
      );
    }
  }
  ThanhVienChucNangActiveChange(element: ThanhVienChucNang) {
    this.ThanhVienService.IsShowLoading = true;
    this.ThanhVienChucNangService.FormData = element;
    this.ThanhVienChucNangService.FormData.ParentID = this.ThanhVienService.FormData.ID;
    this.ThanhVienChucNangService.SaveAsync().subscribe(
      res => {
        this.NotificationService.warn(environment.SaveSuccess);        
      },
      err => {
        this.NotificationService.warn(environment.SaveNotSuccess);       
      },
      ()=>{
        this.ThanhVienService.IsShowLoading = false;
      }
    );
  }
  ThanhVienChucNangActiveAllChange() {
    this.ThanhVienService.IsShowLoading = true;
    for (let i = 0; i < this.ThanhVienChucNangService.List.length; i++) {
      this.ThanhVienChucNangService.FormData = this.ThanhVienChucNangService.List[i];
      this.ThanhVienChucNangService.FormData.ParentID = this.ThanhVienService.FormData.ID;
      this.ThanhVienChucNangService.FormData.Active = this.ActiveAllThanhVienChucNang;
    }
    this.ThanhVienChucNangService.SaveListAsync(this.ThanhVienChucNangService.List).subscribe(
      res => {
        this.ThanhVienChucNangSearch();
        this.NotificationService.warn(environment.SaveSuccess);        
      },
      err => {
        this.NotificationService.warn(environment.SaveNotSuccess);        
      },
      ()=>{
        this.ThanhVienService.IsShowLoading = false;
      }
    );
  }

  ThanhVienSave() {
    this.ThanhVienService.IsShowLoading = true;
    this.ThanhVienService.SaveAsync().subscribe(
      res => {
        this.ThanhVienService.FormData = res as ThanhVien;
        this.NotificationService.warn(environment.SaveSuccess);        
      },
      err => {
        this.NotificationService.warn(environment.SaveNotSuccess);       
      },
      ()=>{
        this.ThanhVienService.IsShowLoading = false;
      }
    );
  }

  Close() {
    this.dialogRef.close();
  }  
}
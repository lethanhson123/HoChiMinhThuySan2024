import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { environment } from 'src/environments/environment';
import { NotificationService } from 'src/app/shared/Notification.service';
import { DownloadService } from 'src/app/shared/Download.service';


import { DanhMucChucNang } from 'src/app/shared/DanhMucChucNang.model';
import { DanhMucChucNangService } from 'src/app/shared/DanhMucChucNang.service';
import { ThanhVienChucNangDetailComponent } from '../thanh-vien-chuc-nang-detail/thanh-vien-chuc-nang-detail.component';

@Component({
  selector: 'app-danh-muc-chuc-nang',
  templateUrl: './danh-muc-chuc-nang.component.html',
  styleUrls: ['./danh-muc-chuc-nang.component.css']
})
export class DanhMucChucNangComponent implements OnInit {

  @ViewChild('DanhMucChucNangSort') DanhMucChucNangSort: MatSort;
  @ViewChild('DanhMucChucNangPaginator') DanhMucChucNangPaginator: MatPaginator;

  DanhMucUngDungID: number = environment.InitializationNumber;

  constructor(
    private dialog: MatDialog,
    public NotificationService: NotificationService,

    public DanhMucChucNangService: DanhMucChucNangService,
  ) { }

  ngOnInit(): void {
    this.DanhMucChucNangSearch();
  }
  DanhMucChucNangSearch() {
    this.DanhMucChucNangService.SearchAll(this.DanhMucChucNangSort, this.DanhMucChucNangPaginator);
  }

  DanhMucChucNangSave(element: DanhMucChucNang) {
    this.DanhMucChucNangService.FormData = element;
    this.NotificationService.warn(this.DanhMucChucNangService.ComponentSaveAll(this.DanhMucChucNangSort, this.DanhMucChucNangPaginator));
  }

  DanhMucChucNangDelete(element: DanhMucChucNang) {
    this.DanhMucChucNangService.BaseParameter.ID = element.ID;
    this.NotificationService.warn(this.DanhMucChucNangService.ComponentDeleteAll(this.DanhMucChucNangSort, this.DanhMucChucNangPaginator));
  }
  DanhMucChucNangAdd(element: DanhMucChucNang) {
    this.DanhMucChucNangService.FormData = element;
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = environment.DialogConfigWidth;
    dialogConfig.data = { ID: element.ID };
    const dialog = this.dialog.open(ThanhVienChucNangDetailComponent, dialogConfig);
    dialog.afterClosed().subscribe(() => {
    });
  }
}
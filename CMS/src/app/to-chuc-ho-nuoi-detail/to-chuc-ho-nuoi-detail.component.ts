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

import { DanhMucTinhThanh } from 'src/app/shared/DanhMucTinhThanh.model';
import { DanhMucTinhThanhService } from 'src/app/shared/DanhMucTinhThanh.service';
import { DanhMucQuanHuyen } from 'src/app/shared/DanhMucQuanHuyen.model';
import { DanhMucQuanHuyenService } from 'src/app/shared/DanhMucQuanHuyen.service';
import { DanhMucXaPhuong } from 'src/app/shared/DanhMucXaPhuong.model';
import { DanhMucXaPhuongService } from 'src/app/shared/DanhMucXaPhuong.service';

import { DanhMucToChuc } from 'src/app/shared/DanhMucToChuc.model';
import { DanhMucToChucService } from 'src/app/shared/DanhMucToChuc.service';
import { DanhMucTieuChuan } from 'src/app/shared/DanhMucTieuChuan.model';
import { DanhMucTieuChuanService } from 'src/app/shared/DanhMucTieuChuan.service';
import { DanhMucLoaiGiong } from 'src/app/shared/DanhMucLoaiGiong.model';
import { DanhMucLoaiGiongService } from 'src/app/shared/DanhMucLoaiGiong.service';
import { DanhMucGiong } from 'src/app/shared/DanhMucGiong.model';
import { DanhMucGiongService } from 'src/app/shared/DanhMucGiong.service';

import { ToChuc } from 'src/app/shared/ToChuc.model';
import { ToChucService } from 'src/app/shared/ToChuc.service';
import { ToChucToaDo } from 'src/app/shared/ToChucToaDo.model';
import { ToChucToaDoService } from 'src/app/shared/ToChucToaDo.service';
import { ToChucTapTinDinhKem } from 'src/app/shared/ToChucTapTinDinhKem.model';
import { ToChucTapTinDinhKemService } from 'src/app/shared/ToChucTapTinDinhKem.service';
import { ToChucQuanLy } from 'src/app/shared/ToChucQuanLy.model';
import { ToChucQuanLyService } from 'src/app/shared/ToChucQuanLy.service';
import { ToChucTieuChuan } from 'src/app/shared/ToChucTieuChuan.model';
import { ToChucTieuChuanService } from 'src/app/shared/ToChucTieuChuan.service';
import { ToChucGiong } from 'src/app/shared/ToChucGiong.model';
import { ToChucGiongService } from 'src/app/shared/ToChucGiong.service';
import { ToChucVungNuoi } from 'src/app/shared/ToChucVungNuoi.model';
import { ToChucVungNuoiService } from 'src/app/shared/ToChucVungNuoi.service';

import * as maplibregl from 'maplibre-gl';
import { ToChucToaDoDetailComponent } from '../to-chuc-toa-do-detail/to-chuc-toa-do-detail.component';

@Component({
  selector: 'app-to-chuc-ho-nuoi-detail',
  templateUrl: './to-chuc-ho-nuoi-detail.component.html',
  styleUrls: ['./to-chuc-ho-nuoi-detail.component.css']
})
export class ToChucHoNuoiDetailComponent implements OnInit {

  @ViewChild('ToChucToaDoSort') ToChucToaDoSort: MatSort;
  @ViewChild('ToChucToaDoPaginator') ToChucToaDoPaginator: MatPaginator;

  @ViewChild('ToChucTapTinDinhKemSort') ToChucTapTinDinhKemSort: MatSort;
  @ViewChild('ToChucTapTinDinhKemPaginator') ToChucTapTinDinhKemPaginator: MatPaginator;

  @ViewChild('ToChucQuanLySort') ToChucQuanLySort: MatSort;
  @ViewChild('ToChucQuanLyPaginator') ToChucQuanLyPaginator: MatPaginator;

  @ViewChild('ToChucTieuChuanSort') ToChucTieuChuanSort: MatSort;
  @ViewChild('ToChucTieuChuanPaginator') ToChucTieuChuanPaginator: MatPaginator;

  @ViewChild('ToChucGiongSort') ToChucGiongSort: MatSort;
  @ViewChild('ToChucGiongPaginator') ToChucGiongPaginator: MatPaginator;

  @ViewChild('ToChucVungNuoiSort') ToChucVungNuoiSort: MatSort;
  @ViewChild('ToChucVungNuoiPaginator') ToChucVungNuoiPaginator: MatPaginator;

  constructor(
    private dialog: MatDialog,
    public dialogRef: MatDialogRef<ToChucHoNuoiDetailComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,

    public NotificationService: NotificationService,
    public DownloadService: DownloadService,

    public DanhMucTinhThanhService: DanhMucTinhThanhService,
    public DanhMucQuanHuyenService: DanhMucQuanHuyenService,
    public DanhMucXaPhuongService: DanhMucXaPhuongService,
    public DanhMucToChucService: DanhMucToChucService,
    public DanhMucTieuChuanService: DanhMucTieuChuanService,
    public DanhMucLoaiGiongService: DanhMucLoaiGiongService,
    public DanhMucGiongService: DanhMucGiongService,

    public ToChucService: ToChucService,
    public ToChucToaDoService: ToChucToaDoService,
    public ToChucTapTinDinhKemService: ToChucTapTinDinhKemService,
    public ToChucQuanLyService: ToChucQuanLyService,
    public ToChucTieuChuanService: ToChucTieuChuanService,
    public ToChucGiongService: ToChucGiongService,
    public ToChucVungNuoiService: ToChucVungNuoiService,

  ) { }

  ngOnInit(): void {
    this.ToChucSearch();
  }
  DateNgaySinh(value) {
    this.ToChucService.FormData.NgaySinh = new Date(value);
  }
  DanhMucToChucSearch() {
    this.DanhMucToChucService.ComponentGetAllToListAsync(this.ToChucService);
  }
  DanhMucTieuChuanSearch() {
    this.DanhMucTieuChuanService.ComponentGetAllToListAsync(this.ToChucService);
  }
  DanhMucLoaiGiongSearch() {
    this.DanhMucLoaiGiongService.ComponentGetAllToListAsync(this.ToChucService);
  }
  DanhMucGiongSearch() {
    this.DanhMucGiongService.ComponentGetAllToListAsync(this.ToChucService);
  }
  DanhMucQuanHuyenSearch() {
    if (this.DanhMucQuanHuyenService.List) {
      if (this.DanhMucQuanHuyenService.List.length == 0) {
        this.ToChucService.IsShowLoading = true;
        this.DanhMucQuanHuyenService.GetAllToListAsync().subscribe(
          res => {
            this.DanhMucQuanHuyenService.List = (res as DanhMucQuanHuyen[]).sort((a, b) => (a.Name > b.Name ? 1 : -1));
            this.DanhMucQuanHuyenService.ListFilter = this.DanhMucQuanHuyenService.List;
            this.DanhMucXaPhuongSearch();
          },
          err => {
          },
          () => {
            this.ToChucService.IsShowLoading = false;
          }
        );
      }
    }
  }
  DanhMucXaPhuongSearch() {
    this.ToChucService.IsShowLoading = true;
    this.DanhMucXaPhuongService.BaseParameter.ParentID = this.ToChucService.FormData.DanhMucQuanHuyenID;
    this.DanhMucXaPhuongService.GetByParentIDToListAsync().subscribe(
      res => {
        this.DanhMucXaPhuongService.List = (res as DanhMucXaPhuong[]).sort((a, b) => (a.Name > b.Name ? 1 : -1));
      },
      err => {
      },
      () => {
        this.ToChucService.IsShowLoading = false;
      }
    );
  }
  ToChucSearchHopTacXa() {
    this.ToChucService.IsShowLoading = true;
    this.ToChucService.BaseParameter.ParentID = environment.DanhMucToChucIDHopTacXa;
    this.ToChucService.GetByParentIDToListAsync().subscribe(
      res => {
        this.ToChucService.ListHopTacXa = (res as ToChuc[]).sort((a, b) => (a.Name > b.Name ? 1 : -1));
      },
      err => {
      },
      () => {
        this.ToChucService.IsShowLoading = false;
      }
    );
  }
  ToChucSearch() {
    this.ToChucService.IsShowLoading = true;
    this.ToChucService.BaseParameter.ID = this.ToChucService.FormData.ID;
    this.ToChucService.GetByIDAsync().subscribe(
      res => {
        this.ToChucService.FormData = res as ToChuc;
        if (this.ToChucService.FormData.ID == environment.InitializationNumber) {
          this.ToChucService.FormData.DanhMucQuocGiaID = environment.DanhMucQuocGiaIDVietNam;
          this.ToChucService.FormData.DanhMucTinhThanhID = environment.DanhMucTinhThanhID;
          this.ToChucService.FormData.DanhMucQuanHuyenID = environment.DanhMucQuanHuyenID;
        }
        this.DanhMucQuanHuyenSearch();
        this.DanhMucToChucSearch();
        this.DanhMucTieuChuanSearch();
        this.DanhMucLoaiGiongSearch();
        this.DanhMucGiongSearch();
        this.ToChucSearchHopTacXa();
      },
      err => {
      },
      () => {
        this.ToChucService.IsShowLoading = false;
      }
    );
  }
  ToChucSave() {
    this.ToChucService.IsShowLoading = true;
    this.ToChucService.FormData.ParentID = environment.DanhMucToChucIDHoNuoi;
    this.ToChucService.SaveAsync().subscribe(
      res => {
        this.ToChucService.FormData = res as ToChuc;
        this.NotificationService.warn(environment.SaveSuccess);
      },
      err => {
        this.NotificationService.warn(environment.SaveNotSuccess);
      },
      () => {
        this.ToChucService.IsShowLoading = false;
      }
    );
  }

  ToChucTapTinDinhKemChangeFileName(files: FileList) {
    if (files) {
      this.ToChucTapTinDinhKemService.FileToUpload = files;
    }
  }
  ToChucTapTinDinhKemSearch() {
    this.ToChucTapTinDinhKemService.BaseParameter.ParentID = this.ToChucService.FormData.ID;
    this.ToChucTapTinDinhKemService.SearchByParentID(this.ToChucTapTinDinhKemSort, this.ToChucTapTinDinhKemPaginator, this.ToChucService);
  }
  ToChucTapTinDinhKemSave(element: ToChucTapTinDinhKem) {
    this.ToChucService.IsShowLoading = true;
    element.ParentID = this.ToChucService.FormData.ID;
    this.ToChucTapTinDinhKemService.FormData = element;
    this.ToChucTapTinDinhKemService.SaveAndUploadFileAsync().subscribe(
      res => {
        this.ToChucTapTinDinhKemSearch();
        this.NotificationService.warn(environment.SaveSuccess);
      },
      err => {
        this.NotificationService.warn(environment.SaveNotSuccess);
      },
      () => {
        this.ToChucService.IsShowLoading = false;
      }
    );
  }
  ToChucTapTinDinhKemDelete(element: ToChucTapTinDinhKem) {
    this.ToChucToaDoService.BaseParameter.ID = element.ID;
    this.NotificationService.warn(this.ToChucToaDoService.ComponentDeleteByParentID(this.ToChucTapTinDinhKemSort, this.ToChucTapTinDinhKemPaginator, this.ToChucService));
  }

  ToChucToaDoSearch() {
    this.ToChucToaDoService.BaseParameter.ParentID = this.ToChucService.FormData.ID;
    this.ToChucToaDoService.SearchByParentID(this.ToChucToaDoSort, this.ToChucToaDoPaginator, this.ToChucService);
  }
  ToChucToaDoSave(element: ToChucToaDo) {
    element.ParentID = this.ToChucService.FormData.ID;
    this.ToChucToaDoService.FormData = element;
    this.NotificationService.warn(this.ToChucToaDoService.ComponentSaveByParentID(this.ToChucToaDoSort, this.ToChucToaDoPaginator, this.ToChucService));
  }
  ToChucToaDoDelete(element: ToChucToaDo) {
    this.ToChucToaDoService.BaseParameter.ID = element.ID;
    this.NotificationService.warn(this.ToChucToaDoService.ComponentDeleteByParentID(this.ToChucToaDoSort, this.ToChucToaDoPaginator, this.ToChucService));
  }

  ToChucQuanLySearch() {
    this.ToChucQuanLyService.BaseParameter.ParentID = this.ToChucService.FormData.ID;
    this.ToChucQuanLyService.SearchByParentID(this.ToChucQuanLySort, this.ToChucQuanLyPaginator, this.ToChucService);
  }
  ToChucQuanLySave(element: ToChucQuanLy) {
    element.ParentID = this.ToChucService.FormData.ID;
    this.ToChucQuanLyService.FormData = element;
    this.NotificationService.warn(this.ToChucQuanLyService.ComponentSaveByParentID(this.ToChucQuanLySort, this.ToChucQuanLyPaginator, this.ToChucService));
  }
  ToChucQuanLyDelete(element: ToChucQuanLy) {
    this.ToChucQuanLyService.BaseParameter.ID = element.ID;
    this.NotificationService.warn(this.ToChucQuanLyService.ComponentDeleteByParentID(this.ToChucQuanLySort, this.ToChucQuanLyPaginator, this.ToChucService));
  }

  ToChucTieuChuanSearch() {
    this.ToChucTieuChuanService.BaseParameter.ParentID = this.ToChucService.FormData.ID;
    this.ToChucTieuChuanService.SearchByParentID(this.ToChucTieuChuanSort, this.ToChucTieuChuanPaginator, this.ToChucService);
  }
  ToChucTieuChuanSave(element: ToChucTieuChuan) {
    element.ParentID = this.ToChucService.FormData.ID;
    this.ToChucTieuChuanService.FormData = element;
    this.NotificationService.warn(this.ToChucTieuChuanService.ComponentSaveByParentID(this.ToChucTieuChuanSort, this.ToChucTieuChuanPaginator, this.ToChucService));
  }
  ToChucTieuChuanDelete(element: ToChucTieuChuan) {
    this.ToChucTieuChuanService.BaseParameter.ID = element.ID;
    this.NotificationService.warn(this.ToChucTieuChuanService.ComponentDeleteByParentID(this.ToChucTieuChuanSort, this.ToChucTieuChuanPaginator, this.ToChucService));
  }

  ToChucGiongSearch() {
    this.ToChucGiongService.BaseParameter.ParentID = this.ToChucService.FormData.ID;
    this.ToChucGiongService.SearchByParentID(this.ToChucGiongSort, this.ToChucGiongPaginator, this.ToChucService);
  }
  ToChucGiongSave(element: ToChucGiong) {
    element.ParentID = this.ToChucService.FormData.ID;
    this.ToChucGiongService.FormData = element;
    this.NotificationService.warn(this.ToChucGiongService.ComponentSaveByParentID(this.ToChucGiongSort, this.ToChucGiongPaginator, this.ToChucService));
  }
  ToChucGiongDelete(element: ToChucGiong) {
    this.ToChucGiongService.BaseParameter.ID = element.ID;
    this.NotificationService.warn(this.ToChucGiongService.ComponentDeleteByParentID(this.ToChucGiongSort, this.ToChucGiongPaginator, this.ToChucService));
  }

  ToChucVungNuoiSearch() {
    this.ToChucVungNuoiService.BaseParameter.ParentID = this.ToChucService.FormData.ID;
    this.ToChucVungNuoiService.SearchByParentID(this.ToChucVungNuoiSort, this.ToChucVungNuoiPaginator, this.ToChucService);
  }
  ToChucVungNuoiSave(element: ToChucVungNuoi) {
    element.ParentID = this.ToChucService.FormData.ID;
    this.ToChucVungNuoiService.FormData = element;
    this.NotificationService.warn(this.ToChucVungNuoiService.ComponentSaveByParentID(this.ToChucVungNuoiSort, this.ToChucVungNuoiPaginator, this.ToChucService));
  }
  ToChucVungNuoiDelete(element: ToChucVungNuoi) {
    this.ToChucVungNuoiService.BaseParameter.ID = element.ID;
    this.NotificationService.warn(this.ToChucVungNuoiService.ComponentDeleteByParentID(this.ToChucVungNuoiSort, this.ToChucVungNuoiPaginator, this.ToChucService));
  }

  ToChucToaDoAdd(element: ToChucVungNuoi) {
    this.ToChucToaDoService.BaseParameter.ToChucVungNuoiID = element.ID;
    this.ToChucToaDoService.BaseParameter.ToChucVungNuoiName = element.Name;
    this.ToChucToaDoService.BaseParameter.Code = element.Code;
    this.ToChucToaDoService.BaseParameter.ParentID = this.ToChucService.FormData.ID;
    this.ToChucToaDoService.BaseParameter.ParentName = this.ToChucService.FormData.Name;
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = environment.DialogConfigWidth;
    dialogConfig.data = { ID: element.ID };
    const dialog = this.dialog.open(ToChucToaDoDetailComponent, dialogConfig);
    dialog.afterClosed().subscribe(() => {
    });
  }

  Close() {
    this.dialogRef.close();
  }

  OpenWindowVeBanDo() {
    let URL = environment.MapURL + "Homepage/" + this.ToChucService.BaseParameter.ID + "/?Token=" + localStorage.getItem(environment.Token);
    this.DownloadService.OpenWindow(URL);
  }

  map: maplibregl.Map | undefined;

  @ViewChild('map')
  private mapContainer!: ElementRef<HTMLElement>;

  ngAfterViewInit() {

  }

  ngOnDestroy() {
    this.map?.remove();
  }

  MapInitialization(ID, longitude, latitude) {
    let IDDate = new Date().toISOString();
    let zoom = 16;

    if ((latitude > 90) || (latitude == 0)) {
      latitude = environment.Latitude;
      longitude = environment.Longitude;
    }

    if (ID == 0) {
      this.map = new maplibregl.Map({
        container: this.mapContainer.nativeElement,
        style: 'https://api.maptiler.com/maps/streets/style.json?key=' + environment.MaptilerAPIKey,
        center: [longitude, latitude],
        zoom: zoom,
        pitch: 45,
      });
    }
    if (ID == 1) {
      this.map = new maplibregl.Map({
        container: this.mapContainer.nativeElement,
        style: 'https://api.maptiler.com/maps/hybrid/style.json?key=' + environment.MaptilerAPIKey,
        center: [longitude, latitude],
        zoom: zoom,
        pitch: 45,
      });
    }

    this.map.addControl(
      new maplibregl.NavigationControl({
        visualizePitch: true,
        showZoom: true,
        showCompass: true
      })
    );
    this.map.addControl(
      new maplibregl.FullscreenControl({
      })
    );
    this.map.on('load', () => {

      this.map.addSource("HoangSa" + IDDate, {
        "type": "image",
        "url": environment.DomainURL + "assets/image/HoangSa01.png",
        "coordinates": [
          [111.09665858054495, 17.432475898867523],
          [113.11720985517763, 17.38420482529338],
          [112.79285037220984, 15.643938718432054],
          [110.88537855035554, 15.672592116966598],
        ]
      });
      this.map.addLayer({
        "id": "HoangSa" + IDDate,
        "source": "HoangSa" + IDDate,
        "type": "raster",
        "paint": {
          "raster-opacity": 1
        }
      });

      this.map.addSource("TruongSa" + IDDate, {
        "type": "image",
        "url": environment.DomainURL + "assets/image/TruongSa01.png",
        "coordinates": [
          [112.32373278444106, 12.236103169381323],
          [117.4620551483049, 11.606334626304161],
          [115.59654957671216, 7.357025445897818],
          [110.62186805246108, 7.811210355974268],


        ]
      });
      this.map.addLayer({
        "id": "TruongSa" + IDDate,
        "source": "TruongSa" + IDDate,
        "type": "raster",
        "paint": {
          "raster-opacity": 1
        }
      });

    });
  }

  MapLoad(ID: number) {
    this.ToChucGiongSearch();
    this.ToChucQuanLySearch();
    this.ToChucTieuChuanSearch();
    this.ToChucService.IsShowLoading = true;
    this.ToChucToaDoService.BaseParameter.ParentID = this.ToChucService.FormData.ID;
    this.ToChucToaDoService.GetByParentIDToListAsync().subscribe(
      res => {
        this.ToChucToaDoService.List = (res as ToChucToaDo[]);
        if (this.ToChucToaDoService.List) {
          let longitude = environment.Longitude;
          let latitude = environment.Latitude;
          if (this.ToChucToaDoService.List.length > 0) {
            let ListToChucToaDoActive = this.ToChucToaDoService.List.filter((item: any) => item.Active == true);
            if (ListToChucToaDoActive.length > 0) {
            }
            else {
              ListToChucToaDoActive = [];
              ListToChucToaDoActive.push(this.ToChucToaDoService.List[0]);
            }

            if (ListToChucToaDoActive.length > 0) {
              longitude = this.DownloadService.GetKinhDo(Number(ListToChucToaDoActive[0].KinhDo));
              latitude = this.DownloadService.GetViDo(Number(ListToChucToaDoActive[0].ViDo));
            }


            this.MapInitialization(ID, longitude, latitude);



            let html = "<div style='opacity: 0.8; width: 600px; background-color: transparent;'>";
            html = html + "<a style='cursor: pointer;' onclick='OpenWindowByToChuc(" + this.ToChucService.FormData.ID + ")'><h4 style='text-align: center;'><b style='color: blue;'>" + this.ToChucService.FormData.Name + "</b></h4></a>";
            html = html + "<a style='cursor: pointer;' onclick='OpenWindowByToChuc(" + this.ToChucService.FormData.ID + ")'><h5 style='text-align: center;'>Mã số: <b style='color: blue;'>" + this.ToChucService.FormData.Code + "</b></h5></a>";
            html = html + "<table style='width: 100%;'>";
            html = html + "<tr>";
            html = html + "<td style='width: 50%; vertical-align: top;'>";
            html = html + "<div style='padding: 5px;'>Điện thoại: <b>" + this.ToChucService.FormData.DienThoai + "</b></div>";
            html = html + "<div style='padding: 5px;'>Email: <b>" + this.ToChucService.FormData.Email + "</b></div>";
            html = html + "<div style='padding: 5px;'>Quận huyện: <b>" + this.ToChucService.FormData.DanhMucQuanHuyenName + "</b></div>";
            html = html + "<div style='padding: 5px;'>Xã phường: <b>" + this.ToChucService.FormData.DanhMucXaPhuongName + "</b></div>";
            html = html + "<div style='padding: 5px;'>Địa chỉ: <b>" + this.ToChucService.FormData.DiaChi + "</b></div>";
            html = html + "<div style='padding: 5px;'>Đường phố: <b>" + this.ToChucService.FormData.DuongPho + "</b></div>";
            html = html + "<div style='padding: 5px;'>Số nhà: <b>" + this.ToChucService.FormData.SoNha + "</b></div>";
            html = html + "</td>";
            html = html + "<td style='width: 50%; vertical-align: top;'>";
            if (this.ToChucGiongService.List.length > 1) {
              for (let i = 0; i < this.ToChucGiongService.List.length; i++) {
                if (this.ToChucGiongService.List[i].ID) {
                  html = html + "<div style='padding: 5px;'>Loại nuôi (nếu có): <b>" + this.ToChucGiongService.List[i].DanhMucGiongName + "</b></div>";
                }
              }
            }
            else {
              let count = this.ToChucGiongService.List.length - 1;
              html = html + "<div style='padding: 5px;'>Loại nuôi (nếu có): <b>" + count + "</b></div>";
            }
            if (this.ToChucTieuChuanService.List.length > 1) {
              for (let i = 0; i < this.ToChucTieuChuanService.List.length; i++) {
                if (this.ToChucTieuChuanService.List[i].ID) {
                  html = html + "<div style='padding: 5px;'>Tiêu chuẩn (nếu có): <b>" + this.ToChucTieuChuanService.List[i].DanhMucTieuChuanName + "</b></div>";
                }
              }
            }
            else {
              let count = this.ToChucTieuChuanService.List.length - 1;
              html = html + "<div style='padding: 5px;'>Tiêu chuẩn (nếu có): <b>" + count + "</b></div>";
            }
            if (this.ToChucQuanLyService.List.length > 1) {
              for (let i = 0; i < this.ToChucQuanLyService.List.length; i++) {
                if (this.ToChucQuanLyService.List[i].ID) {
                  html = html + "<div style='padding: 5px;'>Hợp tác xã (nếu có): <b>" + this.ToChucQuanLyService.List[i].ToChucName + "</b></div>";
                }
              }
            }
            else {
              let count = this.ToChucQuanLyService.List.length - 1;
              html = html + "<div style='padding: 5px;'>Hợp tác xã (nếu có): <b>" + count + "</b></div>";
            }
            html = html + "</tr>";
            html = html + "</table>";
            html = html + "</div>";

            let popup = new maplibregl.Popup({ offset: 25 }).setHTML(html)
              .setMaxWidth("600px");

            var el = document.createElement('div');
            el.style.backgroundImage = "url(assets/image/IconHoNuoi.png)";
            el.style.width = '30px';
            el.style.height = '42px';

            let marker = new maplibregl.Marker({ element: el })
              .setLngLat([longitude, latitude])
              .setPopup(popup)
              .addTo(this.map);


            let ListToChucToaDoNotActive = this.ToChucToaDoService.List.filter((item: any) => item.Active == false);
            if (ListToChucToaDoNotActive.length > 0) {
              let listToaDoPolygon = [];
              let listPolygon = [];
              for (let j = 0; j < ListToChucToaDoNotActive.length; j++) {
                let longitudeSub1 = this.DownloadService.GetKinhDo(Number(ListToChucToaDoNotActive[j].KinhDo));
                let latitudeSub1 = this.DownloadService.GetViDo(Number(ListToChucToaDoNotActive[j].ViDo));
                listToaDoPolygon.push([longitudeSub1, latitudeSub1]);
              }
              listPolygon.push(listToaDoPolygon);
              let IDDate = new Date().toISOString();
              let layerID = 'Layer_' + this.ToChucService.FormData.ID;
              let sourceID = 'Source_' + this.ToChucService.FormData.ID;
              this.map.on('load', () => {
                this.map.addSource(sourceID, {
                  'type': 'geojson',
                  'data': {
                    'type': 'Feature',
                    'properties': {
                      "name": this.ToChucService.FormData.Name,
                      "address": this.ToChucService.FormData.DiaChi,
                    },
                    'geometry': {
                      'type': 'Polygon',
                      'coordinates': listPolygon,
                    }
                  }
                });
                let color = this.DownloadService.GetRandomColor(ListToChucToaDoNotActive.length);
                this.map.addLayer({
                  'id': layerID,
                  'type': 'fill',
                  'source': sourceID,
                  'paint': {
                    'fill-color': color,
                    'fill-opacity': 0.5,
                    'fill-outline-color': color,
                  }
                });
              });

              let mapSub = this.map;
              this.map.on('click', layerID, function (e) {
                this.map = mapSub;
                let popup = new maplibregl.Popup({ offset: 25 })
                  .setLngLat(e.lngLat)
                  .setHTML(html)
                  .setMaxWidth("600px")
                  .addTo(this.map);
              });
            }
          }
          else {
            this.MapInitialization(ID, longitude, latitude);
          }
        }
      },
      err => {
      },
      () => {
        this.ToChucService.IsShowLoading = false;
      },
    );
  }

}
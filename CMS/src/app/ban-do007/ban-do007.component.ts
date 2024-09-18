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

import { DanhMucQuanHuyen } from 'src/app/shared/DanhMucQuanHuyen.model';
import { DanhMucQuanHuyenService } from 'src/app/shared/DanhMucQuanHuyen.service';
import { DanhMucXaPhuong } from 'src/app/shared/DanhMucXaPhuong.model';
import { DanhMucXaPhuongService } from 'src/app/shared/DanhMucXaPhuong.service';

import { ToChuc } from 'src/app/shared/ToChuc.model';
import { ToChucService } from 'src/app/shared/ToChuc.service';

import * as maplibregl from 'maplibre-gl';

@Component({
  selector: 'app-ban-do007',
  templateUrl: './ban-do007.component.html',
  styleUrls: ['./ban-do007.component.css']
})
export class BanDo007Component implements OnInit {

  IsHoNuoi: boolean = true;
  IsTramQuanTrac: boolean = false;
  IsPhuongTienKhaiThac: boolean = false;
  IsGiong: boolean = false;
  IsVungNuoi: boolean = false;
  IsCuaHang: boolean = false;

  constructor(

    public NotificationService: NotificationService,
    public DownloadService: DownloadService,
    public DanhMucQuanHuyenService: DanhMucQuanHuyenService,
    public DanhMucXaPhuongService: DanhMucXaPhuongService,

    public ToChucService: ToChucService,

  ) { }

  ngOnInit(): void {
    this.DanhMucQuanHuyenSearch();
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
    this.DanhMucXaPhuongService.BaseParameter.ParentID = this.ToChucService.BaseParameter.DanhMucQuanHuyenID;
    this.DanhMucXaPhuongService.GetByParentIDToListAsync().subscribe(
      res => {
        this.DanhMucXaPhuongService.List = (res as DanhMucXaPhuong[]).sort((a, b) => (a.Name > b.Name ? 1 : -1));
        if (this.DanhMucXaPhuongService.List.length > 0) {
          this.ToChucService.BaseParameter.DanhMucXaPhuongID = this.DanhMucXaPhuongService.List[0].ID;
        }
      },
      err => {
      },
      () => {
        this.ToChucService.IsShowLoading = false;
      }
    );
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
    let zoom = 11;
    if (this.ToChucService.BaseParameter.DanhMucXaPhuongID > 0) {
      zoom = 13;
    }
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
    let longitude = environment.Longitude;
    let latitude = environment.Latitude;
    if (this.IsVungNuoi == true) {
      this.MapLoadVungNuoi(ID);
    }
    else {
      this.MapInitialization(ID, longitude, latitude);
      this.MapLoadSub();
    }
  }
  MapLoadSub() {
    if (this.IsHoNuoi == true) {
      this.MapLoadHoNuoi();
    }
    if (this.IsTramQuanTrac == true) {
      this.MapLoadTramQuanTrac();
    }
    if (this.IsCuaHang == true) {
      this.MapLoadCuaHang();
    }
    if (this.IsPhuongTienKhaiThac == true) {
      this.MapLoadPhuongTienKhaiThac();
    }
    if (this.IsGiong == true) {
      this.MapLoadGiong();
    }
  }

  MapLoadHoNuoi() {
    this.ToChucService.IsShowLoading = true;
    this.ToChucService.BaseParameter.ParentID = environment.DanhMucToChucIDHoNuoi;
    this.ToChucService.BaseParameter.Active = true;
    this.ToChucService.GetSQLByParentID_Active_SearchString_DanhMucQuanHuyenID_DanhMucXaPhuongIDToListAsync().subscribe(
      res => {
        this.ToChucService.ListHoNuoi = (res as ToChuc[]);
        let longitude = environment.Longitude;
        let latitude = environment.Latitude;

        if (this.ToChucService.ListHoNuoi) {
          if (this.ToChucService.ListHoNuoi.length > 0) {
            longitude = this.DownloadService.GetKinhDo(Number(this.ToChucService.ListHoNuoi[0].KinhDo));
            latitude = this.DownloadService.GetViDo(Number(this.ToChucService.ListHoNuoi[0].ViDo));
          }
        }

        for (let i = 0; i < this.ToChucService.ListHoNuoi.length; i++) {

          let ToChuc = this.ToChucService.ListHoNuoi[i];

          let html = "<div style='opacity: 0.8; width: 600px; background-color: transparent;'>";
          html = html + "<a style='cursor: pointer;' onclick='OpenWindowByToChuc(" + ToChuc.ID + ")'><h4 style='text-align: center;'><b style='color: blue;'>" + ToChuc.Name + "</b></h4></a>";
          html = html + "<a style='cursor: pointer;' onclick='OpenWindowByToChuc(" + ToChuc.ID + ")'><h5 style='text-align: center;'>Mã số: <b style='color: blue;'>" + ToChuc.Code + " [" + ToChuc.ID + "]</b></h5></a>";
          html = html + "<table style='width: 100%;'>";
          html = html + "<tr>";
          html = html + "<td style='width: 50%; vertical-align: top;'>";
          html = html + "<div style='padding: 5px;'>Điện thoại: <b>" + ToChuc.DienThoai + "</b></div>";
          html = html + "<div style='padding: 5px;'>Email: <b>" + ToChuc.Email + "</b></div>";
          html = html + "<div style='padding: 5px;'>Quận huyện: <b>" + ToChuc.DanhMucQuanHuyenName + "</b></div>";
          html = html + "<div style='padding: 5px;'>Xã phường: <b>" + ToChuc.DanhMucXaPhuongName + "</b></div>";
          html = html + "<div style='padding: 5px;'>Địa chỉ: <b>" + ToChuc.DiaChi + "</b></div>";
          html = html + "<div style='padding: 5px;'>Đường phố: <b>" + ToChuc.DuongPho + "</b></div>";
          html = html + "<div style='padding: 5px;'>Số nhà: <b>" + ToChuc.SoNha + "</b></div>";
          html = html + "</td>";
          html = html + "<td style='width: 50%; vertical-align: top;'>";
          html = html + "</tr>";
          html = html + "</table>";
          html = html + "</div>";

          let popup = new maplibregl.Popup({ offset: 25 }).setHTML(html)
            .setMaxWidth("600px");

          longitude = this.DownloadService.GetKinhDo(Number(ToChuc.KinhDo));
          latitude = this.DownloadService.GetViDo(Number(ToChuc.ViDo));
          var el = document.createElement('div');
          el.style.backgroundImage = "url(assets/image/IconHoNuoi.png)";
          el.style.width = '30px';
          el.style.height = '42px';
          let marker = new maplibregl.Marker({ element: el })
            .setLngLat([longitude, latitude])
            .setPopup(popup)
            .addTo(this.map);

        }

      },
      err => {
      },
      () => {
        this.ToChucService.IsShowLoading = false;
      },
    );
  }

  MapLoadTramQuanTrac() {
    this.ToChucService.IsShowLoading = true;
    this.ToChucService.BaseParameter.ParentID = environment.DanhMucToChucIDTramQuanTrac;
    this.ToChucService.BaseParameter.Active = true;
    this.ToChucService.GetSQLByParentID_Active_SearchString_DanhMucQuanHuyenID_DanhMucXaPhuongIDToListAsync().subscribe(
      res => {
        this.ToChucService.ListTramQuanTrac = (res as ToChuc[]);
        let longitude = environment.Longitude;
        let latitude = environment.Latitude;

        if (this.ToChucService.ListTramQuanTrac) {
          if (this.ToChucService.ListTramQuanTrac.length > 0) {
            longitude = this.DownloadService.GetKinhDo(Number(this.ToChucService.ListTramQuanTrac[0].KinhDo));
            latitude = this.DownloadService.GetViDo(Number(this.ToChucService.ListTramQuanTrac[0].ViDo));
          }
        }

        for (let i = 0; i < this.ToChucService.ListTramQuanTrac.length; i++) {

          let ToChuc = this.ToChucService.ListTramQuanTrac[i];

          let html = "<div style='opacity: 0.8; width: 600px; background-color: transparent;'>";
          html = html + "<a style='cursor: pointer;' onclick='OpenWindowByToChuc(" + ToChuc.ID + ")'><h4 style='text-align: center;'><b style='color: blue;'>" + ToChuc.Name + "</b></h4></a>";
          html = html + "<a style='cursor: pointer;' onclick='OpenWindowByToChuc(" + ToChuc.ID + ")'><h5 style='text-align: center;'>Mã số: <b style='color: blue;'>" + ToChuc.Code + " [" + ToChuc.ID + "]</b></h5></a>";
          html = html + "<table style='width: 100%;'>";
          html = html + "<tr>";
          html = html + "<td style='width: 50%; vertical-align: top;'>";
          html = html + "<div style='padding: 5px;'>Điện thoại: <b>" + ToChuc.DienThoai + "</b></div>";
          html = html + "<div style='padding: 5px;'>Email: <b>" + ToChuc.Email + "</b></div>";
          html = html + "<div style='padding: 5px;'>Quận huyện: <b>" + ToChuc.DanhMucQuanHuyenName + "</b></div>";
          html = html + "<div style='padding: 5px;'>Xã phường: <b>" + ToChuc.DanhMucXaPhuongName + "</b></div>";
          html = html + "<div style='padding: 5px;'>Địa chỉ: <b>" + ToChuc.DiaChi + "</b></div>";
          html = html + "<div style='padding: 5px;'>Đường phố: <b>" + ToChuc.DuongPho + "</b></div>";
          html = html + "<div style='padding: 5px;'>Số nhà: <b>" + ToChuc.SoNha + "</b></div>";
          html = html + "</td>";
          html = html + "<td style='width: 50%; vertical-align: top;'>";
          html = html + "</tr>";
          html = html + "</table>";
          html = html + "</div>";

          let popup = new maplibregl.Popup({ offset: 25 }).setHTML(html)
            .setMaxWidth("600px");

          longitude = this.DownloadService.GetKinhDo(Number(ToChuc.KinhDo));
          latitude = this.DownloadService.GetViDo(Number(ToChuc.ViDo));
          var el = document.createElement('div');
          el.style.backgroundImage = "url(assets/image/IconTramQuanTrac.png)";
          el.style.width = '30px';
          el.style.height = '42px';
          let marker = new maplibregl.Marker({ element: el })
            .setLngLat([longitude, latitude])
            .setPopup(popup)
            .addTo(this.map);

        }

      },
      err => {
      },
      () => {
        this.ToChucService.IsShowLoading = false;
      },
    );
  }

  MapLoadCuaHang() {
    this.ToChucService.IsShowLoading = true;
    this.ToChucService.BaseParameter.ParentID = environment.DanhMucToChucIDCuaHang;
    this.ToChucService.BaseParameter.Active = true;
    this.ToChucService.GetSQLByParentID_Active_SearchString_DanhMucQuanHuyenID_DanhMucXaPhuongIDToListAsync().subscribe(
      res => {
        this.ToChucService.ListCuaHang = (res as ToChuc[]);
        let longitude = environment.Longitude;
        let latitude = environment.Latitude;

        if (this.ToChucService.ListCuaHang) {
          if (this.ToChucService.ListCuaHang.length > 0) {
            longitude = this.DownloadService.GetKinhDo(Number(this.ToChucService.ListCuaHang[0].KinhDo));
            latitude = this.DownloadService.GetViDo(Number(this.ToChucService.ListCuaHang[0].ViDo));
          }
        }


        for (let i = 0; i < this.ToChucService.ListCuaHang.length; i++) {

          let ToChuc = this.ToChucService.ListCuaHang[i];

          let html = "<div style='opacity: 0.8; width: 600px; background-color: transparent;'>";
          html = html + "<a style='cursor: pointer;' onclick='OpenWindowByToChuc(" + ToChuc.ID + ")'><h4 style='text-align: center;'><b style='color: blue;'>" + ToChuc.Name + "</b></h4></a>";
          html = html + "<a style='cursor: pointer;' onclick='OpenWindowByToChuc(" + ToChuc.ID + ")'><h5 style='text-align: center;'>Mã số: <b style='color: blue;'>" + ToChuc.Code + " [" + ToChuc.ID + "]</b></h5></a>";
          html = html + "<table style='width: 100%;'>";
          html = html + "<tr>";
          html = html + "<td style='width: 50%; vertical-align: top;'>";
          html = html + "<div style='padding: 5px;'>Điện thoại: <b>" + ToChuc.DienThoai + "</b></div>";
          html = html + "<div style='padding: 5px;'>Email: <b>" + ToChuc.Email + "</b></div>";
          html = html + "<div style='padding: 5px;'>Quận huyện: <b>" + ToChuc.DanhMucQuanHuyenName + "</b></div>";
          html = html + "<div style='padding: 5px;'>Xã phường: <b>" + ToChuc.DanhMucXaPhuongName + "</b></div>";
          html = html + "<div style='padding: 5px;'>Địa chỉ: <b>" + ToChuc.DiaChi + "</b></div>";
          html = html + "<div style='padding: 5px;'>Đường phố: <b>" + ToChuc.DuongPho + "</b></div>";
          html = html + "<div style='padding: 5px;'>Số nhà: <b>" + ToChuc.SoNha + "</b></div>";
          html = html + "</td>";
          html = html + "<td style='width: 50%; vertical-align: top;'>";
          html = html + "</tr>";
          html = html + "</table>";
          html = html + "</div>";

          let popup = new maplibregl.Popup({ offset: 25 }).setHTML(html)
            .setMaxWidth("600px");

          longitude = this.DownloadService.GetKinhDo(Number(ToChuc.KinhDo));
          latitude = this.DownloadService.GetViDo(Number(ToChuc.ViDo));
          var el = document.createElement('div');
          el.style.backgroundImage = "url(assets/image/IconCuaHang.png)";
          el.style.width = '30px';
          el.style.height = '42px';
          let marker = new maplibregl.Marker({ element: el })
            .setLngLat([longitude, latitude])
            .setPopup(popup)
            .addTo(this.map);

        }

      },
      err => {
      },
      () => {
        this.ToChucService.IsShowLoading = false;
      },
    );
  }

  MapLoadPhuongTienKhaiThac() {
    this.ToChucService.IsShowLoading = true;
    this.ToChucService.BaseParameter.ParentID = environment.DanhMucToChucIDPhuongTienKhaiThac;
    this.ToChucService.BaseParameter.Active = true;
    this.ToChucService.GetSQLByParentID_Active_SearchString_DanhMucQuanHuyenID_DanhMucXaPhuongIDToListAsync().subscribe(
      res => {
        this.ToChucService.ListPhuongTienKhaiThac = (res as ToChuc[]);
        let longitude = environment.Longitude;
        let latitude = environment.Latitude;

        if (this.ToChucService.ListPhuongTienKhaiThac) {
          if (this.ToChucService.ListPhuongTienKhaiThac.length > 0) {
            longitude = this.DownloadService.GetKinhDo(Number(this.ToChucService.ListPhuongTienKhaiThac[0].KinhDo));
            latitude = this.DownloadService.GetViDo(Number(this.ToChucService.ListPhuongTienKhaiThac[0].ViDo));
          }
        }

        for (let i = 0; i < this.ToChucService.ListPhuongTienKhaiThac.length; i++) {

          let ToChuc = this.ToChucService.ListPhuongTienKhaiThac[i];

          let html = "<div style='opacity: 0.8; width: 600px; background-color: transparent;'>";
          html = html + "<a style='cursor: pointer;' onclick='OpenWindowByToChuc(" + ToChuc.ID + ")'><h4 style='text-align: center;'><b style='color: blue;'>" + ToChuc.Name + "</b></h4></a>";
          html = html + "<a style='cursor: pointer;' onclick='OpenWindowByToChuc(" + ToChuc.ID + ")'><h5 style='text-align: center;'>Mã số: <b style='color: blue;'>" + ToChuc.Code + " [" + ToChuc.ID + "]</b></h5></a>";
          html = html + "<table style='width: 100%;'>";
          html = html + "<tr>";
          html = html + "<td style='width: 50%; vertical-align: top;'>";
          html = html + "<div style='padding: 5px;'>Điện thoại: <b>" + ToChuc.DienThoai + "</b></div>";
          html = html + "<div style='padding: 5px;'>Email: <b>" + ToChuc.Email + "</b></div>";
          html = html + "<div style='padding: 5px;'>Quận huyện: <b>" + ToChuc.DanhMucQuanHuyenName + "</b></div>";
          html = html + "<div style='padding: 5px;'>Xã phường: <b>" + ToChuc.DanhMucXaPhuongName + "</b></div>";
          html = html + "<div style='padding: 5px;'>Địa chỉ: <b>" + ToChuc.DiaChi + "</b></div>";
          html = html + "<div style='padding: 5px;'>Đường phố: <b>" + ToChuc.DuongPho + "</b></div>";
          html = html + "<div style='padding: 5px;'>Số nhà: <b>" + ToChuc.SoNha + "</b></div>";
          html = html + "</td>";
          html = html + "<td style='width: 50%; vertical-align: top;'>";
          html = html + "</tr>";
          html = html + "</table>";
          html = html + "</div>";

          let popup = new maplibregl.Popup({ offset: 25 }).setHTML(html)
            .setMaxWidth("600px");

          longitude = this.DownloadService.GetKinhDo(Number(ToChuc.KinhDo));
          latitude = this.DownloadService.GetViDo(Number(ToChuc.ViDo));
          var el = document.createElement('div');
          el.style.backgroundImage = "url(assets/image/IconPhuongTienKhaiThac.png)";
          el.style.width = '30px';
          el.style.height = '42px';
          let marker = new maplibregl.Marker({ element: el })
            .setLngLat([longitude, latitude])
            .setPopup(popup)
            .addTo(this.map);

        }

      },
      err => {
      },
      () => {
        this.ToChucService.IsShowLoading = false;
      },
    );
  }

  MapLoadGiong() {
    this.ToChucService.IsShowLoading = true;
    this.ToChucService.BaseParameter.ParentID = environment.DanhMucToChucIDGiong;
    this.ToChucService.BaseParameter.Active = true;
    this.ToChucService.GetSQLByParentID_Active_SearchString_DanhMucQuanHuyenID_DanhMucXaPhuongIDToListAsync().subscribe(
      res => {
        this.ToChucService.ListGiong = (res as ToChuc[]);
        let longitude = environment.Longitude;
        let latitude = environment.Latitude;

        if (this.ToChucService.ListGiong) {
          if (this.ToChucService.ListGiong.length > 0) {
            longitude = this.DownloadService.GetKinhDo(Number(this.ToChucService.ListGiong[0].KinhDo));
            latitude = this.DownloadService.GetViDo(Number(this.ToChucService.ListGiong[0].ViDo));
          }
        }


        for (let i = 0; i < this.ToChucService.ListGiong.length; i++) {

          let ToChuc = this.ToChucService.ListGiong[i];

          let html = "<div style='opacity: 0.8; width: 600px; background-color: transparent;'>";
          html = html + "<a style='cursor: pointer;' onclick='OpenWindowByToChuc(" + ToChuc.ID + ")'><h4 style='text-align: center;'><b style='color: blue;'>" + ToChuc.Name + "</b></h4></a>";
          html = html + "<a style='cursor: pointer;' onclick='OpenWindowByToChuc(" + ToChuc.ID + ")'><h5 style='text-align: center;'>Mã số: <b style='color: blue;'>" + ToChuc.Code + " [" + ToChuc.ID + "]</b></h5></a>";
          html = html + "<table style='width: 100%;'>";
          html = html + "<tr>";
          html = html + "<td style='width: 50%; vertical-align: top;'>";
          html = html + "<div style='padding: 5px;'>Điện thoại: <b>" + ToChuc.DienThoai + "</b></div>";
          html = html + "<div style='padding: 5px;'>Email: <b>" + ToChuc.Email + "</b></div>";
          html = html + "<div style='padding: 5px;'>Quận huyện: <b>" + ToChuc.DanhMucQuanHuyenName + "</b></div>";
          html = html + "<div style='padding: 5px;'>Xã phường: <b>" + ToChuc.DanhMucXaPhuongName + "</b></div>";
          html = html + "<div style='padding: 5px;'>Địa chỉ: <b>" + ToChuc.DiaChi + "</b></div>";
          html = html + "<div style='padding: 5px;'>Đường phố: <b>" + ToChuc.DuongPho + "</b></div>";
          html = html + "<div style='padding: 5px;'>Số nhà: <b>" + ToChuc.SoNha + "</b></div>";
          html = html + "</td>";
          html = html + "<td style='width: 50%; vertical-align: top;'>";
          html = html + "</tr>";
          html = html + "</table>";
          html = html + "</div>";

          let popup = new maplibregl.Popup({ offset: 25 }).setHTML(html)
            .setMaxWidth("600px");

          longitude = this.DownloadService.GetKinhDo(Number(ToChuc.KinhDo));
          latitude = this.DownloadService.GetViDo(Number(ToChuc.ViDo));
          var el = document.createElement('div');
          el.style.backgroundImage = "url(assets/image/IconGiong.png)";
          el.style.width = '30px';
          el.style.height = '42px';
          let marker = new maplibregl.Marker({ element: el })
            .setLngLat([longitude, latitude])
            .setPopup(popup)
            .addTo(this.map);

        }

      },
      err => {
      },
      () => {
        this.ToChucService.IsShowLoading = false;
      },
    );
  }

  MapLoadVungNuoi(ID: number) {
    this.ToChucService.IsShowLoading = true;
    this.ToChucService.BaseParameter.ParentID = environment.DanhMucToChucIDHoNuoi;
    this.ToChucService.BaseParameter.Active = false;
    this.ToChucService.GetSQLByParentID_Active_SearchString_DanhMucQuanHuyenID_DanhMucXaPhuongIDToListAsync().subscribe(
      res => {
        this.ToChucService.ListVungNuoi = (res as ToChuc[]);
        let longitude = environment.Longitude;
        let latitude = environment.Latitude;

        if (this.ToChucService.ListVungNuoi) {
          if (this.ToChucService.ListVungNuoi.length > 0) {
            longitude = this.DownloadService.GetKinhDo(Number(this.ToChucService.ListVungNuoi[0].KinhDo));
            latitude = this.DownloadService.GetViDo(Number(this.ToChucService.ListVungNuoi[0].ViDo));
          }
        }
        this.MapInitialization(ID, longitude, latitude);
        this.MapLoadSub();

        let ListToChucID = [...new Map(this.ToChucService.ListVungNuoi.map(item =>
          [item["ID"], item])).values()];


        for (let i = 0; i < ListToChucID.length; i++) {
          let ListToChuc = this.ToChucService.ListVungNuoi.filter((item: any) => item.ID == ListToChucID[i].ID);
          if (ListToChuc) {
            if (ListToChuc.length > 0) {

              let listToaDoPolygon = [];
              let listPolygon = [];
              for (let j = 0; j < ListToChuc.length; j++) {
                let longitudeSub1 = this.DownloadService.GetKinhDo(Number(ListToChuc[j].KinhDo));
                let latitudeSub1 = this.DownloadService.GetViDo(Number(ListToChuc[j].ViDo));
                listToaDoPolygon.push([longitudeSub1, latitudeSub1]);
              }
              listPolygon.push(listToaDoPolygon);

              let ToChuc = ListToChuc[0];
              let html = "<div style='opacity: 0.8; width: 600px; background-color: transparent;'>";
              html = html + "<a style='cursor: pointer;' onclick='OpenWindowByToChuc(" + ToChuc.ID + ")'><h4 style='text-align: center;'><b style='color: blue;'>" + ToChuc.Name + "</b></h4></a>";
              html = html + "<a style='cursor: pointer;' onclick='OpenWindowByToChuc(" + ToChuc.ID + ")'><h5 style='text-align: center;'>Mã số: <b style='color: blue;'>" + ToChuc.Code + " [" + ToChuc.ID + "]</b></h5></a>";
              html = html + "<table style='width: 100%;'>";
              html = html + "<tr>";
              html = html + "<td style='width: 50%; vertical-align: top;'>";
              html = html + "<div style='padding: 5px;'>Điện thoại: <b>" + ToChuc.DienThoai + "</b></div>";
              html = html + "<div style='padding: 5px;'>Email: <b>" + ToChuc.Email + "</b></div>";
              html = html + "<div style='padding: 5px;'>Quận huyện: <b>" + ToChuc.DanhMucQuanHuyenName + "</b></div>";
              html = html + "<div style='padding: 5px;'>Xã phường: <b>" + ToChuc.DanhMucXaPhuongName + "</b></div>";
              html = html + "<div style='padding: 5px;'>Địa chỉ: <b>" + ToChuc.DiaChi + "</b></div>";
              html = html + "<div style='padding: 5px;'>Đường phố: <b>" + ToChuc.DuongPho + "</b></div>";
              html = html + "<div style='padding: 5px;'>Số nhà: <b>" + ToChuc.SoNha + "</b></div>";
              html = html + "</td>";
              html = html + "<td style='width: 50%; vertical-align: top;'>";
              html = html + "</tr>";
              html = html + "</table>";
              html = html + "</div>";

              let layerID = 'Layer_' + ToChuc.ID;
              let sourceID = 'Source_' + ToChuc.ID;

              this.map.on('load', () => {
                this.map.addSource(sourceID, {
                  'type': 'geojson',
                  'data': {
                    'type': 'Feature',
                    'properties': {
                      "name": ToChuc.Name,
                      "address": ToChuc.DiaChi,
                    },
                    'geometry': {
                      'type': 'Polygon',
                      'coordinates': listPolygon,
                    }
                  }
                });
                let color = this.DownloadService.GetRandomColor(ListToChuc.length);
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
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


import { DanhMucTinhThanhToaDo } from 'src/app/shared/DanhMucTinhThanhToaDo.model';
import { DanhMucTinhThanhToaDoService } from 'src/app/shared/DanhMucTinhThanhToaDo.service';

import { Report } from 'src/app/shared/Report.model';
import { ReportService } from 'src/app/shared/Report.service';

import * as maplibregl from 'maplibre-gl';

@Component({
  selector: 'app-ban-do000',
  templateUrl: './ban-do000.component.html',
  styleUrls: ['./ban-do000.component.css']
})
export class BanDo000Component implements OnInit {

  IsPopup: boolean = false;
  PopupContent: string = environment.InitializationString;
  constructor(

    public NotificationService: NotificationService,
    public DownloadService: DownloadService,
    public DanhMucQuanHuyenService: DanhMucQuanHuyenService,

    public DanhMucTinhThanhToaDoService: DanhMucTinhThanhToaDoService,
    public ReportService: ReportService,

  ) { }

  ngOnInit(): void {
    this.DanhMucQuanHuyenSearch();
  }

  DanhMucQuanHuyenSearch() {
    this.DanhMucTinhThanhToaDoService.BaseParameter.ParentID = environment.InitializationNumber;
    if (this.DanhMucQuanHuyenService.List) {
      if (this.DanhMucQuanHuyenService.List.length == 0) {
        this.DanhMucTinhThanhToaDoService.IsShowLoading = true;
        this.DanhMucQuanHuyenService.GetAllToListAsync().subscribe(
          res => {
            this.DanhMucQuanHuyenService.List = (res as DanhMucQuanHuyen[]).sort((a, b) => (a.Name > b.Name ? 1 : -1));
            this.DanhMucQuanHuyenService.ListFilter = this.DanhMucQuanHuyenService.List;

            this.DanhMucTinhThanhToaDoService.BaseParameter.ParentID = environment.DanhMucQuanHuyenID;
          },
          err => {
          },
          () => {
            this.DanhMucTinhThanhToaDoService.IsShowLoading = false;
          }
        );
      }
    }
  }

  PopupClose() {
    this.IsPopup = false;
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
    let zoom = 10;
    if (this.DanhMucTinhThanhToaDoService.BaseParameter.ParentID > 0) {
      zoom = 11;
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
    this.DanhMucTinhThanhToaDoService.IsShowLoading = true;
    this.DanhMucTinhThanhToaDoService.GetSQLByParentIDToListAsync().subscribe(
      res => {
        this.DanhMucTinhThanhToaDoService.List = (res as DanhMucTinhThanhToaDo[]);

        let longitude = environment.Longitude;
        let latitude = environment.Latitude;

        if (this.DanhMucTinhThanhToaDoService.List) {
          if (this.DanhMucTinhThanhToaDoService.List.length > 0) {
            longitude = this.DownloadService.GetKinhDo(Number(this.DanhMucTinhThanhToaDoService.List[0].KinhDo));
            latitude = this.DownloadService.GetViDo(Number(this.DanhMucTinhThanhToaDoService.List[0].ViDo));
          }
        }

        this.MapInitialization(ID, longitude, latitude);

        let ListParent = [];

        if (this.DanhMucTinhThanhToaDoService.BaseParameter.ParentID > 0) {
          ListParent = [...new Map(this.DanhMucTinhThanhToaDoService.List.map(item =>
            [item["DanhMucXaPhuongID"], item])).values()];
        }
        else {
          ListParent = [...new Map(this.DanhMucTinhThanhToaDoService.List.map(item =>
            [item["DanhMucQuanHuyenID"], item])).values()];
        }

        for (let i = 0; i < ListParent.length; i++) {
          let ListDanhMucTinhThanhToaDo = this.DanhMucTinhThanhToaDoService.List.filter((item: any) => item.ParentID == ListParent[i].ParentID);
          if (ListDanhMucTinhThanhToaDo) {
            if (ListDanhMucTinhThanhToaDo.length > 0) {
              let listToaDoPolygon = [];
              let listPolygon = [];
              let Name = environment.InitializationString;
              for (let j = 0; j < ListDanhMucTinhThanhToaDo.length; j++) {
                let longitudeSub1 = this.DownloadService.GetKinhDo(Number(ListDanhMucTinhThanhToaDo[j].KinhDo));
                let latitudeSub1 = this.DownloadService.GetViDo(Number(ListDanhMucTinhThanhToaDo[j].ViDo));
                listToaDoPolygon.push([longitudeSub1, latitudeSub1]);

                Name = ListDanhMucTinhThanhToaDo[j].Name;
              }
              listPolygon.push(listToaDoPolygon);
              let layerID = 'Layer_' + ListParent[i].ID;
              let sourceID = 'Source_' + ListParent[i].ID;
              this.map.on('load', () => {
                this.map.addSource(sourceID, {
                  'type': 'geojson',
                  'data': {
                    'type': 'Feature',
                    'properties': {
                      "name": Name,
                      "address": Name,
                    },
                    'geometry': {
                      'type': 'Polygon',
                      'coordinates': listPolygon,
                    }
                  }
                });

                let length = ListDanhMucTinhThanhToaDo.length + ListParent[i].ParentID + ListParent[i].ID;
                let color = this.DownloadService.GetRandomColor(length);

                this.map.addLayer({
                  'id': layerID + 'Line',
                  'type': 'line',
                  'source': sourceID,
                  'paint': {
                    'line-dasharray': [3, 1],
                    "line-color": color,
                    "line-width": environment.LineWidth,
                  }
                });

                this.map.addLayer({
                  'id': layerID,
                  'type': 'fill',
                  'source': sourceID,
                  'paint': {
                    'fill-color': color,
                    'fill-opacity': 0.2,
                  }
                });

              });
            }
          }
        }

        this.Report000012Search();

      },
      err => {
      },
      () => {
        this.DanhMucTinhThanhToaDoService.IsShowLoading = false;
      },
    );

  }

  Report000012Search() {
    this.ReportService.BaseParameter.ParentID = this.DanhMucTinhThanhToaDoService.BaseParameter.ParentID;
    this.ReportService.Report000012ToListAsync().subscribe(
      res => {
        this.ReportService.List000012 = (res as Report[]);
        let ListParent = [...new Map(this.ReportService.List000012.map(item =>
          [item["ParentID"], item])).values()];

        for (let i = 0; i < ListParent.length; i++) {
          let ListReport = this.ReportService.List000012.filter((item: any) => item.ParentID == ListParent[i].ParentID);
          if (ListReport) {
            if (ListReport.length > 0) {
              let Report = ListReport[0];

              let html = "<div style='width: 200px; padding-top: 40px; margin-left: -80px;'>";
              html = html + "<div style='border: 0px solid #ffffff; padding: 5px;'>";
              html = html + "<div style='color: red; font-size: 14px; text-align: center;'><b>" + Report.ParentName + "</b></div>";
              html = html + "</div>";
              html = html + "</div>";

              var el = document.createElement('div');
              el.innerHTML = html;
              el.style.backgroundImage = "url(assets/image/Icon.png)";
              el.style.width = '30px';
              el.style.height = '42px';
              let ViDo = Number(Report.ViDo);
              let KinhDo = Number(Report.KinhDo);
              let marker = new maplibregl.Marker({ element: el })
                .setLngLat([KinhDo, ViDo])
                .addTo(this.map);
              marker.getElement().addEventListener('click', () => {
                this.IsPopup = true;
                this.PopupContent = "<h3 style='color: red; font-size: 14px; text-align: center;'><b>" + Report.ParentName + "</b></h3>";
                this.PopupContent = this.PopupContent + "<hr/>";
                for (let j = 0; j < ListReport.length; j++) {
                  let stt = j + 1;
                  if (ListReport[j].ThongKe001 > 0) {
                    this.PopupContent = this.PopupContent + "<h5>" + stt + ". " + ListReport[j].DanhMucToChucName + ": <b>" + ListReport[j].ThongKe001 + "</b></h5>";
                  }
                  else {
                    this.PopupContent = this.PopupContent + "<h5>" + stt + ". " + ListReport[j].DanhMucToChucName + ": <b>---</b></h5>";
                  }
                }
              });

            }
          }
        }

      },
      err => {
      },
      () => {

      },
    );
  }

}
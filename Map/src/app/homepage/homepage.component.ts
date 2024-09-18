import { Component, OnInit, ViewChild, ElementRef, AfterViewInit, OnDestroy } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { Router, NavigationEnd, ActivatedRoute } from '@angular/router';
import { environment } from 'src/environments/environment';
import { draw } from 'src/environments/environment';
import { NotificationService } from 'src/app/shared/Notification.service';
import { DownloadService } from 'src/app/shared/Download.service';

import { ToChuc } from 'src/app/shared/ToChuc.model';
import { ToChucService } from 'src/app/shared/ToChuc.service';
import { ToChucToaDo } from 'src/app/shared/ToChucToaDo.model';
import { ToChucToaDoService } from 'src/app/shared/ToChucToaDo.service';
import { ToChucVungNuoi } from 'src/app/shared/ToChucVungNuoi.model';
import { ToChucVungNuoiService } from 'src/app/shared/ToChucVungNuoi.service';

import * as maplibregl from 'maplibre-gl';

import * as MapboxDraw from '@mapbox/mapbox-gl-draw';



@Component({
  selector: 'app-homepage',
  templateUrl: './homepage.component.html',
  styleUrls: ['./homepage.component.css']
})
export class HomepageComponent implements OnInit {

  map: maplibregl.Map | undefined;

  @ViewChild('map')
  private mapContainer!: ElementRef<HTMLElement>;

  constructor(
    private Dialog: MatDialog,
    public ActivatedRoute: ActivatedRoute,
    public NotificationService: NotificationService,
    public DownloadService: DownloadService,

    public ToChucService: ToChucService,
    public ToChucVungNuoiService: ToChucVungNuoiService,
    public ToChucToaDoService: ToChucToaDoService,

  ) { }

  ngOnInit(): void {
  }
  ngAfterViewInit() {
    this.ActivatedRoute.paramMap.subscribe((params) => {
      this.ToChucService.BaseParameter.ID = Number(params.get('ID')!);
      this.MapLoad(1);
    });
  }
  ngOnDestroy() {
    this.map?.remove();
  }

  Save() {
    let polygon = JSON.parse(localStorage.getItem(environment.Polygon));
    if (polygon) {
      if (polygon.length > 0) {
        this.ToChucService.IsShowLoading = true;
        this.ToChucVungNuoiService.FormData.ParentID = this.ToChucService.FormData.ID;
        this.ToChucVungNuoiService.FormData.ParentName = this.ToChucService.FormData.Name;
        this.ToChucVungNuoiService.SaveAsync().subscribe(
          res => {
            this.ToChucVungNuoiService.FormData = res as ToChucVungNuoi;
            if (this.ToChucToaDoService.FormData.Active == true) {
              this.ToChucToaDoService.FormData.ID = environment.InitializationNumber;
              this.ToChucToaDoService.FormData.ParentID = this.ToChucService.FormData.ID;
              this.ToChucToaDoService.FormData.ParentName = this.ToChucService.FormData.Name;
              this.ToChucToaDoService.FormData.Code = this.ToChucService.FormData.Code;
              this.ToChucToaDoService.FormData.KinhDo = polygon[0][0];
              this.ToChucToaDoService.FormData.ViDo = polygon[0][1];
              this.ToChucToaDoService.List.push(this.ToChucToaDoService.FormData);
            }
            else {
              for (let i = 0; i < polygon.length; i++) {
                this.ToChucToaDoService.FormData.ID = environment.InitializationNumber;
                this.ToChucToaDoService.FormData.ToChucVungNuoiID = this.ToChucVungNuoiService.FormData.ID;
                this.ToChucToaDoService.FormData.ToChucVungNuoiName = this.ToChucVungNuoiService.FormData.Name;
                this.ToChucToaDoService.FormData.Code = this.ToChucVungNuoiService.FormData.Code;
                this.ToChucToaDoService.FormData.ParentID = this.ToChucService.FormData.ID;
                this.ToChucToaDoService.FormData.ParentName = this.ToChucService.FormData.Name;                
                this.ToChucToaDoService.FormData.KinhDo = polygon[i][0];
                this.ToChucToaDoService.FormData.ViDo = polygon[i][1];
                this.ToChucToaDoService.List.push(this.ToChucToaDoService.FormData);
              }
            }
            this.ToChucToaDoService.SaveListAsync(this.ToChucToaDoService.List).subscribe(
              res => {
                this.NotificationService.warn(environment.SaveSuccess);
              },
              err => {
                this.NotificationService.warn(environment.SaveNotSuccess);
              },
              () => {
                this.ToChucService.IsShowLoading = false;
              }
            );
          },
          err => {

          },
          () => {

          }
        );

      }
      else {
        this.NotificationService.warn(environment.ToChucToaDoSaveThongBao);
      }
    }
    else {
      this.NotificationService.warn(environment.ToChucToaDoSaveThongBao);
    }


  }

  MapInitialization(ID, longitude, latitude) {

    MapboxDraw.constants.classes.CONTROL_BASE = 'maplibregl-ctrl';
    MapboxDraw.constants.classes.CONTROL_PREFIX = 'maplibregl-ctrl-';
    MapboxDraw.constants.classes.CONTROL_GROUP = 'maplibregl-ctrl-group';

    let zoom = environment.MapZoom;
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
      });
    }
    if (ID == 1) {
      this.map = new maplibregl.Map({
        container: this.mapContainer.nativeElement,
        style: 'https://api.maptiler.com/maps/hybrid/style.json?key=' + environment.MaptilerAPIKey,
        center: [longitude, latitude],
        zoom: zoom,
      });
    }
    this.map.addControl(
      new maplibregl.NavigationControl({
        visualizePitch: true,
        showZoom: true,
        showCompass: true,
      })
    );

    this.map.addControl(
      new maplibregl.FullscreenControl({
      })
    );

    this.map.addControl(draw);
    this.map.on('draw.create', this.UpdateArea);
    this.map.on('draw.delete', this.UpdateArea);
    this.map.on('draw.update', this.UpdateArea);

    let mapSub = this.map;
    this.map.on('load', () => {
      this.map = mapSub;
      this.map.addSource("HoangSa", {
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
        "id": "HoangSa",
        "source": "HoangSa",
        "type": "raster",
        "paint": {
          "raster-opacity": 1
        }
      });

      this.map.addSource("TruongSa", {
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
        "id": "TruongSa",
        "source": "TruongSa",
        "type": "raster",
        "paint": {
          "raster-opacity": 1
        }
      });

    });
  }
  UpdateArea() {
    const data = draw.getAll();
    if (data.features.length > 0) {
      let features = data["features"];
      let lastIndex = features.length - 1;
      let geometry = features[lastIndex]["geometry"];
      let coordinates = geometry["coordinates"];
      let polygon = [];
      for (let i = 0; i < coordinates[0].length; i++) {
        polygon.push(coordinates[0][i]);
      }
      localStorage.setItem(environment.Polygon, JSON.stringify(polygon));
    }
  }
  MapLoad(ID: number) {

    this.ToChucService.IsShowLoading = true;
    this.ToChucService.GetByIDAsync().subscribe(
      res => {
        this.ToChucService.FormData = (res as ToChuc);
        if (this.ToChucService.FormData) {
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


                  var el = document.createElement('div');
                  el.style.backgroundImage = "url(assets/image/Icon.png)";
                  el.style.width = '30px';
                  el.style.height = '42px';

                  let marker = new maplibregl.Marker({ element: el })
                    .setLngLat([longitude, latitude])
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
            }
          );

        }
      },
      err => {

      },
      () => {
        this.ToChucService.IsShowLoading = false;
      }
    );

  }
}

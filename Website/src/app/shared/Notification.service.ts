import { Injectable } from '@angular/core';
import { MatSnackBar, MatSnackBarConfig } from '@angular/material/snack-bar';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class NotificationService {

  IsSave: boolean = false;
  IsMobile: boolean = false;
  IsMobileDevice: boolean = false;
  ThanhVienID: number = 0;
  constructor(public snackBar: MatSnackBar) {
    if (localStorage.getItem(environment.ThanhVienID)) {
      this.ThanhVienID = Number(localStorage.getItem(environment.ThanhVienID));
    }
    let windowWidth = Math.floor(window.innerWidth);

    if (windowWidth < 700) {
      this.IsMobile = true;
    }
    this.IsMobileDevice = /iPhone|iPad|iPod|Android/i.test(navigator.userAgent);
    this.IsSave=false;
  }

  config: MatSnackBarConfig = {
    duration: 3000,
    horizontalPosition: 'right',
    verticalPosition: 'bottom'
  }
  success(message: string) {
    this.config['panelClass'] = ['notification', 'success'];
    this.snackBar.open(message, '', this.config);
  }

  warn(message: string) {
    this.config['panelClass'] = ['notification', 'warn'];
    this.snackBar.open(message, '', this.config);
    this.IsSave=true;
  }
  OpenWindowByURL(URLParamater, w = 100, h = 200) {
    var width = screen.width;
    var height = screen.height;
    var width01 = width - w;
    var height01 = height - h;
    var left = (width - width01) / 2;
    var top = (height - height01) / 3;
    var url = URLParamater;
    window.open(url, '_blank', 'location=yes,height=' + height01 + ',width=' + width01 + ',scrollbars=yes,status=yes,toolbar=yes,top=' + top + ',left=' + left + '');
  }
}

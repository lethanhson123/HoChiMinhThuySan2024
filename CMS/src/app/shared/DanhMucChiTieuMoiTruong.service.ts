import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { DanhMucChiTieuMoiTruong } from 'src/app/shared/DanhMucChiTieuMoiTruong.model';
import { BaseService } from './Base.service';
@Injectable({
    providedIn: 'root'
})
export class DanhMucChiTieuMoiTruongService extends BaseService{
    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.Controller = "DanhMucChiTieuMoiTruong";
    }
}


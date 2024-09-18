import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { DanhMucLoaiGiong } from 'src/app/shared/DanhMucLoaiGiong.model';
import { BaseService } from './Base.service';
@Injectable({
    providedIn: 'root'
})
export class DanhMucLoaiGiongService extends BaseService{
    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.Controller = "DanhMucLoaiGiong";
    }
}


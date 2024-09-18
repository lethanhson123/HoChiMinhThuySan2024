import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { DanhMucQuocGia } from 'src/app/shared/DanhMucQuocGia.model';
import { BaseService } from './Base.service';
@Injectable({
    providedIn: 'root'
})
export class DanhMucQuocGiaService extends BaseService{
    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.Controller = "DanhMucQuocGia";
    }
}


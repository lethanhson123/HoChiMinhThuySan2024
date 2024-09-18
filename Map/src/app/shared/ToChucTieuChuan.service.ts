import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { ToChucTieuChuan } from 'src/app/shared/ToChucTieuChuan.model';
import { BaseService } from './Base.service';
@Injectable({
    providedIn: 'root'
})
export class ToChucTieuChuanService extends BaseService{

    DisplayColumns001: string[] = ['STT', 'ID', 'DanhMucTieuChuanID', 'Name', 'NamGhiNhan', 'Save'];
        
    List: ToChucTieuChuan[] | undefined;
    ListFilter: ToChucTieuChuan[] | undefined;
    FormData!: ToChucTieuChuan;    

    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.Controller = "ToChucTieuChuan";
    }
}


import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { ToChucVungNuoi } from 'src/app/shared/ToChucVungNuoi.model';
import { BaseService } from './Base.service';
@Injectable({
    providedIn: 'root'
})
export class ToChucVungNuoiService extends BaseService{

    DisplayColumns001: string[] = ['STT', 'ID', 'Name', 'Code', 'Description', 'TypeName', 'Save'];

    DisplayColumns002: string[] = ['STT', 'ID', 'Name', 'Code', 'Description', 'DanhMucLoaiGiongID', 'DanhMucLoaiGiongName', 'DanhMucGiongID', 'DanhMucGiongName', 'SoLuong', 'MatDoTha', 'SanLuong', 'NangSuat', 'TypeName', 'Save'];

    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.Controller = "ToChucVungNuoi";
    }
}


import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { ChiTieuMoiTruong } from 'src/app/shared/ChiTieuMoiTruong.model';
import { BaseService } from './Base.service';
@Injectable({
    providedIn: 'root'
})
export class ChiTieuMoiTruongService extends BaseService{

    DisplayColumns001: string[] = ['STT', 'ID', 'NgayGhiNhan', 'ToChucID', 'DanhMucChiTieuMoiTruongID', 'DanhMucChiTieuMoiTruongName', 'SoLieu', 'Display', 'Description', 'Save'];
   
    List: ChiTieuMoiTruong[] | undefined;
    ListFilter: ChiTieuMoiTruong[] | undefined;
    FormData!: ChiTieuMoiTruong;
    

    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.Controller = "ChiTieuMoiTruong";
    }

    GetByBatDau_KetThucToListAsync() {
        let url = this.APIURL + this.Controller + '/GetByBatDau_KetThucToListAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    GetByBatDau_KetThucAndEmptyToListAsync() {
        let url = this.APIURL + this.Controller + '/GetByBatDau_KetThucAndEmptyToListAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
}


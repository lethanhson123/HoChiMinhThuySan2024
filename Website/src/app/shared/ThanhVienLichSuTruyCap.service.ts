import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { ThanhVienLichSuTruyCap } from 'src/app/shared/ThanhVienLichSuTruyCap.model';
import { BaseService } from './Base.service';
@Injectable({
    providedIn: 'root'
})
export class ThanhVienLichSuTruyCapService extends BaseService{

    DisplayColumns001: string[] = ['STT', 'NgayGhiNhan', 'Name', 'Code', 'URL', 'IPAddress', 'DanhMucQuocGiaName', 'DanhMucTinhThanhName', 'DanhMucQuanHuyenName', 'KinhDo', 'ViDo', 'TypeName'];
        
    List: ThanhVienLichSuTruyCap[] | undefined;
    ListFilter: ThanhVienLichSuTruyCap[] | undefined;
    FormData!: ThanhVienLichSuTruyCap;

    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.Controller = "ThanhVienLichSuTruyCap";
    }

    GetByBatDau_KetThucToListAsync() {
        let url = this.APIURL + this.Controller + '/GetByBatDau_KetThucToListAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));       
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    GetBySearchString_BatDau_KetThucToListAsync() {
        let url = this.APIURL + this.Controller + '/GetBySearchString_BatDau_KetThucToListAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));       
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
}


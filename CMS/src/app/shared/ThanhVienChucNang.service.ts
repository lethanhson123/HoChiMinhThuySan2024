import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { ThanhVienChucNang } from 'src/app/shared/ThanhVienChucNang.model';
import { BaseService } from './Base.service';
@Injectable({
    providedIn: 'root'
})
export class ThanhVienChucNangService extends BaseService{

    DisplayColumns001: string[] = ['STT', 'Name', 'Active'];   
    DisplayColumns002: string[] = ['DanhMucThanhVienID', 'Save'];   
        
    List: ThanhVienChucNang[] | undefined;
    ListFilter: ThanhVienChucNang[] | undefined;
    FormData!: ThanhVienChucNang;

    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.Controller = "ThanhVienChucNang";
    }

    GetSQLByParentIDToListAsync() {
        let url = this.APIURL + this.Controller + '/GetSQLByParentIDToListAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    GetSQLByDanhMucThanhVienIDToListAsync() {
        let url = this.APIURL + this.Controller + '/GetSQLByDanhMucThanhVienIDToListAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    GetByDanhMucChucNangIDAndEmptyToListAsync() {
        let url = this.APIURL + this.Controller + '/GetByDanhMucChucNangIDAndEmptyToListAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
}


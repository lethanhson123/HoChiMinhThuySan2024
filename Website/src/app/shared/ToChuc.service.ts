import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { ToChuc } from 'src/app/shared/ToChuc.model';
import { BaseService } from './Base.service';
@Injectable({
    providedIn: 'root'
})
export class ToChucService extends BaseService{


    DisplayColumns001: string[] = ['STT', 'ID', 'Name', 'DanhMucQuanHuyenName', 'DanhMucXaPhuongName', 'Active', 'Save'];
    DisplayColumns002: string[] = ['STT', 'ID', 'Code', 'Name', 'DanhMucQuanHuyenName', 'DanhMucXaPhuongName', 'Active', 'Save'];
        
    APIURL: string = environment.APIURL;
    List: ToChuc[] | undefined;
    ListFilter: ToChuc[] | undefined;
    ListHoNuoi: ToChuc[] | undefined;
    ListHopTacXa: ToChuc[] | undefined;
    ListMap: ToChuc[] | undefined;   
    ListVungNuoi: ToChuc[] | undefined;
    ListTramQuanTrac: ToChuc[] | undefined;
    ListCuaHang: ToChuc[] | undefined;
    ListPhuongTienKhaiThac: ToChuc[] | undefined;
    ListGiong: ToChuc[] | undefined;
    FormData!: ToChuc;    


    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.Controller = "ToChuc";
    }

    GetByParentIDAndSearchString_DanhMucQuanHuyenID_DanhMucXaPhuongIDAsync() {
        let url = this.APIURL + this.Controller + '/GetByParentIDAndSearchString_DanhMucQuanHuyenID_DanhMucXaPhuongIDAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    GetSQLByParentID_ActiveToListAsync() {
        let url = this.APIURL + this.Controller + '/GetSQLByParentID_ActiveToListAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    GetSQLByParentID_Active_SearchStringToListAsync() {
        let url = this.APIURL + this.Controller + '/GetSQLByParentID_Active_SearchStringToListAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    GetSQLByParentID_Active_SearchString_DanhMucQuanHuyenID_DanhMucXaPhuongIDToListAsync() {
        let url = this.APIURL + this.Controller + '/GetSQLByParentID_Active_SearchString_DanhMucQuanHuyenID_DanhMucXaPhuongIDToListAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    GetSQLByDanhMucGiongIDToListAsync() {
        let url = this.APIURL + this.Controller + '/GetSQLByDanhMucGiongIDToListAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    GetSQLByDanhMucGiongID_ActiveToListAsync() {
        let url = this.APIURL + this.Controller + '/GetSQLByDanhMucGiongID_ActiveToListAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
}


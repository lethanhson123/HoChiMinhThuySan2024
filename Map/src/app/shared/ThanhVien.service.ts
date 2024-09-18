import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { ThanhVien } from 'src/app/shared/ThanhVien.model';
import { BaseService } from './Base.service';
@Injectable({
    providedIn: 'root'
})
export class ThanhVienService extends BaseService{

    DisplayColumns001: string[] = ['STT', 'ID', 'ParentName', 'Name', 'TaiKhoan', 'DienThoai', 'Active'];
    DisplayColumns002: string[] = ['STT', 'ID', 'Code', 'TaiKhoan', 'Name', 'DienThoai', 'DiaChi', 'DanhMucXaPhuongName', 'Active'];
    DisplayColumns003: string[] = ['STT', 'ID', 'TaiKhoan', 'Name', 'DienThoai', 'DanhMucQuanHuyenName', 'DanhMucXaPhuongName', 'Active'];
    DisplayColumns004: string[] = ['STT', 'ID', 'TaiKhoan', 'Name', 'DienThoai', 'DanhMucQuanHuyenName', 'DanhMucXaPhuongName', 'DiaChi', 'Active'];
    DisplayColumns005: string[] = ['STT', 'ID', 'TaiKhoan', 'Name', 'DienThoai', 'DanhMucQuanHuyenName', 'DanhMucXaPhuongName', 'DiaChi', 'Active', 'VungTrong'];
        
    List: ThanhVien[] | undefined;
    ListFilter: ThanhVien[] | undefined;
    FormData!: ThanhVien;
    FormDataLogin!: ThanhVien;

    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.Controller = "ThanhVien";
        this.FormDataLogin = {
            Name: environment.InitializationString,
        }; 
    }

    GetLogin() {
        this.FormDataLogin = {
        }
        this.FormDataLogin.Name = localStorage.getItem(environment.ThanhVienHoTen);
        var LastUpdatedMembershipID = localStorage.getItem(environment.ThanhVienID);
        if (LastUpdatedMembershipID) {
            this.FormDataLogin.ID = Number(LastUpdatedMembershipID);
        }
       
    }
    SaveSyncAsync() {
        let url = this.APIURL + this.Controller + '/SaveSyncAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.FormData));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    SaveListSyncAsync(list: ThanhVien[]) {
        let url = this.APIURL + this.Controller + '/SaveListSyncAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(list));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    AuthenticationAsync() {
        let url = this.APIURL + this.Controller + '/AuthenticationAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.FormData));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    ChangePasswordAsync() {
        let url = this.APIURL + this.Controller + '/ChangePasswordAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.FormData));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    PostThanhVienByExcelFileAsync() {
        let url = this.APIURL + this.Controller + '/PostThanhVienByExcelFileAsync';
        const formUpload: FormData = new FormData();
        if (this.FileToUpload) {
            if (this.FileToUpload.length > 0) {
                for (var i = 0; i < this.FileToUpload.length; i++) {
                    formUpload.append('file[]', this.FileToUpload[i]);
                }
            }
        }
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    PostThanhVien001ByExcelFileAsync() {
        let url = this.APIURL + this.Controller + '/PostThanhVien001ByExcelFileAsync';
        const formUpload: FormData = new FormData();
        if (this.FileToUpload) {
            if (this.FileToUpload.length > 0) {
                for (var i = 0; i < this.FileToUpload.length; i++) {
                    formUpload.append('file[]', this.FileToUpload[i]);
                }
            }
        }
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    PostThanhVien002ByExcelFileAsync() {
        let url = this.APIURL + this.Controller + '/PostThanhVien002ByExcelFileAsync';
        const formUpload: FormData = new FormData();
        if (this.FileToUpload) {
            if (this.FileToUpload.length > 0) {
                for (var i = 0; i < this.FileToUpload.length; i++) {
                    formUpload.append('file[]', this.FileToUpload[i]);
                }
            }
        }
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    PostThanhVienDanhMucXaPhuongNameByExcelFileAsync() {
        let url = this.APIURL + this.Controller + '/PostThanhVienDanhMucXaPhuongNameByExcelFileAsync';
        const formUpload: FormData = new FormData();
        if (this.FileToUpload) {
            if (this.FileToUpload.length > 0) {
                for (var i = 0; i < this.FileToUpload.length; i++) {
                    formUpload.append('file[]', this.FileToUpload[i]);
                }
            }
        }
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
}


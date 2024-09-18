import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { BaseParameter } from './BaseParameter.model';
@Injectable({
    providedIn: 'root'
})
export class UploadService {

    File: File;
    FileToUpload: FileList;
    BaseParameter!: BaseParameter;
    IsShowLoading: boolean = false;
    APIURL: string = environment.APIUploadURL;
    Controller: string = "Upload";

    Headers: HttpHeaders = new HttpHeaders();
    constructor(private httpClient: HttpClient) {
        this.InitializationFormData();
    }
    InitializationFormData() {
        this.BaseParameter = {
        };

        let token = localStorage.getItem(environment.Token);
        this.Headers = this.Headers.append('Authorization', 'Bearer ' + token);
    }

    PostToChucTramQuanTracByExcelFileAsync() {
        let url = this.APIURL + this.Controller + '/PostToChucTramQuanTracByExcelFileAsync';
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
    PostToChucHoNuoiByExcelFile() {
        let url = this.APIURL + this.Controller + '/PostToChucHoNuoiByExcelFile';
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
    PostToChucPhuongTienKhaiThacByExcelFileAsync() {
        let url = this.APIURL + this.Controller + '/PostToChucPhuongTienKhaiThacByExcelFileAsync';
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
    PostToChucGiongByExcelFileAsync() {
        let url = this.APIURL + this.Controller + '/PostToChucGiongByExcelFileAsync';
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
    PostToChucVungTrongByExcelFileAsync() {
        let url = this.APIURL + this.Controller + '/PostToChucVungTrongByExcelFileAsync';
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
    PostToChucCuaHangByExcelFileAsync() {
        let url = this.APIURL + this.Controller + '/PostToChucCuaHangByExcelFileAsync';
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
    PostToChucLongBeByExcelFileAsync() {
        let url = this.APIURL + this.Controller + '/PostToChucLongBeByExcelFileAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        if (this.FileToUpload) {
            if (this.FileToUpload.length > 0) {
                for (var i = 0; i < this.FileToUpload.length; i++) {
                    formUpload.append('file[]', this.FileToUpload[i]);
                }
            }
        }
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    PostToChucNuoiNhuyenThe001ByExcelFileAsync() {
        let url = this.APIURL + this.Controller + '/PostToChucNuoiNhuyenThe001ByExcelFileAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        if (this.FileToUpload) {
            if (this.FileToUpload.length > 0) {
                for (var i = 0; i < this.FileToUpload.length; i++) {
                    formUpload.append('file[]', this.FileToUpload[i]);
                }
            }
        }
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    PostToChucNuoiNhuyenThe002ByExcelFileAsync() {
        let url = this.APIURL + this.Controller + '/PostToChucNuoiNhuyenThe002ByExcelFileAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
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


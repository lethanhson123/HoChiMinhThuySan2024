import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { BaseParameter } from './BaseParameter.model';
import { NamThang } from './NamThang.model';

@Injectable({
    providedIn: 'root'
})
export class DownloadService {

    ListNam001: NamThang[] | undefined;
    ListThang001: NamThang[] | undefined;

    BaseParameter!: BaseParameter;
    APIURL: string = environment.APIUploadURL;
    Controller: string = "Download";
    Headers: HttpHeaders = new HttpHeaders();


    IPAddress: string = environment.InitializationString;


    constructor(private httpClient: HttpClient) {
        this.InitializationFormData();
        this.GetIPAddress();
    }
    InitializationFormData() {
        this.BaseParameter = {
        };

        let token = localStorage.getItem(environment.Token);
        this.Headers = this.Headers.append('Authorization', 'Bearer ' + token);
    }
    GetRandomColor(count) {
        var arr = [];
        for (var i = 0; i < count; i++) {
            var letters = '0123456789ABCDEF'.split('');
            var color = '#';
            for (var x = 0; x < 6; x++) {
                color += letters[Math.floor(Math.random() * 16)];
            }
        }
        return color;
    }
    GetIPAddress() {
        // if (this.IPAddress.length == 0) {
        //     this.httpClient.get(environment.IPRegistry).toPromise().then(res => {
        //         this.IPAddress = res["ip"];
        //     });
        // }      

        return this.httpClient.get(environment.IPRegistry).toPromise();
    }
    GetIPData() {
        return this.httpClient.get(environment.IPRegistryURL).toPromise();
    }
    GetKinhDo(KinhDo: number) {
        if (KinhDo > 180) {
            KinhDo = 180;
        }
        if (KinhDo < -180) {
            KinhDo = -180;
        }      
        return KinhDo;
    }
    GetViDo(ViDo: number) {
        if (ViDo > 180) {
            ViDo = 180;
        }
        if (ViDo < -180) {
            ViDo = -180;
        }
        if (ViDo > 90) {
            ViDo = 90;
        }
        if (ViDo < -90) {
            ViDo = -90;
        }
        return ViDo;
    }
    OpenWindow(URL: string) {
        let width = screen.width;
        let height = screen.height;
        let width01 = width - 100;
        let height01 = height - 200;
        let left = (width - width01) / 2;
        let top = (height - height01) / 3;
        window.open(URL, '_blank', 'location=yes, height=' + height01 + ',width=' + width01 + ', scrollbars=yes, status=yes, toolbar=yes, top=' + top + ', left=' + left + '');
    }
    ComponentGetListNam() {
        this.ListNam().subscribe(
            res => {
                this.ListNam001 = (res as NamThang[]).sort((a, b) => (a.ID > b.ID ? 1 : -1));
            },
            err => {
            }
        );
    }
    ComponentGetListThang() {
        this.ListThang().subscribe(
            res => {
                this.ListThang001 = (res as NamThang[]).sort((a, b) => (a.ID > b.ID ? 1 : -1));
            },
            err => {
            }
        );
    }
    NamBatDau() {
        let url = this.APIURL + this.Controller + '/NamBatDau';
        const formUpload: FormData = new FormData();
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }

    NamKeThuc() {
        let url = this.APIURL + this.Controller + '/NamKeThuc';
        const formUpload: FormData = new FormData();
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    ListNam() {
        let url = this.APIURL + this.Controller + '/ListNam';
        const formUpload: FormData = new FormData();
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    ListThang() {
        let url = this.APIURL + this.Controller + '/ListThang';
        const formUpload: FormData = new FormData();
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    ExportToChucHoNuoiToExcelAsync() {
        let url = this.APIURL + this.Controller + '/ExportToChucHoNuoiToExcelAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    ExportToChucCuaHangToExcelAsync() {
        let url = this.APIURL + this.Controller + '/ExportToChucCuaHangToExcelAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    ExportToChucTramQuanTracToExcelAsync() {
        let url = this.APIURL + this.Controller + '/ExportToChucTramQuanTracToExcelAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    ExportToChucPhuongTienKhaiThacToExcelAsync() {
        let url = this.APIURL + this.Controller + '/ExportToChucPhuongTienKhaiThacToExcelAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    ExportToChucGiongToExcelAsync() {
        let url = this.APIURL + this.Controller + '/ExportToChucGiongToExcelAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    ExportToChucDanhMucGiongToExcelAsync() {
        let url = this.APIURL + this.Controller + '/ExportToChucDanhMucGiongToExcelAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
}


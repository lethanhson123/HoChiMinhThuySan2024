import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { ThanhVienToken } from 'src/app/shared/ThanhVienToken.model';
import { BaseService } from './Base.service';
@Injectable({
    providedIn: 'root'
})
export class ThanhVienTokenService extends BaseService{

    DisplayColumns001: string[] = ['STT', 'ID', 'Code', 'Name', 'Note', 'ParentID', 'SortOrder', 'Active', 'Save'];
        
    List: ThanhVienToken[] | undefined;
    ListFilter: ThanhVienToken[] | undefined;
    FormData!: ThanhVienToken;

    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.Controller = "ThanhVienToken";
    }

    AuthenticationByTokenAsync() {
        let url = this.APIURL + this.Controller + '/AuthenticationByTokenAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
}


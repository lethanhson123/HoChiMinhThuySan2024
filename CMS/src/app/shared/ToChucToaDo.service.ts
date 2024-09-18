import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { ToChucToaDo } from 'src/app/shared/ToChucToaDo.model';
import { BaseService } from './Base.service';
@Injectable({
    providedIn: 'root'
})
export class ToChucToaDoService extends BaseService{

    DisplayColumns001: string[] = ['STT', 'ID', 'KinhDo', 'ViDo', 'SortOrder', 'Active', 'Save'];

    DisplayColumns002: string[] = ['STT', 'ID', 'ToChucVungNuoiID', 'Name', 'KinhDo', 'ViDo', 'SortOrder', 'Active', 'Save'];
        
    APIURL: string = environment.APIMapURL;
    List: ToChucToaDo[] | undefined;
    ListFilter: ToChucToaDo[] | undefined;
    FormData!: ToChucToaDo;    
    

    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.Controller = "ToChucToaDo";
    }
    GetByToChucVungNuoiIDToListAsync() {
        let url = this.APIURL + this.Controller + '/GetByToChucVungNuoiIDToListAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    GetByToChucVungNuoiIDAndEmptyToListAsync() {
        let url = this.APIURL + this.Controller + '/GetByToChucVungNuoiIDAndEmptyToListAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
}


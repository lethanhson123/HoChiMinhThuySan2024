import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { DanhMucTinhThanhToaDo } from 'src/app/shared/DanhMucTinhThanhToaDo.model';
import { BaseService } from './Base.service';
@Injectable({
    providedIn: 'root'
})
export class DanhMucTinhThanhToaDoService extends BaseService{

    DisplayColumns001: string[] = ['STT', 'ID', 'KinhDo', 'ViDo', 'Note', 'SortOrder', 'Save'];
        
    List: DanhMucTinhThanhToaDo[] | undefined;
    ListFilter: DanhMucTinhThanhToaDo[] | undefined;
    FormData!: DanhMucTinhThanhToaDo;
    
    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.Controller = "DanhMucTinhThanhToaDo";
    }
}


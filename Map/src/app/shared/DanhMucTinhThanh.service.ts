import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { DanhMucTinhThanh } from 'src/app/shared/DanhMucTinhThanh.model';
import { BaseService } from './Base.service';
@Injectable({
    providedIn: 'root'
})
export class DanhMucTinhThanhService extends BaseService{

    DisplayColumns001: string[] = ['STT', 'ID', 'Name', 'Note', 'ParentID', 'KinhDo', 'ViDo', 'SortOrder', 'Active', 'Save'];
    DisplayColumns002: string[] = ['STT', 'ID', 'Name', 'Display', 'Note', 'ParentID', 'KinhDo', 'ViDo', 'SortOrder', 'Active', 'Save'];
    
    List: DanhMucTinhThanh[] | undefined;
    ListFilter: DanhMucTinhThanh[] | undefined;
    FormData!: DanhMucTinhThanh;

    
    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.Controller = "DanhMucTinhThanh";
    }
}


import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { DanhMucQuanHuyen } from 'src/app/shared/DanhMucQuanHuyen.model';
import { BaseService } from './Base.service';
@Injectable({
    providedIn: 'root'
})
export class DanhMucQuanHuyenService extends BaseService{

    DisplayColumns001: string[] = ['STT', 'ID', 'Name', 'Note', 'ParentID', 'KinhDo', 'ViDo', 'SortOrder', 'Active', 'Save'];
    DisplayColumns002: string[] = ['STT', 'ID', 'Name', 'Display', 'Note', 'ParentID', 'KinhDo', 'ViDo', 'SortOrder', 'Active', 'Save'];

    List: DanhMucQuanHuyen[] | undefined;
    ListFilter: DanhMucQuanHuyen[] | undefined;
    FormData!: DanhMucQuanHuyen;
    
    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.Controller = "DanhMucQuanHuyen";
    }
}


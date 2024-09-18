import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { DanhMucXaPhuong } from 'src/app/shared/DanhMucXaPhuong.model';
import { BaseService } from './Base.service';
@Injectable({
    providedIn: 'root'
})
export class DanhMucXaPhuongService extends BaseService{

    DisplayColumns001: string[] = ['STT', 'ID', 'Name', 'Note', 'ParentID', 'KinhDo', 'ViDo', 'SortOrder', 'Active', 'Save'];
    DisplayColumns002: string[] = ['STT', 'ID', 'Name', 'Display', 'Note', 'ParentID', 'KinhDo', 'ViDo', 'SortOrder', 'Active', 'Save'];
    
    List: DanhMucXaPhuong[] | undefined;
    ListFilter: DanhMucXaPhuong[] | undefined;
    FormData!: DanhMucXaPhuong;
    
    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.Controller = "DanhMucXaPhuong";
    }
}


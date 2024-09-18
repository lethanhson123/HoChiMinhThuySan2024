import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { ToChucTapTinDinhKem } from 'src/app/shared/ToChucTapTinDinhKem.model';
import { BaseService } from './Base.service';
@Injectable({
    providedIn: 'root'
})
export class ToChucTapTinDinhKemService extends BaseService{

    DisplayColumns001: string[] = ['STT', 'ID', 'LastUpdatedDate', 'Name', 'FileName', 'Save'];

    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.Controller = "ToChucTapTinDinhKem";
    }
}


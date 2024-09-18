import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { ToChucNguyenVatLieu } from 'src/app/shared/ToChucNguyenVatLieu.model';
import { BaseService } from './Base.service';
@Injectable({
    providedIn: 'root'
})
export class ToChucNguyenVatLieuService extends BaseService{

    DisplayColumns001: string[] = ['STT', 'ID', 'DanhMucNguyenVatLieuName', 'Save'];
        
    List: ToChucNguyenVatLieu[] | undefined;
    ListFilter: ToChucNguyenVatLieu[] | undefined;
    FormData!: ToChucNguyenVatLieu;    


    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.Controller = "ToChucNguyenVatLieu";
    }
}


import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { ToChucGiong } from 'src/app/shared/ToChucGiong.model';
import { BaseService } from './Base.service';
@Injectable({
    providedIn: 'root'
})
export class ToChucGiongService extends BaseService{

    DisplayColumns001: string[] = ['STT', 'ID', 'DanhMucLoaiGiongID', 'DanhMucGiongID', 'Save'];

    DisplayColumns002: string[] = ['STT', 'ID', 'DanhMucLoaiGiongID', 'DanhMucLoaiGiongName', 'DanhMucGiongID', 'DanhMucGiongName', 'Save'];

    DisplayColumns003: string[] = ['STT', 'ID', 'DanhMucLoaiGiongID', 'DanhMucLoaiGiongName', 'DanhMucGiongID', 'DanhMucGiongName', 'MatDoNuoi', 'TyLeSong', 'ThoiGianNuoi', 'SanLuong', 'PH', 'S', 'DoKiem', 'Save'];

    DisplayColumns004: string[] = ['STT', 'ID', 'DanhMucLoaiGiongID', 'DanhMucLoaiGiongName', 'DanhMucGiongID', 'DanhMucGiongName', 'MatDoNuoi', 'TyLeSong', 'ThoiGianNuoi', 'SanLuong', 'Save'];
        
    List: ToChucGiong[] | undefined;
    ListFilter: ToChucGiong[] | undefined;
    FormData!: ToChucGiong;    

    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.Controller = "ToChucGiong";
    }
}


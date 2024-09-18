import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { ToChucPhuongTienKhaiThac } from 'src/app/shared/ToChucPhuongTienKhaiThac.model';
import { BaseService } from './Base.service';
@Injectable({
    providedIn: 'root'
})
export class ToChucPhuongTienKhaiThacService extends BaseService {

    DisplayColumns001: string[] = ['STT', 'ID', 'DanhMucHieuMayID', 'DanhMucNganhNgheID', 'Code', 'NgayDangKy', 'HanDangKiem', 'ChieuCao', 'ChieuRong', 'ChieuDai', 'DungTich', 'CongSuat', 'ThuyenVien', 'Save'];

    List: ToChucPhuongTienKhaiThac[] | undefined;
    ListFilter: ToChucPhuongTienKhaiThac[] | undefined;
    FormData!: ToChucPhuongTienKhaiThac;

    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.Controller = "ToChucPhuongTienKhaiThac";
    }
}


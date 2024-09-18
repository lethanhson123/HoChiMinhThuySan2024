import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { ThongBaoThanhVien } from 'src/app/shared/ThongBaoThanhVien.model';
import { BaseService } from './Base.service';
@Injectable({
    providedIn: 'root'
})
export class ThongBaoThanhVienService extends BaseService{
    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.Controller = "ThongBaoThanhVien";
    }
}


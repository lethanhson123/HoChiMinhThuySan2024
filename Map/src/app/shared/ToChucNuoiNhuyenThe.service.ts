import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { ToChucNuoiNhuyenThe } from 'src/app/shared/ToChucNuoiNhuyenThe.model';
import { BaseService } from './Base.service';
@Injectable({
    providedIn: 'root'
})
export class ToChucNuoiNhuyenTheService extends BaseService{
    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.Controller = "ToChucNuoiNhuyenThe";
    }
}


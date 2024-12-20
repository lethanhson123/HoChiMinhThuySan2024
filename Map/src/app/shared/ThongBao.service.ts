﻿import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { ThongBao } from 'src/app/shared/ThongBao.model';
import { BaseService } from './Base.service';
@Injectable({
    providedIn: 'root'
})
export class ThongBaoService extends BaseService{
    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.Controller = "ThongBao";
    }
}


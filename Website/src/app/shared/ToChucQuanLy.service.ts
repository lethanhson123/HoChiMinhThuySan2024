import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { ToChucQuanLy } from 'src/app/shared/ToChucQuanLy.model';
import { BaseService } from './Base.service';
@Injectable({
    providedIn: 'root'
})
export class ToChucQuanLyService extends BaseService{

    DisplayColumns001: string[] = ['STT', 'ID', 'ToChucID', 'ToChucName', 'Save'];
        
    List: ToChucQuanLy[] | undefined;
    ListFilter: ToChucQuanLy[] | undefined;
    FormData!: ToChucQuanLy;    

    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.Controller = "ToChucQuanLy";
    }
}


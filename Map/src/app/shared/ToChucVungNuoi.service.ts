import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { ToChucVungNuoi } from 'src/app/shared/ToChucVungNuoi.model';
import { BaseService } from './Base.service';
@Injectable({
    providedIn: 'root'
})
export class ToChucVungNuoiService extends BaseService{
    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.Controller = "ToChucVungNuoi";
    }
}


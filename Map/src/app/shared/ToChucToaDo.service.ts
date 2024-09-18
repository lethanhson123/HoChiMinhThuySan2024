import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { ToChucToaDo } from 'src/app/shared/ToChucToaDo.model';
import { BaseService } from './Base.service';
@Injectable({
    providedIn: 'root'
})
export class ToChucToaDoService extends BaseService {

    DisplayColumns001: string[] = ['STT', 'ID', 'Name', 'KinhDo', 'ViDo', 'Active', 'Save'];

    List: ToChucToaDo[] | undefined;
    ListFilter: ToChucToaDo[] | undefined;
    FormData!: ToChucToaDo;   
    APIURL: string = environment.APIMapURL;

    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.Controller = "ToChucToaDo";
        this.List = [];
        this.ListFilter = [];       
    }
}


import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { ThanhVien } from 'src/app/shared/ThanhVien.model';
import { BaseService } from './Base.service';
@Injectable({
    providedIn: 'root'
})
export class ThanhVienService extends BaseService{
   
    List: ThanhVien[] | undefined;                  
    FormData!: ThanhVien;
    FormDataLogin!: ThanhVien;
    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.Controller = "ThanhVien";
    }
    
    AuthenticationAsync() {
        let url = this.APIURL + this.Controller + '/AuthenticationAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.FormData));        
        return this.httpClient.post(url, formUpload);
    }       
}


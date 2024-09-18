import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Report } from 'src/app/shared/Report.model';
import { BaseService } from './Base.service';

@Injectable({
  providedIn: 'root'
})

export class ReportService extends BaseService {



  List: Report[] | undefined;
  ListFilter: Report[] | undefined;
  FormData!: Report;
  List000012: Report[] | undefined = [];

  APIURL: string = environment.APIReportURL;
  constructor(public httpClient: HttpClient) {
    super(httpClient);
    this.Controller = "Report";    
  }


  Report000012ToListAsync() {
    let url = this.APIURL + this.Controller + '/Report000012ToListAsync';
    const formUpload: FormData = new FormData();
    formUpload.append('data', JSON.stringify(this.BaseParameter));
    return this.httpClient.post(url, formUpload, { headers: this.Headers });
  }
  Report00003ToListAsync() {
    let url = this.APIURL + this.Controller + '/Report00003ToListAsync';
    const formUpload: FormData = new FormData();
    formUpload.append('data', JSON.stringify(this.BaseParameter));
    return this.httpClient.post(url, formUpload, { headers: this.Headers });
  }
}


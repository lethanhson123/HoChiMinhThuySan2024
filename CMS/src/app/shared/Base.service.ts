import { Injectable, ViewChild } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { environment } from 'src/environments/environment';
import { NotificationService } from 'src/app/shared/Notification.service';
import { Base } from 'src/app/shared/Base.model';
import { BaseParameter } from './BaseParameter.model';
@Injectable({
    providedIn: 'root'
})
export class BaseService {

    DataSource: MatTableDataSource<any>;
    DataSourceFilter: MatTableDataSource<any>;
    DisplayColumns: string[] = ['STT', 'ID', 'Code', 'Name', 'Note', 'ParentID', 'SortOrder', 'Active', 'Save'];
    DisplayColumnsMobile: string[] = ['STT'];
    List: Base[] | undefined;
    ListFilter: Base[] | undefined;
    FormData!: Base;
    File: File;
    FileToUpload: FileList
    BaseParameter!: BaseParameter;
    IsShowLoading: boolean = false;
    APIURL: string = environment.APIURL;
    Controller: string = "Base";
    Headers: HttpHeaders = new HttpHeaders();


    constructor(
        public httpClient: HttpClient
    ) {
        this.FormData = {
        };
        this.BaseParameter = {
            SearchString: environment.InitializationString,
            BatDau: new Date(new Date().getFullYear(), new Date().getMonth(), 1),
            KetThuc: new Date(),
            Nam: new Date().getFullYear(),
            Thang: new Date().getMonth() + 1,
        };
        this.List = [];
        this.ListFilter = [];

        let token = localStorage.getItem(environment.Token);
        this.Headers = this.Headers.append('Authorization', 'Bearer ' + token);
    }
    InitializationHeaders() {
        if (this.Headers) {
            let Bearer = this.Headers.getAll("Authorization")[0];
            if (Bearer == environment.Bearer) {
                this.Headers = new HttpHeaders();
                this.Headers = this.Headers.append('Authorization', 'Bearer ' + this.FormData.Description);
            }
        }
    }
    Initialization() {
        var lastUpdatedMembershipID = localStorage.getItem(environment.ThanhVienID);
        if (lastUpdatedMembershipID) {
            this.FormData.LastUpdatedMembershipID = Number(lastUpdatedMembershipID);
        }
    }

    Filter(searchString: string) {
        if (searchString.length > 0) {
            searchString = searchString.trim();
            searchString = searchString.toLocaleLowerCase();
            this.ListFilter = this.List.filter((item: any) =>
                item.Name.toLocaleLowerCase().indexOf(searchString) !== -1 || item.Code.toLocaleLowerCase().indexOf(searchString) !== -1);
        }
        else {
            this.ListFilter = this.List;
        }
    }
    FilterActive(searchString: string, Service: BaseService) {
        if (searchString.length > 0) {
            Service.IsShowLoading = true;
            searchString = searchString.trim();
            searchString = searchString.toLocaleLowerCase();
            this.BaseParameter.SearchString = searchString;
            if (this.BaseParameter.Active == null) {
                this.BaseParameter.Active = true;
            }
            this.GetByActiveAndSearchStringToListAsync().subscribe(
                res => {
                    this.List = (res as any[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
                    this.ListFilter = this.List;
                },
                err => {
                },
                () => {
                    Service.IsShowLoading = false;
                }
            );
        }
        else {
            this.ListFilter = this.List;
        }
    }
    FilterDanhMucUngDungIDAndActive(searchString: string, Service: BaseService) {
        if (searchString.length > 0) {
            Service.IsShowLoading = true;
            searchString = searchString.trim();
            searchString = searchString.toLocaleLowerCase();
            this.BaseParameter.SearchString = searchString;
            if (this.BaseParameter.DanhMucUngDungID == null) {
                this.BaseParameter.DanhMucUngDungID = environment.DanhMucUngDungID;
            }
            if (this.BaseParameter.Active == null) {
                this.BaseParameter.Active = true;
            }
            this.GetByDanhMucUngDungIDAndActiveAndSearchStringToListAsync().subscribe(
                res => {
                    this.List = (res as any[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
                    this.ListFilter = this.List;
                },
                err => {
                },
                () => {
                    Service.IsShowLoading = false;
                }
            );
        }
        else {
            this.ListFilter = this.List;
        }
    }
    ComponentGetByActiveAndPageAndPageSizeAndIDToListAsync(Service: BaseService) {
        Service.IsShowLoading = true;
        this.BaseParameter.Page = environment.InitializationNumber;
        this.BaseParameter.PageSize = environment.PageSize;
        if (this.BaseParameter.ID == null) {
            this.BaseParameter.ID = environment.InitializationNumber;
        }
        if (this.BaseParameter.Active == null) {
            this.BaseParameter.Active = true;
        }
        this.GetByActiveAndPageAndPageSizeAndIDToListAsync().subscribe(
            res => {
                this.List = (res as any[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
                this.ListFilter = this.List;
            },
            err => {
            },
            () => {
                Service.IsShowLoading = false;
            }
        );
    }
    ComponentGetByDanhMucUngDungIDAndActiveAndPageAndPageSizeToListAsync(Service: BaseService) {
        Service.IsShowLoading = true;
        this.BaseParameter.Page = environment.InitializationNumber;
        this.BaseParameter.PageSize = environment.PageSize;
        if (this.BaseParameter.DanhMucUngDungID == null) {
            this.BaseParameter.DanhMucUngDungID = environment.DanhMucUngDungID;
        }
        if (this.BaseParameter.Active == null) {
            this.BaseParameter.Active = true;
        }
        this.GetByDanhMucUngDungIDAndActiveAndPageAndPageSizeToListAsync().subscribe(
            res => {
                this.List = (res as any[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
                this.ListFilter = this.List;

            },
            err => {
            },
            () => {
                Service.IsShowLoading = false;
            }
        );
    }
    SearchAllNotEmpty(sort: MatSort, paginator: MatPaginator) {
        if (this.BaseParameter.SearchString.length > 0) {
            this.BaseParameter.SearchString = this.BaseParameter.SearchString.trim();
            if (this.DataSource) {
                this.DataSource.filter = this.BaseParameter.SearchString.toLowerCase();
            }
        }
        else {
            this.ComponentGetAllNotEmptyToListAsync(sort, paginator);
        }
    }
    SearchAll(sort: MatSort, paginator: MatPaginator) {
        if (this.BaseParameter.SearchString.length > 0) {
            this.BaseParameter.SearchString = this.BaseParameter.SearchString.trim();
            if (this.DataSource) {
                this.DataSource.filter = this.BaseParameter.SearchString.toLowerCase();
            }
        }
        else {
            this.ComponentGetAllAndEmptyToListAsync(sort, paginator);
        }
    }
    SearchBySearchString(sort: MatSort, paginator: MatPaginator) {
        this.ComponentGetBySearchStringAndEmptyToListAsync(sort, paginator);
    }
    SearchByParentIDNotEmpty(sort: MatSort, paginator: MatPaginator) {
        if (this.BaseParameter.SearchString.length > 0) {
            this.BaseParameter.SearchString = this.BaseParameter.SearchString.trim();
            if (this.DataSource) {
                this.DataSource.filter = this.BaseParameter.SearchString.toLowerCase();
            }
        }
        else {
            this.ComponentGetByParentIDNotEmptyToListAsync(sort, paginator);
        }
    }
    SearchByDanhMucUngDungID(sort: MatSort, paginator: MatPaginator) {
        if (this.BaseParameter.SearchString.length > 0) {
            this.BaseParameter.SearchString = this.BaseParameter.SearchString.trim();
            if (this.DataSource) {
                this.DataSource.filter = this.BaseParameter.SearchString.toLowerCase();
            }
        }
        else {
            this.ComponentGetByDanhMucUngDungIDAndEmptyToListAsync(sort, paginator);
        }
    }
    SearchByDanhMucUngDungIDNotEmpty(sort: MatSort, paginator: MatPaginator) {
        if (this.BaseParameter.SearchString.length > 0) {
            this.BaseParameter.SearchString = this.BaseParameter.SearchString.trim();
            if (this.DataSource) {
                this.DataSource.filter = this.BaseParameter.SearchString.toLowerCase();
            }
        }
        else {
            this.ComponentGetByDanhMucUngDungIDNotEmptyToListAsync(sort, paginator);
        }
    }
    SearchByParentID(sort: MatSort, paginator: MatPaginator, Service: BaseService) {
        if (this.BaseParameter.SearchString.length > 0) {
            this.BaseParameter.SearchString = this.BaseParameter.SearchString.trim();
            if (this.DataSource) {
                this.DataSource.filter = this.BaseParameter.SearchString.toLowerCase();
            }
        }
        else {
            this.ComponentGetByParentIDAndEmptyToListAsync(sort, paginator, Service);
        }
    }
    SearchByCode(sort: MatSort, paginator: MatPaginator) {
        if (this.BaseParameter.SearchString.length > 0) {
            this.BaseParameter.SearchString = this.BaseParameter.SearchString.trim();
            if (this.DataSource) {
                this.DataSource.filter = this.BaseParameter.SearchString.toLowerCase();
            }
        }
        else {
            this.ComponentGetByCodeAndEmptyToListAsync(sort, paginator);
        }
    }
    SearchByCodeNotEmpty(sort: MatSort, paginator: MatPaginator) {
        if (this.BaseParameter.SearchString.length > 0) {
            this.BaseParameter.SearchString = this.BaseParameter.SearchString.trim();
            if (this.DataSource) {
                this.DataSource.filter = this.BaseParameter.SearchString.toLowerCase();
            }
        }
        else {
            this.ComponentGetByCodeToListAsync(sort, paginator);
        }
    }
    SearchByParentIDAndActive(sort: MatSort, paginator: MatPaginator) {
        if (this.BaseParameter.SearchString.length > 0) {
            this.BaseParameter.SearchString = this.BaseParameter.SearchString.trim();
            if (this.DataSource) {
                this.DataSource.filter = this.BaseParameter.SearchString.toLowerCase();
            }
        }
        else {
            this.ComponentGetByParentIDAndActiveAndEmptyToListAsync(sort, paginator);
        }
    }
    ComponentGetAllNotEmptyToListAsync(sort: MatSort, paginator: MatPaginator) {
        this.IsShowLoading = true;
        this.GetAllToListAsync().subscribe(
            res => {
                this.List = (res as any[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
                this.ListFilter = this.List;
                this.DataSource = new MatTableDataSource(this.List);
                this.DataSource.sort = sort;
                this.DataSource.paginator = paginator;
            },
            err => {
            },
            () => {
                this.IsShowLoading = false;
            }
        );
    }
    ComponentGetAllAndEmptyToListAsync(sort: MatSort, paginator: MatPaginator) {
        this.IsShowLoading = true;
        this.GetAllAndEmptyToListAsync().subscribe(
            res => {
                this.List = (res as any[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
                this.ListFilter = this.List.filter(item => item.ID > 0);
                this.DataSource = new MatTableDataSource(this.List);
                this.DataSource.sort = sort;
                this.DataSource.paginator = paginator;
            },
            err => {
            },
            () => {
                this.IsShowLoading = false;
            }
        );
    }
    ComponentGetBySearchStringAndEmptyToListAsync(sort: MatSort, paginator: MatPaginator) {
        this.IsShowLoading = true;
        this.GetBySearchStringAndEmptyToListAsync().subscribe(
            res => {
                this.List = (res as any[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
                this.ListFilter = this.List.filter(item => item.ID > 0);
                this.DataSource = new MatTableDataSource(this.List);
                this.DataSource.sort = sort;
                this.DataSource.paginator = paginator;
            },
            err => {
            },
            () => {
                this.IsShowLoading = false;
            }
        );
    }
    ComponentGetByParentIDNotEmptyToListAsync(sort: MatSort, paginator: MatPaginator) {
        this.IsShowLoading = true;
        this.GetByParentIDToListAsync().subscribe(
            res => {
                this.List = (res as any[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
                this.ListFilter = this.List;
                this.DataSource = new MatTableDataSource(this.List);
                this.DataSource.sort = sort;
                this.DataSource.paginator = paginator;
            },
            err => {
            },
            () => {
                this.IsShowLoading = false;
            }
        );
    }
    ComponentGetByParentIDAndEmptyToListAsync(sort: MatSort, paginator: MatPaginator, Service: BaseService) {
        Service.IsShowLoading = true;
        this.GetByParentIDAndEmptyToListAsync().subscribe(
            res => {
                this.List = (res as any[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
                this.ListFilter = this.List.filter(item => item.ID > 0);
                this.DataSource = new MatTableDataSource(this.List);
                this.DataSource.sort = sort;
                this.DataSource.paginator = paginator;
            },
            err => {
            },
            () => {
                Service.IsShowLoading = false;
            }
        );
    }
    ComponentGetByCodeAndEmptyToListAsync(sort: MatSort, paginator: MatPaginator) {
        this.IsShowLoading = true;
        this.GetByCodeAndEmptyToListAsync().subscribe(
            res => {
                this.List = (res as any[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
                this.ListFilter = this.List.filter(item => item.ID > 0);
                this.DataSource = new MatTableDataSource(this.List);
                this.DataSource.sort = sort;
                this.DataSource.paginator = paginator;
            },
            err => {
            },
            () => {
                this.IsShowLoading = false;
            }
        );
    }
    ComponentGetByCodeToListAsync(sort: MatSort, paginator: MatPaginator) {
        this.IsShowLoading = true;
        this.GetByCodeToListAsync().subscribe(
            res => {
                this.List = (res as any[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
                this.ListFilter = this.List.filter(item => item.ID > 0);
                this.DataSource = new MatTableDataSource(this.List);
                this.DataSource.sort = sort;
                this.DataSource.paginator = paginator;
            },
            err => {
            },
            () => {
                this.IsShowLoading = false;
            }
        );
    }
    ComponentGetByParentID_SearchString_EmptyToListAsync(sort: MatSort, paginator: MatPaginator) {
        this.IsShowLoading = true;
        this.GetByParentID_SearchString_EmptyToListAsync().subscribe(
            res => {
                this.List = (res as any[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
                this.ListFilter = this.List.filter(item => item.ID > 0);
                this.DataSource = new MatTableDataSource(this.List);
                this.DataSource.sort = sort;
                this.DataSource.paginator = paginator;
            },
            err => {
            },
            () => {
                this.IsShowLoading = false;
            }
        );
    }
    ComponentGetByDanhMucUngDungIDNotEmptyToListAsync(sort: MatSort, paginator: MatPaginator) {
        this.IsShowLoading = true;
        this.GetByDanhMucUngDungIDToListAsync().subscribe(
            res => {
                this.List = (res as any[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
                this.ListFilter = this.List;
                this.DataSource = new MatTableDataSource(this.List);
                this.DataSource.sort = sort;
                this.DataSource.paginator = paginator;
            },
            err => {
            },
            () => {
                this.IsShowLoading = false;
            }
        );
    }
    ComponentGetByDanhMucUngDungIDAndEmptyToListAsync(sort: MatSort, paginator: MatPaginator) {
        this.IsShowLoading = true;
        this.GetByDanhMucUngDungIDAndEmptyToListAsync().subscribe(
            res => {
                this.List = (res as any[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
                this.ListFilter = this.List.filter(item => item.ID > 0);
                this.DataSource = new MatTableDataSource(this.List);
                this.DataSource.sort = sort;
                this.DataSource.paginator = paginator;
            },
            err => {
            },
            () => {
                this.IsShowLoading = false;
            }
        );
    }
    ComponentGetByDanhMucUngDungID_SearchString_EmptyToListAsync(sort: MatSort, paginator: MatPaginator) {
        this.IsShowLoading = true;
        this.GetByDanhMucUngDungID_SearchString_EmptyToListAsync().subscribe(
            res => {
                this.List = (res as any[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
                this.ListFilter = this.List.filter(item => item.ID > 0);
                this.DataSource = new MatTableDataSource(this.List);
                this.DataSource.sort = sort;
                this.DataSource.paginator = paginator;
            },
            err => {
            },
            () => {
                this.IsShowLoading = false;
            }
        );
    }
    ComponentGetByParentIDAndActiveAndEmptyToListAsync(sort: MatSort, paginator: MatPaginator) {
        this.IsShowLoading = true;
        this.GetByParentIDAndActiveAndEmptyToListAsync().subscribe(
            res => {
                this.List = (res as any[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
                this.ListFilter = this.List.filter(item => item.ID > 0);
                this.DataSource = new MatTableDataSource(this.List);
                this.DataSource.sort = sort;
                this.DataSource.paginator = paginator;
            },
            err => {
            },
            () => {
                this.IsShowLoading = false;
            }
        );
    }
    ComponentGetAllToListAsync(Service: BaseService) {       
        if (this.List) {
            if (this.List.length == 0) {
                this.GetAllToListAsync().subscribe(
                    res => {
                        this.List = (res as any[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
                        this.ListFilter = this.List;
                    },
                    err => {
                    },
                    () => {                        
                    }
                );
            }
            else{            
            }
        }
        else{           
        }
    }
    ComponentGetByIDToListAsync(Service: BaseService) {
        Service.IsShowLoading = true;
        this.BaseParameter.ID = environment.DanhMucUngDungID;
        this.GetByIDToListAsync().subscribe(
            res => {
                this.List = (res as any[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
                this.ListFilter = this.List;
            },
            err => {
            },
            () => {
                Service.IsShowLoading = false;
            }
        );
    }
    ComponentGetAllToListSortByNameAsync(Service: BaseService) {
        Service.IsShowLoading = true;
        this.GetAllToListAsync().subscribe(
            res => {
                this.List = (res as any[]).sort((a, b) => (a.Name > b.Name ? 1 : -1));
                this.ListFilter = this.List;
                if (this.List.length > 0) {
                    Service.BaseParameter.ParentID = this.List[0].ID;
                }
            },
            err => {
            },
            () => {
                Service.IsShowLoading = false;
            }
        );
    }
    ComponentGetAllToListRefreshAsync(Service: BaseService) {
        Service.IsShowLoading = true;
        this.GetAllToListAsync().subscribe(
            res => {
                this.List = (res as any[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
                this.ListFilter = this.List;
            },
            err => {
            },
            () => {
                Service.IsShowLoading = false;
            }
        );
    }
    ComponentGetByActiveToListAsync() {
        this.IsShowLoading = true;
        this.GetByActiveToListAsync().subscribe(
            res => {
                this.List = (res as any[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
                this.ListFilter = this.List;
            },
            err => {
            },
            () => {
                this.IsShowLoading = false;
            }
        );
    }
    ComponentGetByParentIDToListAsync(Service: BaseService) {
        Service.IsShowLoading = true;
        this.GetByParentIDToListAsync().subscribe(
            res => {
                this.List = (res as any[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
                this.ListFilter = this.List;
            },
            err => {
            },
            () => {
                Service.IsShowLoading = false;
            }
        );
    }
    ComponentGetByParentIDToListSortByNameAsync(Service: BaseService) {
        Service.IsShowLoading = true;
        this.GetByParentIDToListAsync().subscribe(
            res => {
                this.List = (res as any[]).sort((a, b) => (a.Name > b.Name ? 1 : -1));
                this.ListFilter = this.List;
            },
            err => {
            },
            () => {
                Service.IsShowLoading = false;
            }
        );
    }
    ComponentSaveForm() {
        this.IsShowLoading = true;
        this.SaveAsync().subscribe(
            res => {
                this.FormData = res as any;
                return environment.SaveSuccess;
            },
            err => {
                return environment.SaveNotSuccess;
            },
            () => {
                this.IsShowLoading = false;
            }
        );
        return environment.SaveSuccess;
    }
    ComponentSaveAndUploadFileAsync() {
        this.IsShowLoading = true;
        this.SaveAndUploadFileAsync().subscribe(
            res => {
                this.FormData = res as any;
                return environment.SaveSuccess;
            },
            err => {
                return environment.SaveNotSuccess;
            },
            () => {
                this.IsShowLoading = false;
            }
        );
        return environment.SaveSuccess;
    }
    ComponentSaveAndUploadFilesAsync() {
        this.IsShowLoading = true;
        this.SaveAndUploadFilesAsync().subscribe(
            res => {
                this.FormData = res as any;
                return environment.SaveSuccess;
            },
            err => {
                return environment.SaveNotSuccess;
            },
            () => {
                this.IsShowLoading = false;
            }
        );
        return environment.SaveSuccess;
    }
    ComponentSaveAll(sort: MatSort, paginator: MatPaginator) {
        this.IsShowLoading = true;
        this.SaveAsync().subscribe(
            res => {
                this.SearchAll(sort, paginator);
                return environment.SaveSuccess;
            },
            err => {
                return environment.SaveNotSuccess;
            },
            () => {
                this.IsShowLoading = false;
            }
        );
        return environment.SaveSuccess;
    }
    ComponentSaveAllNotEmpty(sort: MatSort, paginator: MatPaginator) {
        this.IsShowLoading = true;
        this.SaveAsync().subscribe(
            res => {
                this.SearchAllNotEmpty(sort, paginator);
                return environment.SaveSuccess;
            },
            err => {
                return environment.SaveNotSuccess;
            },
            () => {
                this.IsShowLoading = false;
            }
        );
        return environment.SaveSuccess;
    }
    ComponentSaveByParentID(sort: MatSort, paginator: MatPaginator, Service: BaseService) {
        this.IsShowLoading = true;
        this.SaveAsync().subscribe(
            res => {
                this.SearchByParentID(sort, paginator, Service);
                return environment.SaveSuccess;
            },
            err => {
                return environment.SaveNotSuccess;
            },
            () => {
                this.IsShowLoading = false;
            }
        );
        return environment.SaveSuccess;
    }
    ComponentSaveByDanhMucUngDungID(sort: MatSort, paginator: MatPaginator) {
        this.IsShowLoading = true;
        this.SaveAsync().subscribe(
            res => {
                this.SearchByDanhMucUngDungID(sort, paginator);
                return environment.SaveSuccess;
            },
            err => {
                return environment.SaveNotSuccess;
            },
            () => {
                this.IsShowLoading = false;
            }
        );
        return environment.SaveSuccess;
    }
    ComponentSaveByCode(sort: MatSort, paginator: MatPaginator) {
        this.IsShowLoading = true;
        this.SaveAsync().subscribe(
            res => {
                this.SearchByCode(sort, paginator);
                return environment.SaveSuccess;
            },
            err => {
                return environment.SaveNotSuccess;
            },
            () => {
                this.IsShowLoading = false;
            }
        );
        return environment.SaveSuccess;
    }
    ComponentSaveByParentID_SearchString(sort: MatSort, paginator: MatPaginator) {
        this.IsShowLoading = true;
        this.SaveAsync().subscribe(
            res => {
                this.ComponentGetByParentID_SearchString_EmptyToListAsync(sort, paginator);
                return environment.SaveSuccess;
            },
            err => {
                return environment.SaveNotSuccess;
            },
            () => {
                this.IsShowLoading = false;
            }
        );
        return environment.SaveSuccess;
    }
    ComponentSaveByParentIDNotEmpty(sort: MatSort, paginator: MatPaginator) {
        this.IsShowLoading = true;
        this.SaveAsync().subscribe(
            res => {
                this.SearchByParentIDNotEmpty(sort, paginator);
                return environment.SaveSuccess;
            },
            err => {
                return environment.SaveNotSuccess;
            },
            () => {
                this.IsShowLoading = false;
            }
        );
        return environment.SaveSuccess;
    }
    ComponentSaveBySearchString(sort: MatSort, paginator: MatPaginator) {
        this.IsShowLoading = true;
        this.SaveAsync().subscribe(
            res => {
                this.SearchBySearchString(sort, paginator);
                return environment.SaveSuccess;
            },
            err => {
                return environment.SaveNotSuccess;
            },
            () => {
                this.IsShowLoading = false;
            }
        );
        return environment.SaveSuccess;
    }
    ComponentDeleteAll(sort: MatSort, paginator: MatPaginator) {
        if (confirm(environment.DeleteConfirm)) {
            this.IsShowLoading = true;
            this.RemoveAsync().subscribe(
                res => {
                    this.SearchAll(sort, paginator);
                    return environment.SaveSuccess;
                },
                err => {
                    return environment.SaveNotSuccess;
                },
                () => {
                    this.IsShowLoading = false;
                }
            );
            return environment.SaveSuccess;
        }
    }
    ComponentDeleteAllNotEmpty(sort: MatSort, paginator: MatPaginator) {
        if (confirm(environment.DeleteConfirm)) {
            this.IsShowLoading = true;
            this.RemoveAsync().subscribe(
                res => {
                    this.SearchAllNotEmpty(sort, paginator);
                    return environment.SaveSuccess;
                },
                err => {
                    return environment.SaveNotSuccess;
                },
                () => {
                    this.IsShowLoading = false;
                }
            );
            return environment.SaveSuccess;
        }
    }
    ComponentDeleteByParentID(sort: MatSort, paginator: MatPaginator, Service: BaseService) {
        if (confirm(environment.DeleteConfirm)) {
            this.IsShowLoading = true;
            this.RemoveAsync().subscribe(
                res => {
                    this.SearchByParentID(sort, paginator, Service);
                    return environment.SaveSuccess;
                },
                err => {
                    return environment.SaveNotSuccess;
                },
                () => {
                    this.IsShowLoading = false;
                }
            );
            return environment.SaveSuccess;
        }
    }
    ComponentDeleteByDanhMucUngDungID(sort: MatSort, paginator: MatPaginator) {
        if (confirm(environment.DeleteConfirm)) {
            this.IsShowLoading = true;
            this.RemoveAsync().subscribe(
                res => {
                    this.SearchByDanhMucUngDungID(sort, paginator);
                    return environment.SaveSuccess;
                },
                err => {
                    return environment.SaveNotSuccess;
                },
                () => {
                    this.IsShowLoading = false;
                }
            );
            return environment.SaveSuccess;
        }
    }
    ComponentDeleteByCode(sort: MatSort, paginator: MatPaginator) {
        if (confirm(environment.DeleteConfirm)) {
            this.IsShowLoading = true;
            this.RemoveAsync().subscribe(
                res => {
                    this.SearchByCode(sort, paginator);
                    return environment.SaveSuccess;
                },
                err => {
                    return environment.SaveNotSuccess;
                },
                () => {
                    this.IsShowLoading = false;
                }
            );
            return environment.SaveSuccess;
        }
    }
    ComponentDeleteByParentID_SearchString(sort: MatSort, paginator: MatPaginator) {
        if (confirm(environment.DeleteConfirm)) {
            this.IsShowLoading = true;
            this.RemoveAsync().subscribe(
                res => {
                    this.ComponentGetByParentID_SearchString_EmptyToListAsync(sort, paginator);
                    return environment.SaveSuccess;
                },
                err => {
                    return environment.SaveNotSuccess;
                },
                () => {
                    this.IsShowLoading = false;
                }
            );
            return environment.SaveSuccess;
        }
    }
    ComponentDeleteByParentIDNotEmpty(sort: MatSort, paginator: MatPaginator) {
        if (confirm(environment.DeleteConfirm)) {
            this.IsShowLoading = true;
            this.RemoveAsync().subscribe(
                res => {
                    this.SearchByParentIDNotEmpty(sort, paginator);
                    return environment.SaveSuccess;
                },
                err => {
                    return environment.SaveNotSuccess;
                },
                () => {
                    this.IsShowLoading = false;
                }
            );
            return environment.SaveSuccess;
        }
    }
    ComponentDeleteBySearchString(sort: MatSort, paginator: MatPaginator) {
        if (confirm(environment.DeleteConfirm)) {
            this.IsShowLoading = true;
            this.RemoveAsync().subscribe(
                res => {
                    this.SearchBySearchString(sort, paginator);
                    return environment.SaveSuccess;
                },
                err => {
                    return environment.SaveNotSuccess;
                },
                () => {
                    this.IsShowLoading = false;
                }
            );
            return environment.SaveSuccess;
        }
    }

    Save() {
        this.Initialization();
        let url = this.APIURL + this.Controller + '/Save';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.FormData));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    SaveAsync() {
        this.Initialization();
        let url = this.APIURL + this.Controller + '/SaveAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.FormData));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    Copy() {
        this.Initialization();
        let url = this.APIURL + this.Controller + '/Copy';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.FormData));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    CopyAsync() {
        this.Initialization();
        let url = this.APIURL + this.Controller + '/CopyAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.FormData));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    Remove() {
        let url = this.APIURL + this.Controller + '/Remove';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    RemoveAsync() {
        let url = this.APIURL + this.Controller + '/RemoveAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    GetByID() {
        let url = this.APIURL + this.Controller + '/GetByID';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    GetByIDAsync() {
        let url = this.APIURL + this.Controller + '/GetByIDAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    GetByName() {
        let url = this.APIURL + this.Controller + '/GetByName';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    GetByNameAsync() {
        let url = this.APIURL + this.Controller + '/GetByNameAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    GetByCode() {
        let url = this.APIURL + this.Controller + '/GetByCode';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    GetByCodeAsync() {
        let url = this.APIURL + this.Controller + '/GetByCodeAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    GetAllToList() {
        let url = this.APIURL + this.Controller + '/GetAllToList';
        const formUpload: FormData = new FormData();
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    GetAllToListAsync() {
        let url = this.APIURL + this.Controller + '/GetAllToListAsync';
        const formUpload: FormData = new FormData();
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    GetByIDToList() {
        let url = this.APIURL + this.Controller + '/GetByIDToList';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    GetByIDToListAsync() {
        let url = this.APIURL + this.Controller + '/GetByIDToListAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    GetByListIDToList() {
        let url = this.APIURL + this.Controller + '/GetByListIDToList';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    GetByListIDToListAsync() {
        let url = this.APIURL + this.Controller + '/GetByListIDToListAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    GetByCodeToList() {
        let url = this.APIURL + this.Controller + '/GetByCodeToList';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    GetByCodeToListAsync() {
        let url = this.APIURL + this.Controller + '/GetByCodeToListAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    GetByActiveToList() {
        let url = this.APIURL + this.Controller + '/GetByActiveToList';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    GetByActiveToListAsync() {
        let url = this.APIURL + this.Controller + '/GetByActiveToListAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    GetByActiveAndSearchStringToList() {
        let url = this.APIURL + this.Controller + '/GetByActiveAndSearchStringToList';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    GetByActiveAndSearchStringToListAsync() {
        let url = this.APIURL + this.Controller + '/GetByActiveAndSearchStringToListAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    GetByDanhMucUngDungIDAndActiveAndSearchStringToList() {
        let url = this.APIURL + this.Controller + '/GetByDanhMucUngDungIDAndActiveAndSearchStringToList';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    GetByDanhMucUngDungIDAndActiveAndSearchStringToListAsync() {
        let url = this.APIURL + this.Controller + '/GetByDanhMucUngDungIDAndActiveAndSearchStringToListAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    GetByParentIDAndSearchStringToList() {
        let url = this.APIURL + this.Controller + '/GetByParentIDAndSearchStringToList';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    GetByParentIDAndSearchStringToListAsync() {
        let url = this.APIURL + this.Controller + '/GetByParentIDAndSearchStringToListAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    GetByDanhMucUngDungIDAndSearchStringToList() {
        let url = this.APIURL + this.Controller + '/GetByDanhMucUngDungIDAndSearchStringToList';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    GetByDanhMucUngDungIDAndSearchStringToListAsync() {
        let url = this.APIURL + this.Controller + '/GetByDanhMucUngDungIDAndSearchStringToListAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    GetByParentID_SearchStringToList() {
        let url = this.APIURL + this.Controller + '/GetByParentID_SearchStringToList';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    GetByParentID_SearchStringToListAsync() {
        let url = this.APIURL + this.Controller + '/GetByParentID_SearchStringToListAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    GetByDanhMucUngDungID_SearchStringToList() {
        let url = this.APIURL + this.Controller + '/GetByDanhMucUngDungID_SearchStringToList';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    GetByDanhMucUngDungID_SearchStringToListAsync() {
        let url = this.APIURL + this.Controller + '/GetByDanhMucUngDungID_SearchStringToListAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    GetByParentIDToList() {
        let url = this.APIURL + this.Controller + '/GetByParentIDToList';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    GetByParentIDToListAsync() {
        let url = this.APIURL + this.Controller + '/GetByParentIDToListAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    GetByDanhMucUngDungIDToList() {
        let url = this.APIURL + this.Controller + '/GetByDanhMucUngDungIDToList';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    GetByDanhMucUngDungIDToListAsync() {
        let url = this.APIURL + this.Controller + '/GetByDanhMucUngDungIDToListAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    GetByParentIDAndActiveToList() {
        let url = this.APIURL + this.Controller + '/GetByParentIDAndActiveToList';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    GetByParentIDAndActiveToListAsync() {
        let url = this.APIURL + this.Controller + '/GetByParentIDAndActiveToListAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    GetByDanhMucUngDungIDAndActiveToList() {
        let url = this.APIURL + this.Controller + '/GetByDanhMucUngDungIDAndActiveToList';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    GetByDanhMucUngDungIDAndActiveToListAsync() {
        let url = this.APIURL + this.Controller + '/GetByDanhMucUngDungIDAndActiveToListAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    GetByParentIDAndCodeToList() {
        let url = this.APIURL + this.Controller + '/GetByParentIDAndCodeToList';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    GetByParentIDAndCodeToListAsync() {
        let url = this.APIURL + this.Controller + '/GetByParentIDAndCodeToListAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    GetByDanhMucUngDungIDAndCodeToList() {
        let url = this.APIURL + this.Controller + '/GetByDanhMucUngDungIDAndCodeToList';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    GetByDanhMucUngDungIDAndCodeToListAsync() {
        let url = this.APIURL + this.Controller + '/GetByDanhMucUngDungIDAndCodeToListAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    GetByParentIDAndCodeAndActiveToList() {
        let url = this.APIURL + this.Controller + '/GetByParentIDAndCodeAndActiveToList';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    GetByParentIDAndCodeAndActiveToListAsync() {
        let url = this.APIURL + this.Controller + '/GetByParentIDAndCodeAndActiveToListAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    GetByDanhMucUngDungIDAndCodeAndActiveToList() {
        let url = this.APIURL + this.Controller + '/GetByDanhMucUngDungIDAndCodeAndActiveToList';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    GetByDanhMucUngDungIDAndCodeAndActiveToListAsync() {
        let url = this.APIURL + this.Controller + '/GetByDanhMucUngDungIDAndCodeAndActiveToListAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    GetByLastUpdatedMembershipIDToList() {
        let url = this.APIURL + this.Controller + '/GetByLastUpdatedMembershipIDToList';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    GetByLastUpdatedMembershipIDToListAsync(parentID: number) {
        let url = this.APIURL + this.Controller + '/GetByLastUpdatedMembershipIDToListAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(parentID));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    GetByLastUpdatedMembershipIDAndActiveToList() {
        let url = this.APIURL + this.Controller + '/GetByLastUpdatedMembershipIDAndActiveToList';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    GetByLastUpdatedMembershipIDAndActiveToListAsync() {
        let url = this.APIURL + this.Controller + '/GetByLastUpdatedMembershipIDAndActiveToListAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    GetBySearchStringToList() {
        let url = this.APIURL + this.Controller + '/GetBySearchStringToList';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    GetBySearchStringToListAsync() {
        let url = this.APIURL + this.Controller + '/GetBySearchStringToListAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    GetByPageAndPageSizeToList() {
        let url = this.APIURL + this.Controller + '/GetByPageAndPageSizeToList';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    GetByPageAndPageSizeToListAsync() {
        let url = this.APIURL + this.Controller + '/GetByPageAndPageSizeToListAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    GetByPageAndPageSizeAndIDToList() {
        let url = this.APIURL + this.Controller + '/GetByPageAndPageSizeAndIDToList';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    GetByPageAndPageSizeAndIDToListAsync() {
        let url = this.APIURL + this.Controller + '/GetByPageAndPageSizeAndIDToListAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    GetByActiveAndPageAndPageSizeAndIDToList() {
        let url = this.APIURL + this.Controller + '/GetByActiveAndPageAndPageSizeAndIDToList';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    GetByActiveAndPageAndPageSizeAndIDToListAsync() {
        let url = this.APIURL + this.Controller + '/GetByActiveAndPageAndPageSizeAndIDToListAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    GetByDanhMucUngDungIDAndActiveAndPageAndPageSizeToList() {
        let url = this.APIURL + this.Controller + '/GetByDanhMucUngDungIDAndActiveAndPageAndPageSizeToList';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    GetByDanhMucUngDungIDAndActiveAndPageAndPageSizeToListAsync() {
        let url = this.APIURL + this.Controller + '/GetByDanhMucUngDungIDAndActiveAndPageAndPageSizeToListAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    GetByIDString() {
        let url = this.APIURL + this.Controller + '/GetByIDString';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    GetByIDStringAsync() {
        let url = this.APIURL + this.Controller + '/GetByIDStringAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    SaveList(list: Base[]) {
        let url = this.APIURL + this.Controller + '/SaveList';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(list));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    SaveListAsync(list: Base[]) {
        let url = this.APIURL + this.Controller + '/SaveListAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(list));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    GetAllAndEmptyToList() {
        let url = this.APIURL + this.Controller + '/GetAllAndEmptyToList';
        const formUpload: FormData = new FormData();
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    GetAllAndEmptyToListAsync() {
        let url = this.APIURL + this.Controller + '/GetAllAndEmptyToListAsync';
        const formUpload: FormData = new FormData();
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    GetByParentIDAndEmptyToList() {
        let url = this.APIURL + this.Controller + '/GetByParentIDAndEmptyToList';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    GetByParentIDAndEmptyToListAsync() {
        let url = this.APIURL + this.Controller + '/GetByParentIDAndEmptyToListAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    GetByCodeAndEmptyToList() {
        let url = this.APIURL + this.Controller + '/GetByCodeAndEmptyToList';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    GetByCodeAndEmptyToListAsync() {
        let url = this.APIURL + this.Controller + '/GetByCodeAndEmptyToListAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    GetByParentID_SearchString_EmptyToList() {
        let url = this.APIURL + this.Controller + '/GetByParentID_SearchString_EmptyToList';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    GetByParentID_SearchString_EmptyToListAsync() {
        let url = this.APIURL + this.Controller + '/GetByParentID_SearchString_EmptyToListAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    GetByDanhMucUngDungIDAndEmptyToList() {
        let url = this.APIURL + this.Controller + '/GetByDanhMucUngDungIDAndEmptyToList';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    GetByDanhMucUngDungIDAndEmptyToListAsync() {
        let url = this.APIURL + this.Controller + '/GetByDanhMucUngDungIDAndEmptyToListAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    GetByDanhMucUngDungID_SearchString_EmptyToList() {
        let url = this.APIURL + this.Controller + '/GetByDanhMucUngDungID_SearchString_EmptyToList';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    GetByDanhMucUngDungID_SearchString_EmptyToListAsync() {
        let url = this.APIURL + this.Controller + '/GetByDanhMucUngDungID_SearchString_EmptyToListAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    GetByParentIDAndActiveAndEmptyToList() {
        let url = this.APIURL + this.Controller + '/GetByParentIDAndActiveAndEmptyToList';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    GetByParentIDAndActiveAndEmptyToListAsync() {
        let url = this.APIURL + this.Controller + '/GetByParentIDAndActiveAndEmptyToListAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    GetByLastUpdatedMembershipIDAndEmptyToList() {
        let url = this.APIURL + this.Controller + '/GetByLastUpdatedMembershipIDAndEmptyToList';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    GetByLastUpdatedMembershipIDAndEmptyToListAsync() {
        let url = this.APIURL + this.Controller + '/GetByLastUpdatedMembershipIDAndEmptyToListAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    GetBySearchStringAndEmptyToList() {
        let url = this.APIURL + this.Controller + '/GetBySearchStringAndEmptyToList';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    GetBySearchStringAndEmptyToListAsync() {
        let url = this.APIURL + this.Controller + '/GetBySearchStringAndEmptyToListAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    SaveAndUploadFile() {
        this.Initialization();
        let url = this.APIURL + this.Controller + '/SaveAndUploadFile';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.FormData));
        if (this.FileToUpload) {
            if (this.FileToUpload.length > 0) {
                for (var i = 0; i < this.FileToUpload.length; i++) {
                    formUpload.append('file[]', this.FileToUpload[i]);
                }
            }
        }
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    SaveAndUploadFileAsync() {
        this.Initialization();
        let url = this.APIURL + this.Controller + '/SaveAndUploadFileAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.FormData));
        if (this.FileToUpload) {
            if (this.FileToUpload.length > 0) {
                for (var i = 0; i < this.FileToUpload.length; i++) {
                    formUpload.append('file[]', this.FileToUpload[i]);
                }
            }
        }
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    SaveAndUploadFiles() {
        this.Initialization();
        let url = this.APIURL + this.Controller + '/SaveAndUploadFiles';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.FormData));
        if (this.FileToUpload) {
            if (this.FileToUpload.length > 0) {
                for (var i = 0; i < this.FileToUpload.length; i++) {
                    formUpload.append('file[]', this.FileToUpload[i]);
                }
            }
        }
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }
    SaveAndUploadFilesAsync() {
        this.Initialization();
        let url = this.APIURL + this.Controller + '/SaveAndUploadFilesAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.FormData));
        if (this.FileToUpload) {
            if (this.FileToUpload.length > 0) {
                for (var i = 0; i < this.FileToUpload.length; i++) {
                    formUpload.append('file[]', this.FileToUpload[i]);
                }
            }
        }
        return this.httpClient.post(url, formUpload, { headers: this.Headers });
    }

}


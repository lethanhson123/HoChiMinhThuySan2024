import { Base } from "./Base.model";
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';

export class BaseParameter extends Base{   
    ListID?: number[];
    SearchString?: string;
    Token?: string;
    IDString?: string;
    Password01?: string;
    Password02?: string;
    Password03?: string;
    TaiKhoan?: string;
    MaSo?: string;
    Page?: number;
    PageSize?: number;    
    ThanhVienID?: number;    
    DanhMucUngDungID?: number;    
    DanhMucChucNangID?: number;    
    DanhMucXaPhuongID?: number;    
    DanhMucQuanHuyenID?: number;    
    DanhMucGiongID?: number;    
    ToChucID?: number;    
    LoHangID?: number;   
    ToChucVungNuoiID?: number;   
    ToChucVungNuoiName?: string;   
    Nam?: number;
    Thang?: number;
    NgayGhiNhan?: Date;
    BatDau?: Date;
    KetThuc?: Date;  
}

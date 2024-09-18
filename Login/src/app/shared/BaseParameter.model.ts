import { Base } from "./Base.model";
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';

export class BaseParameter extends Base{
    SearchString?: string;
    Token?: string;
    IDString?: string;
    Password01?: string;
    Password02?: string;
    Password03?: string;
    TaiKhoan?: string;
    Year?: number;
    Page?: number;
    PageSize?: number;    
    ThanhVienID?: number;    
    ToChucID?: number;    
    DanhMucQuyTrinhSanXuatPhanLoaiID?: number;    
    DanhMucDuAnID?: number;    
    DanhMucSanPhamID?: number;    
    DanhMucTinhThanhID?: number;    
    DanhMucQuanHuyenID?: number;    
    DanhMucXaPhuongID?: number;    
    ToChucVungTrongID?: number;    
    NgayGhiNhan?: Date;
    BatDau?: Date;
    KetThuc?: Date;
    MatSort?: MatSort;    
    MatPaginator?: MatPaginator;    
}

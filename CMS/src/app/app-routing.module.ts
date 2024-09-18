import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomepageComponent } from './homepage/homepage.component';
import { LoginComponent } from './login/login.component';
import { DanhMucChucNangComponent } from './danh-muc-chuc-nang/danh-muc-chuc-nang.component';
import { DanhMucThanhVienComponent } from './danh-muc-thanh-vien/danh-muc-thanh-vien.component';
import { ThanhVienComponent } from './thanh-vien/thanh-vien.component';
import { ThanhVienLichSuTruyCapComponent } from './thanh-vien-lich-su-truy-cap/thanh-vien-lich-su-truy-cap.component';
import { ThanhVienTokenComponent } from './thanh-vien-token/thanh-vien-token.component';
import { ThanhVienThongTinComponent } from './thanh-vien-thong-tin/thanh-vien-thong-tin.component';
import { GioiThieuComponent } from './gioi-thieu/gioi-thieu.component';
import { UploadComponent } from './upload/upload.component';
import { DanhMucNgonNguComponent } from './danh-muc-ngon-ngu/danh-muc-ngon-ngu.component';
import { HuongDanComponent } from './huong-dan/huong-dan.component';
import { DanhMucQuanHuyenComponent } from './danh-muc-quan-huyen/danh-muc-quan-huyen.component';
import { DanhMucTinhThanhComponent } from './danh-muc-tinh-thanh/danh-muc-tinh-thanh.component';
import { DanhMucXaPhuongComponent } from './danh-muc-xa-phuong/danh-muc-xa-phuong.component';
import { DanhMucToChucComponent } from './danh-muc-to-chuc/danh-muc-to-chuc.component';
import { DanhMucNganhNgheComponent } from './danh-muc-nganh-nghe/danh-muc-nganh-nghe.component';
import { DanhMucLoaiGiongComponent } from './danh-muc-loai-giong/danh-muc-loai-giong.component';
import { DanhMucHieuMayComponent } from './danh-muc-hieu-may/danh-muc-hieu-may.component';
import { DanhMucGiongComponent } from './danh-muc-giong/danh-muc-giong.component';
import { DanhMucAPIComponent } from './danh-muc-api/danh-muc-api.component';
import { ToChucComponent } from './to-chuc/to-chuc.component';
import { ThongBaoComponent } from './thong-bao/thong-bao.component';
import { Upload004Component } from './upload004/upload004.component';
import { Upload003Component } from './upload003/upload003.component';
import { Upload002Component } from './upload002/upload002.component';
import { Upload001Component } from './upload001/upload001.component';
import { DanhMucTieuChuanComponent } from './danh-muc-tieu-chuan/danh-muc-tieu-chuan.component';
import { ToChucTramQuanTracComponent } from './to-chuc-tram-quan-trac/to-chuc-tram-quan-trac.component';
import { ToChucHoNuoiComponent } from './to-chuc-ho-nuoi/to-chuc-ho-nuoi.component';
import { ToChucHopTacXaComponent } from './to-chuc-hop-tac-xa/to-chuc-hop-tac-xa.component';
import { ToChucHoNuoi001Component } from './to-chuc-ho-nuoi001/to-chuc-ho-nuoi001.component';
import { ToChucPhuongTienKhaiThacComponent } from './to-chuc-phuong-tien-khai-thac/to-chuc-phuong-tien-khai-thac.component';
import { ToChucPhuongTienKhaiThac001Component } from './to-chuc-phuong-tien-khai-thac001/to-chuc-phuong-tien-khai-thac001.component';
import { ToChucGiongComponent } from './to-chuc-giong/to-chuc-giong.component';
import { ToChucGiong001Component } from './to-chuc-giong001/to-chuc-giong001.component';
import { Upload005Component } from './upload005/upload005.component';
import { Upload006Component } from './upload006/upload006.component';
import { ToChucVungTrongComponent } from './to-chuc-vung-trong/to-chuc-vung-trong.component';
import { DanhMucLoaiHinhComponent } from './danh-muc-loai-hinh/danh-muc-loai-hinh.component';
import { ToChucCuaHangComponent } from './to-chuc-cua-hang/to-chuc-cua-hang.component';
import { ToChucInfoComponent } from './to-chuc-info/to-chuc-info.component';
import { BanDo001Component } from './ban-do001/ban-do001.component';
import { BanDo005Component } from './ban-do005/ban-do005.component';
import { BanDo004Component } from './ban-do004/ban-do004.component';
import { BanDo003Component } from './ban-do003/ban-do003.component';
import { BanDo002Component } from './ban-do002/ban-do002.component';
import { BanDo000Component } from './ban-do000/ban-do000.component';
import { BanDo006Component } from './ban-do006/ban-do006.component';
import { BanDo007Component } from './ban-do007/ban-do007.component';
import { ToChucLongBeComponent } from './to-chuc-long-be/to-chuc-long-be.component';
import { ToChucNuoiNhuyenTheComponent } from './to-chuc-nuoi-nhuyen-the/to-chuc-nuoi-nhuyen-the.component';
import { Dashboard000Component } from './dashboard000/dashboard000.component';
import { ThongKe000Component } from './thong-ke000/thong-ke000.component';
import { ToChucDanhMucGiong001Component } from './to-chuc-danh-muc-giong001/to-chuc-danh-muc-giong001.component';
import { DanhMucChiTieuMoiTruongComponent } from './danh-muc-chi-tieu-moi-truong/danh-muc-chi-tieu-moi-truong.component';
import { ChiTieuMoiTruongComponent } from './chi-tieu-moi-truong/chi-tieu-moi-truong.component';
import { ThanhVien001Component } from './thanh-vien001/thanh-vien001.component';
import { ThanhVien002Component } from './thanh-vien002/thanh-vien002.component';
import { ThanhVien003Component } from './thanh-vien003/thanh-vien003.component';
import { ThanhVien004Component } from './thanh-vien004/thanh-vien004.component';
import { Upload007Component } from './upload007/upload007.component';
import { Upload008Component } from './upload008/upload008.component';
import { Upload009Component } from './upload009/upload009.component';


const routes: Routes = [
  { path: '', redirectTo: '/Login', pathMatch: 'full' },
  {
    path: 'Homepage', component: HomepageComponent,
  },
  {
    path: 'Login', component: LoginComponent,
  },  
  {
    path: 'GioiThieu', component: GioiThieuComponent,
  },  
  {
    path: 'HuongDan', component: HuongDanComponent,
  },  

  {
    path: 'ChiTieuMoiTruong', component: ChiTieuMoiTruongComponent,
  }, 

  {
    path: 'DanhMucChiTieuMoiTruong', component: DanhMucChiTieuMoiTruongComponent,
  }, 
  {
    path: 'DanhMucChucNang', component: DanhMucChucNangComponent,
  },  
  {
    path: 'DanhMucThanhVien', component: DanhMucThanhVienComponent,
  },  
  {
    path: 'DanhMucNgonNgu', component: DanhMucNgonNguComponent,
  },  
  {
    path: 'DanhMucQuanHuyen', component: DanhMucQuanHuyenComponent,
  }, 
  {
    path: 'DanhMucTinhThanh', component: DanhMucTinhThanhComponent,
  },  
  {
    path: 'DanhMucXaPhuong', component: DanhMucXaPhuongComponent,
  }, 
  {
    path: 'DanhMucToChuc', component: DanhMucToChucComponent,
  }, 
  {
    path: 'DanhMucAPI', component: DanhMucAPIComponent,
  }, 
  {
    path: 'DanhMucGiong', component: DanhMucGiongComponent,
  }, 
  {
    path: 'DanhMucHieuMay', component: DanhMucHieuMayComponent,
  }, 
  {
    path: 'DanhMucLoaiGiong', component: DanhMucLoaiGiongComponent,
  }, 
  {
    path: 'DanhMucNganhNghe', component: DanhMucNganhNgheComponent,
  }, 
  {
    path: 'DanhMucTieuChuan', component: DanhMucTieuChuanComponent,
  }, 
  {
    path: 'DanhMucLoaiHinh', component: DanhMucLoaiHinhComponent,
  }, 

  {
    path: 'ThanhVien', component: ThanhVienComponent,
  }, 
  {
    path: 'ThanhVien001', component: ThanhVien001Component,
  }, 
  {
    path: 'ThanhVien002', component: ThanhVien002Component,
  }, 
  {
    path: 'ThanhVien003', component: ThanhVien003Component,
  }, 
  {
    path: 'ThanhVien004', component: ThanhVien004Component,
  }, 
  {
    path: 'ThanhVienLichSuTruyCap', component: ThanhVienLichSuTruyCapComponent,
  }, 
  {
    path: 'ThanhVienToken', component: ThanhVienTokenComponent,
  },  
  {
    path: 'ThanhVienThongTin', component: ThanhVienThongTinComponent,
  },  

  {
    path: 'ToChucInfo/:ID', component: ToChucInfoComponent,
  },  
  {
    path: 'ToChuc', component: ToChucComponent,
  },  
  {
    path: 'ToChucTramQuanTrac', component: ToChucTramQuanTracComponent,
  },  
  {
    path: 'ToChucHopTacXa', component: ToChucHopTacXaComponent,
  },  
  {
    path: 'ToChucVungTrong', component: ToChucVungTrongComponent,
  },  
  {
    path: 'ToChucHoNuoi', component: ToChucHoNuoiComponent,
  },  
  {
    path: 'ToChucHoNuoi001', component: ToChucHoNuoi001Component,
  },  
  {
    path: 'ToChucPhuongTienKhaiThac', component: ToChucPhuongTienKhaiThacComponent,
  },  
  {
    path: 'ToChucPhuongTienKhaiThac001', component: ToChucPhuongTienKhaiThac001Component,
  },  
  {
    path: 'ToChucGiong', component: ToChucGiongComponent,
  },  
  {
    path: 'ToChucGiong001', component: ToChucGiong001Component,
  }, 
  {
    path: 'ToChucCuaHang', component: ToChucCuaHangComponent,
  },  
  {
    path: 'ToChucNuoiNhuyenThe', component: ToChucNuoiNhuyenTheComponent,
  },  
  {
    path: 'ToChucLongBe', component: ToChucLongBeComponent,
  },  
  {
    path: 'ToChucDanhMucGiong001', component: ToChucDanhMucGiong001Component,
  },  

  {
    path: 'ThongBao', component: ThongBaoComponent,
  }, 

  {
    path: 'Upload', component: UploadComponent,
  },  
  {
    path: 'Upload001', component: Upload001Component,
  },  
  {
    path: 'Upload002', component: Upload002Component,
  },  
  {
    path: 'Upload003', component: Upload003Component,
  },  
  {
    path: 'Upload004', component: Upload004Component,
  },  
  {
    path: 'Upload005', component: Upload005Component,
  },
  {
    path: 'Upload006', component: Upload006Component,
  },
  {
    path: 'Upload007', component: Upload007Component,
  },
  {
    path: 'Upload008', component: Upload008Component,
  },
  {
    path: 'Upload009', component: Upload009Component,
  },

  {
    path: 'BanDo000', component: BanDo000Component,
  },
  {
    path: 'BanDo001', component: BanDo001Component,
  },
  {
    path: 'BanDo002', component: BanDo002Component,
  },
  {
    path: 'BanDo003', component: BanDo003Component,
  },
  {
    path: 'BanDo004', component: BanDo004Component,
  },
  {
    path: 'BanDo005', component: BanDo005Component,
  },
  {
    path: 'BanDo006', component: BanDo006Component,
  },
  {
    path: 'BanDo007', component: BanDo007Component,
  },

  {
    path: 'Dashboard000', component: Dashboard000Component,
  },

  {
    path: 'ThongKe000', component: ThongKe000Component,
  },

];

@NgModule({
  imports: [RouterModule.forRoot(routes, { useHash: true, initialNavigation: 'enabled' })],
  exports: [RouterModule]
})
export class AppRoutingModule { }










































































import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CKEditorModule } from 'ngx-ckeditor';
import { ChartsModule } from 'ng2-charts';
import { CookieService } from 'ngx-cookie-service';
import { MAT_DATE_LOCALE } from '@angular/material/core';
import { MaterialModule } from './material/material.module';
import { GoogleMapsModule } from '@angular/google-maps';
import { NotificationService } from './shared/Notification.service';
import { AppComponent } from './app.component';
import { LoadingComponent } from './loading/loading.component';
import { HomepageComponent } from './homepage/homepage.component';
import { LoginComponent } from './login/login.component';
import { DanhMucThanhVienComponent } from './danh-muc-thanh-vien/danh-muc-thanh-vien.component';
import { ThanhVienComponent } from './thanh-vien/thanh-vien.component';
import { ThanhVienLichSuTruyCapComponent } from './thanh-vien-lich-su-truy-cap/thanh-vien-lich-su-truy-cap.component';
import { ThanhVienTokenComponent } from './thanh-vien-token/thanh-vien-token.component';
import { DanhMucChucNangComponent } from './danh-muc-chuc-nang/danh-muc-chuc-nang.component';
import { ThanhVienDetailComponent } from './thanh-vien-detail/thanh-vien-detail.component';
import { ThanhVienThongTinComponent } from './thanh-vien-thong-tin/thanh-vien-thong-tin.component';
import { GioiThieuComponent } from './gioi-thieu/gioi-thieu.component';
import { UploadComponent } from './upload/upload.component';
import { DanhMucNgonNguComponent } from './danh-muc-ngon-ngu/danh-muc-ngon-ngu.component';
import { ThanhVienChucNangDetailComponent } from './thanh-vien-chuc-nang-detail/thanh-vien-chuc-nang-detail.component';
import { DanhMucAPIComponent } from './danh-muc-api/danh-muc-api.component';
import { DanhMucGiongComponent } from './danh-muc-giong/danh-muc-giong.component';
import { DanhMucHieuMayComponent } from './danh-muc-hieu-may/danh-muc-hieu-may.component';
import { DanhMucLoaiGiongComponent } from './danh-muc-loai-giong/danh-muc-loai-giong.component';
import { DanhMucNganhNgheComponent } from './danh-muc-nganh-nghe/danh-muc-nganh-nghe.component';
import { DanhMucQuanHuyenComponent } from './danh-muc-quan-huyen/danh-muc-quan-huyen.component';
import { DanhMucTinhThanhComponent } from './danh-muc-tinh-thanh/danh-muc-tinh-thanh.component';
import { DanhMucTinhThanhToaDoDetailComponent } from './danh-muc-tinh-thanh-toa-do-detail/danh-muc-tinh-thanh-toa-do-detail.component';
import { DanhMucToChucComponent } from './danh-muc-to-chuc/danh-muc-to-chuc.component';
import { DanhMucXaPhuongComponent } from './danh-muc-xa-phuong/danh-muc-xa-phuong.component';
import { ThongBaoComponent } from './thong-bao/thong-bao.component';
import { ThongBaoDetailComponent } from './thong-bao-detail/thong-bao-detail.component';
import { ToChucComponent } from './to-chuc/to-chuc.component';
import { ToChucDetailComponent } from './to-chuc-detail/to-chuc-detail.component';
import { Upload001Component } from './upload001/upload001.component';
import { Upload002Component } from './upload002/upload002.component';
import { Upload003Component } from './upload003/upload003.component';
import { Upload004Component } from './upload004/upload004.component';
import { HuongDanComponent } from './huong-dan/huong-dan.component';
import { DanhMucTieuChuanComponent } from './danh-muc-tieu-chuan/danh-muc-tieu-chuan.component';
import { ToChucTramQuanTracComponent } from './to-chuc-tram-quan-trac/to-chuc-tram-quan-trac.component';
import { ToChucTramQuanTracDetailComponent } from './to-chuc-tram-quan-trac-detail/to-chuc-tram-quan-trac-detail.component';
import { ToChucHopTacXaComponent } from './to-chuc-hop-tac-xa/to-chuc-hop-tac-xa.component';
import { ToChucHopTacXaDetailComponent } from './to-chuc-hop-tac-xa-detail/to-chuc-hop-tac-xa-detail.component';
import { ToChucHoNuoiComponent } from './to-chuc-ho-nuoi/to-chuc-ho-nuoi.component';
import { ToChucHoNuoiDetailComponent } from './to-chuc-ho-nuoi-detail/to-chuc-ho-nuoi-detail.component';
import { ToChucHoNuoi001Component } from './to-chuc-ho-nuoi001/to-chuc-ho-nuoi001.component';
import { ToChucPhuongTienKhaiThacComponent } from './to-chuc-phuong-tien-khai-thac/to-chuc-phuong-tien-khai-thac.component';
import { ToChucPhuongTienKhaiThac001Component } from './to-chuc-phuong-tien-khai-thac001/to-chuc-phuong-tien-khai-thac001.component';
import { ToChucPhuongTienKhaiThacDetailComponent } from './to-chuc-phuong-tien-khai-thac-detail/to-chuc-phuong-tien-khai-thac-detail.component';
import { ToChucGiongComponent } from './to-chuc-giong/to-chuc-giong.component';
import { ToChucGiong001Component } from './to-chuc-giong001/to-chuc-giong001.component';
import { ToChucGiongDetailComponent } from './to-chuc-giong-detail/to-chuc-giong-detail.component';
import { ToChucVungTrongComponent } from './to-chuc-vung-trong/to-chuc-vung-trong.component';
import { ToChucVungTrongDetailComponent } from './to-chuc-vung-trong-detail/to-chuc-vung-trong-detail.component';
import { Upload005Component } from './upload005/upload005.component';
import { Upload006Component } from './upload006/upload006.component';
import { DanhMucLoaiHinhComponent } from './danh-muc-loai-hinh/danh-muc-loai-hinh.component';
import { ToChucCuaHangComponent } from './to-chuc-cua-hang/to-chuc-cua-hang.component';
import { ToChucCuaHangDetailComponent } from './to-chuc-cua-hang-detail/to-chuc-cua-hang-detail.component';
import { ToChucInfoComponent } from './to-chuc-info/to-chuc-info.component';
import { BanDo001Component } from './ban-do001/ban-do001.component';
import { BanDo002Component } from './ban-do002/ban-do002.component';
import { BanDo003Component } from './ban-do003/ban-do003.component';
import { BanDo004Component } from './ban-do004/ban-do004.component';
import { BanDo005Component } from './ban-do005/ban-do005.component';
import { BanDo006Component } from './ban-do006/ban-do006.component';
import { BanDo007Component } from './ban-do007/ban-do007.component';
import { BanDo000Component } from './ban-do000/ban-do000.component';
import { ToChucToaDoDetailComponent } from './to-chuc-toa-do-detail/to-chuc-toa-do-detail.component';
import { ToChucLongBeComponent } from './to-chuc-long-be/to-chuc-long-be.component';
import { ToChucLongBeDetailComponent } from './to-chuc-long-be-detail/to-chuc-long-be-detail.component';
import { ToChucLongBe001Component } from './to-chuc-long-be001/to-chuc-long-be001.component';

import { ToChucNuoiNhuyenTheComponent } from './to-chuc-nuoi-nhuyen-the/to-chuc-nuoi-nhuyen-the.component';
import { ToChucNuoiNhuyenThe001Component } from './to-chuc-nuoi-nhuyen-the001/to-chuc-nuoi-nhuyen-the001.component';
import { ToChucNuoiNhuyenTheDetailComponent } from './to-chuc-nuoi-nhuyen-the-detail/to-chuc-nuoi-nhuyen-the-detail.component';
import { Dashboard000Component } from './dashboard000/dashboard000.component';
import { ThongKe000Component } from './thong-ke000/thong-ke000.component';
import { DanhMucTinhThanhToaDoDetail002Component } from './danh-muc-tinh-thanh-toa-do-detail002/danh-muc-tinh-thanh-toa-do-detail002.component';
import { DanhMucTinhThanhToaDoDetail001Component } from './danh-muc-tinh-thanh-toa-do-detail001/danh-muc-tinh-thanh-toa-do-detail001.component';
import { ToChucDanhMucGiong001Component } from './to-chuc-danh-muc-giong001/to-chuc-danh-muc-giong001.component';
import { DanhMucChiTieuMoiTruongComponent } from './danh-muc-chi-tieu-moi-truong/danh-muc-chi-tieu-moi-truong.component';
import { ChiTieuMoiTruongComponent } from './chi-tieu-moi-truong/chi-tieu-moi-truong.component';
import { ChiTieuMoiTruongDetailComponent } from './chi-tieu-moi-truong-detail/chi-tieu-moi-truong-detail.component';
import { ThanhVien001Component } from './thanh-vien001/thanh-vien001.component';
import { ThanhVien002Component } from './thanh-vien002/thanh-vien002.component';
import { ThanhVien003Component } from './thanh-vien003/thanh-vien003.component';
import { ThanhVien004Component } from './thanh-vien004/thanh-vien004.component';
import { ThanhVienDetail001Component } from './thanh-vien-detail001/thanh-vien-detail001.component';
import { Upload007Component } from './upload007/upload007.component';
import { Upload008Component } from './upload008/upload008.component';
import { Upload009Component } from './upload009/upload009.component';




@NgModule({
  declarations: [
    AppComponent,
    LoadingComponent,
    HomepageComponent,
    LoginComponent,
    DanhMucThanhVienComponent,
    ThanhVienComponent,
    ThanhVienLichSuTruyCapComponent,
    ThanhVienTokenComponent,
    DanhMucChucNangComponent,
    ThanhVienDetailComponent,
    ThanhVienThongTinComponent,
    GioiThieuComponent,
    UploadComponent,
    DanhMucNgonNguComponent,
    ThanhVienChucNangDetailComponent,
    DanhMucAPIComponent,
    DanhMucGiongComponent,
    DanhMucHieuMayComponent,
    DanhMucLoaiGiongComponent,
    DanhMucNganhNgheComponent,
    DanhMucQuanHuyenComponent,
    DanhMucTinhThanhComponent,
    DanhMucTinhThanhToaDoDetailComponent,
    DanhMucToChucComponent,
    DanhMucXaPhuongComponent,
    ThongBaoComponent,
    ThongBaoDetailComponent,
    ToChucComponent,
    ToChucDetailComponent,
    Upload001Component,
    Upload002Component,
    Upload003Component,
    Upload004Component,
    HuongDanComponent,
    DanhMucTieuChuanComponent,
    ToChucTramQuanTracComponent,
    ToChucTramQuanTracDetailComponent,
    ToChucHopTacXaComponent,
    ToChucHopTacXaDetailComponent,
    ToChucHoNuoiComponent,
    ToChucHoNuoiDetailComponent,
    ToChucHoNuoi001Component,
    ToChucPhuongTienKhaiThacComponent,
    ToChucPhuongTienKhaiThac001Component,
    ToChucPhuongTienKhaiThacDetailComponent,
    ToChucGiongComponent,
    ToChucGiong001Component,
    ToChucGiongDetailComponent,
    ToChucVungTrongComponent,
    ToChucVungTrongDetailComponent,
    Upload005Component,
    Upload006Component,
    DanhMucLoaiHinhComponent,
    ToChucCuaHangComponent,
    ToChucCuaHangDetailComponent,
    ToChucInfoComponent,
    BanDo001Component,
    BanDo002Component,
    BanDo003Component,
    BanDo004Component,
    BanDo005Component,
    BanDo006Component,
    BanDo007Component,
    BanDo000Component,
    ToChucToaDoDetailComponent,
    ToChucLongBeComponent,
    ToChucLongBeDetailComponent,
    ToChucLongBe001Component,
    ToChucNuoiNhuyenTheComponent,
    ToChucNuoiNhuyenThe001Component,
    ToChucNuoiNhuyenTheDetailComponent, 
    Dashboard000Component, 
    ThongKe000Component, 
    DanhMucTinhThanhToaDoDetail002Component, 
    DanhMucTinhThanhToaDoDetail001Component, 
    ToChucDanhMucGiong001Component, 
    DanhMucChiTieuMoiTruongComponent, 
    ChiTieuMoiTruongComponent, 
    ChiTieuMoiTruongDetailComponent, 
    ThanhVien001Component, 
    ThanhVien002Component, 
    ThanhVien003Component, 
    ThanhVien004Component, 
    ThanhVienDetail001Component, 
    Upload007Component, 
    Upload008Component, Upload009Component,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'serverApp' }),
    FormsModule,
    HttpClientModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MaterialModule,
    GoogleMapsModule,
    ChartsModule,
    CKEditorModule,
  ],
  providers: [
    CookieService,
    NotificationService,
    { provide: MAT_DATE_LOCALE, useValue: 'en-GB' }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

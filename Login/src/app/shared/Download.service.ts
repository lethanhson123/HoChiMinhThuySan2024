import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
@Injectable({
    providedIn: 'root'
})
export class DownloadService {
    aPIURL: string = environment.APIURL;
    controller: string = "Download";
    LanguageID: boolean = true;
    TitleTaiKhoan: string = environment.InitializationString;
    TitleMatKhau: string = environment.InitializationString;
    TitleDangNhap: string = environment.InitializationString;
    TitleDangKy: string = environment.InitializationString;
    TitleQuenMatKhau: string = environment.InitializationString;
    TitleQuenMatKhauButton: string = environment.InitializationString;
    TitleHoTen: string = environment.InitializationString;
    TitleDienThoai: string = environment.InitializationString;
    TitleCCCD: string = environment.InitializationString;
    constructor(private httpClient: HttpClient) {
        this.initializationFormData();
        this.ChangeLanguage();
    }
    initializationFormData() {
    }
    GetRandomColor(count) {
        var arr = [];
        for (var i = 0; i < count; i++) {
            var letters = '0123456789ABCDEF'.split('');
            var color = '#';
            for (var x = 0; x < 6; x++) {
                color += letters[Math.floor(Math.random() * 16)];
            }
        }
        return color;
    }
    PageTitle() {
        return "Du lịch thành phố Hồ Chí Minh";
    }
    ChangeLanguage() {
        if (this.LanguageID == true) {
            this.TitleTaiKhoan = "Tài khoản";
            this.TitleMatKhau = "Mật khẩu";
            this.TitleDangNhap = "Đăng nhập";
            this.TitleDangKy = "Đăng ký";
            this.TitleQuenMatKhau = "Quên mật khẩu?";
            this.TitleQuenMatKhauButton = "Khôi phục mật khẩu";
            this.TitleHoTen = "Họ tên";
            this.TitleDienThoai = "Điện thoại";
            this.TitleCCCD = "Căn cước công dân";
        }
        else {
            this.TitleTaiKhoan = "Account";
            this.TitleMatKhau = "Password";
            this.TitleDangNhap = "Login";
            this.TitleDangKy = "Register";
            this.TitleQuenMatKhau = "Forgot password?";
            this.TitleQuenMatKhauButton = "Password recovery";
            this.TitleHoTen = "Full Name";
            this.TitleDienThoai = "Phone";
            this.TitleCCCD = "Passport";
        }
    }
}


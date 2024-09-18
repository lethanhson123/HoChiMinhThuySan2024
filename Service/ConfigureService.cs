using Data.Model;
using Repository.Implement;
using Repository.Interface;
using Service.Implement;
using Service.Interface;

namespace Service
{
    public static class ConfigureService
    {
        public static IServiceCollection AddJWT(this IServiceCollection services)
        {         

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = GlobalHelper.Audience,
                    ValidIssuer = GlobalHelper.Issuer,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(GlobalHelper.Key))
                };
            });
            return services;
        }
        public static IServiceCollection AddContext(this IServiceCollection services)
        {
            services.AddDbContext<Context>(opts =>
            {
            });
            return services;
        }
        public static IServiceCollection AddService(this IServiceCollection services)
        {
            services.AddTransient<IChiTieuMoiTruongService, ChiTieuMoiTruongService>();

            services.AddTransient<IDanhMucAPIService, DanhMucAPIService>();
            services.AddTransient<IDanhMucChucNangService, DanhMucChucNangService>();
            services.AddTransient<IDanhMucGiongService, DanhMucGiongService>();
            services.AddTransient<IDanhMucHieuMayService, DanhMucHieuMayService>();
            services.AddTransient<IDanhMucLoaiGiongService, DanhMucLoaiGiongService>();
            services.AddTransient<IDanhMucNganhNgheService, DanhMucNganhNgheService>();
            services.AddTransient<IDanhMucNgonNguService, DanhMucNgonNguService>();
            services.AddTransient<IDanhMucQuanHuyenService, DanhMucQuanHuyenService>();
            services.AddTransient<IDanhMucQuocGiaService, DanhMucQuocGiaService>();
            services.AddTransient<IDanhMucThanhVienService, DanhMucThanhVienService>();
            services.AddTransient<IDanhMucTinhThanhService, DanhMucTinhThanhService>();
            services.AddTransient<IDanhMucTinhThanhToaDoService, DanhMucTinhThanhToaDoService>();            
            services.AddTransient<IDanhMucToChucService, DanhMucToChucService>();
            services.AddTransient<IDanhMucXaPhuongService, DanhMucXaPhuongService>();
            services.AddTransient<IDanhMucTieuChuanService, DanhMucTieuChuanService>();
            services.AddTransient<IDanhMucLoaiHinhService, DanhMucLoaiHinhService>();
            services.AddTransient<IDanhMucCuaHangService, DanhMucCuaHangService>();
            services.AddTransient<IDanhMucNguyenVatLieuService, DanhMucNguyenVatLieuService>();
            services.AddTransient<IDanhMucChiTieuMoiTruongService, DanhMucChiTieuMoiTruongService>();

            services.AddTransient<IThanhVienService, ThanhVienService>();
            services.AddTransient<IThanhVienChucNangService, ThanhVienChucNangService>();
            services.AddTransient<IThanhVienLichSuTruyCapService, ThanhVienLichSuTruyCapService>();
            services.AddTransient<IThanhVienThongBaoService, ThanhVienThongBaoService>();
            services.AddTransient<IThanhVienTokenService, ThanhVienTokenService>();

            services.AddTransient<IThongBaoService, ThongBaoService>();
            services.AddTransient<IThongBaoThanhVienService, ThongBaoThanhVienService>();

            services.AddTransient<IToChucService, ToChucService>();
            services.AddTransient<IToChucQuanLyService, ToChucQuanLyService>();
            services.AddTransient<IToChucTapTinDinhKemService, ToChucTapTinDinhKemService>();
            services.AddTransient<IToChucToaDoService, ToChucToaDoService>();
            services.AddTransient<IToChucLongBeService, ToChucLongBeService>();
            services.AddTransient<IToChucNuoiNhuyenTheService, ToChucNuoiNhuyenTheService>();
            services.AddTransient<IToChucPhuongTienKhaiThacService, ToChucPhuongTienKhaiThacService>();
            services.AddTransient<IToChucVungNuoiService, ToChucVungNuoiService>();
            services.AddTransient<IToChucGiongService, ToChucGiongService>();
            services.AddTransient<IToChucTieuChuanService, ToChucTieuChuanService>();
            services.AddTransient<IToChucNguyenVatLieuService, ToChucNguyenVatLieuService>();

            services.AddTransient<IReportService, ReportService>();

            services.AddSingleton(HtmlEncoder.Create(allowedRanges: new[] { UnicodeRanges.All }));

            return services;
        }

        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddTransient<IChiTieuMoiTruongRepository, ChiTieuMoiTruongRepository>();

            services.AddTransient<IDanhMucAPIRepository, DanhMucAPIRepository>();
            services.AddTransient<IDanhMucChucNangRepository, DanhMucChucNangRepository>();
            services.AddTransient<IDanhMucGiongRepository, DanhMucGiongRepository>();
            services.AddTransient<IDanhMucHieuMayRepository, DanhMucHieuMayRepository>();
            services.AddTransient<IDanhMucLoaiGiongRepository, DanhMucLoaiGiongRepository>();
            services.AddTransient<IDanhMucNganhNgheRepository, DanhMucNganhNgheRepository>();
            services.AddTransient<IDanhMucNgonNguRepository, DanhMucNgonNguRepository>();
            services.AddTransient<IDanhMucQuanHuyenRepository, DanhMucQuanHuyenRepository>();
            services.AddTransient<IDanhMucQuocGiaRepository, DanhMucQuocGiaRepository>();
            services.AddTransient<IDanhMucThanhVienRepository, DanhMucThanhVienRepository>();
            services.AddTransient<IDanhMucTinhThanhRepository, DanhMucTinhThanhRepository>();
            services.AddTransient<IDanhMucTinhThanhToaDoRepository, DanhMucTinhThanhToaDoRepository>();
            services.AddTransient<IDanhMucToChucRepository, DanhMucToChucRepository>();
            services.AddTransient<IDanhMucXaPhuongRepository, DanhMucXaPhuongRepository>();
            services.AddTransient<IDanhMucTieuChuanRepository, DanhMucTieuChuanRepository>();
            services.AddTransient<IDanhMucLoaiHinhRepository, DanhMucLoaiHinhRepository>();
            services.AddTransient<IDanhMucCuaHangRepository, DanhMucCuaHangRepository>();
            services.AddTransient<IDanhMucNguyenVatLieuRepository, DanhMucNguyenVatLieuRepository>();
            services.AddTransient<IDanhMucChiTieuMoiTruongRepository, DanhMucChiTieuMoiTruongRepository>();


            services.AddTransient<IThanhVienRepository, ThanhVienRepository>();
            services.AddTransient<IThanhVienChucNangRepository, ThanhVienChucNangRepository>();
            services.AddTransient<IThanhVienLichSuTruyCapRepository, ThanhVienLichSuTruyCapRepository>();
            services.AddTransient<IThanhVienThongBaoRepository, ThanhVienThongBaoRepository>();
            services.AddTransient<IThanhVienTokenRepository, ThanhVienTokenRepository>();

            services.AddTransient<IThongBaoRepository, ThongBaoRepository>();
            services.AddTransient<IThongBaoThanhVienRepository, ThongBaoThanhVienRepository>();

            services.AddTransient<IToChucRepository, ToChucRepository>();
            services.AddTransient<IToChucQuanLyRepository, ToChucQuanLyRepository>();
            services.AddTransient<IToChucTapTinDinhKemRepository, ToChucTapTinDinhKemRepository>();
            services.AddTransient<IToChucToaDoRepository, ToChucToaDoRepository>();
            services.AddTransient<IToChucLongBeRepository, ToChucLongBeRepository>();
            services.AddTransient<IToChucNuoiNhuyenTheRepository, ToChucNuoiNhuyenTheRepository>();
            services.AddTransient<IToChucPhuongTienKhaiThacRepository, ToChucPhuongTienKhaiThacRepository>();
            services.AddTransient<IToChucVungNuoiRepository, ToChucVungNuoiRepository>();
            services.AddTransient<IToChucGiongRepository, ToChucGiongRepository>();
            services.AddTransient<IToChucTieuChuanRepository, ToChucTieuChuanRepository>();
            services.AddTransient<IToChucNguyenVatLieuRepository, ToChucNguyenVatLieuRepository>();

            services.AddTransient<IReportRepository, ReportRepository>();

            return services;
        }
    }
}

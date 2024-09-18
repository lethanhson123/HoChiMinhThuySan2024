namespace Data.Model
{
    public partial class ToChucPhuongTienKhaiThac : BaseModel
    {       
        public decimal? ChieuCao { get; set; }
        public decimal? ChieuRong { get; set; }
        public decimal? ChieuDai { get; set; }
        public decimal? DungTich { get; set; }
        public long? DanhMucHieuMayID { get; set; }
        public string? DanhMucHieuMayName { get; set; }
        public decimal? CongSuat { get; set; }
        public long? DanhMucNganhNgheID { get; set; }
        public string? DanhMucNganhNgheName { get; set; }
        public int? ThuyenVien { get; set; }
        public DateTime? NgayDangKy { get; set; }
        public DateTime? HanDangKiem { get; set; }
        public string? KinhDo { get; set; }
        public string? ViDo { get; set; }
        public long? DanhMucQuocGiaID { get; set; }
        public string? DanhMucQuocGiaName { get; set; }
        public long? DanhMucTinhThanhID { get; set; }
        public string? DanhMucTinhThanhName { get; set; }
        public long? DanhMucQuanHuyenID { get; set; }
        public string? DanhMucQuanHuyenName { get; set; }
        public long? DanhMucXaPhuongID { get; set; }
        public string? DanhMucXaPhuongName { get; set; }

        public ToChucPhuongTienKhaiThac()
        {
        }
    }
}


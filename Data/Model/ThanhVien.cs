namespace Data.Model
{
    public partial class ThanhVien : BaseModel
    {
        public string? TaiKhoan { get; set; }
        public string? MatKhau { get; set; }
        public string? GUIDCode { get; set; }
        public string? CCCD { get; set; }
        public string? DienThoai { get; set; }
        public string? Email { get; set; }
        public string? GioiTinh { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string? DiaChi { get; set; }
        public string? ApThon { get; set; }
        public long? DanhMucQuocGiaID { get; set; }
        public string? DanhMucQuocGiaName { get; set; }
        public long? DanhMucTinhThanhID { get; set; }
        public string? DanhMucTinhThanhName { get; set; }
        public long? DanhMucQuanHuyenID { get; set; }
        public string? DanhMucQuanHuyenName { get; set; }
        public long? DanhMucXaPhuongID { get; set; }
        public string? DanhMucXaPhuongName { get; set; }
        public long? ToChucID { get; set; }
        public string? ToChucName { get; set; }
        public string? DonViCongTac { get; set; }
        public string? PhongBan { get; set; }
        public string? ChucDanh { get; set; }        
        public ThanhVien()
        {
        }
    }
}


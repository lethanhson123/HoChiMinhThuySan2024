namespace Data.Model
{
    public partial class ToChuc : BaseModel
    {
       
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
        public string? KinhDo { get; set; }
        public string? ViDo { get; set; }
        public string? DuongPho { get; set; }
        public string? SoNha { get; set; }
        public string? ChuDatHoTen { get; set; }
        public string? ChuDatDiaChi { get; set; }
        public decimal? DienTichNuoiTrongThuySan { get; set; }
        public decimal? DienTichNuoi { get; set; }
        public decimal? DienTichTha { get; set; }
        public decimal? DienTichThuHoach { get; set; }
        public decimal? DienTichBenh { get; set; }
        public int? AoNuoi { get; set; }
        public string? HinhThucNuoi { get; set; }
        public decimal? SoLuongGiongTha { get; set; }
        public decimal? SoLuongBenh { get; set; }
        public decimal? SanLuong { get; set; }
        public string? NgayTTB { get; set; }
        public string? NguonGiong { get; set; }
        public string? HienTrang { get; set; }
        public string? QuyHoach { get; set; }
        public string? DiaChiKhu { get; set; }
        public long? DanhMucGiongID { get; set; }
        public string? DanhMucGiongName { get; set; }
        public long? DanhMucLoaiGiongID { get; set; }
        public string? DanhMucLoaiGiongName { get; set; }
        public long? DanhMucLoaiHinhID { get; set; }
        public string? DanhMucLoaiHinhName { get; set; }
        public long? DanhMucCuaHangID { get; set; }
        public string? DanhMucCuaHangName { get; set; }
        public long? DanhMucNguyenVatLieuID { get; set; }
        public string? DanhMucNguyenVatLieuName { get; set; }
        public string? Geom { get; set; }
        public int? NamGhiNhan { get; set; }
        public ToChuc()
        {
        }
    }
}


namespace Data.Model
{
    public partial class ThanhVienLichSuTruyCap : BaseModel
    {
        public string? URL { get; set; }
        public string? Token { get; set; }
        public DateTime? NgayGhiNhan { get; set; }
        public string? IPAddress { get; set; }
        public string? KinhDo { get; set; }
        public string? ViDo { get; set; }
        public string? DanhMucQuocGiaName { get; set; }
        public string? DanhMucTinhThanhName { get; set; }
        public string? DanhMucQuanHuyenName { get; set; }
        public string? DanhMucXaPhuongName { get; set; }
        public ThanhVienLichSuTruyCap()
        {
        }
    }
}


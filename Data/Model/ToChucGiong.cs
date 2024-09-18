namespace Data.Model
{
    public partial class ToChucGiong : BaseModel
    {       
        public long? DanhMucGiongID { get; set; }
        public string? DanhMucGiongName { get; set; }
        public long? DanhMucLoaiGiongID { get; set; }
        public string? DanhMucLoaiGiongName { get; set; }
        public decimal? MatDoNuoi { get; set; }
        public string? PH { get; set; }
        public string? S { get; set; }
        public string? DoKiem { get; set; }
        public decimal? TyLeSong { get; set; }
        public decimal? ThoiGianNuoi { get; set; }
        public decimal? SanLuong { get; set; }
        public int? NamGhiNhan { get; set; }
        public decimal? DienTich { get; set; }
        public string? KinhDo { get; set; }
        public string? ViDo { get; set; }
        public ToChucGiong()
        {
        }
    }
}


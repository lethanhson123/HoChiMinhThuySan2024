namespace Data.Model
{
    public partial class ToChucVungNuoi : BaseModel
    {       
        public long? ToChucID { get; set; }
        public string? ToChucName { get; set; }
        public long? DanhMucGiongID { get; set; }
        public string? DanhMucGiongName { get; set; }
        public long? DanhMucLoaiGiongID { get; set; }
        public string? DanhMucLoaiGiongName { get; set; }
        public decimal? NangSuat { get; set; }
        public decimal? SanLuong { get; set; }
        public decimal? MatDoTha { get; set; }
        public decimal? SoLuong { get; set; }

        public ToChucVungNuoi()
        {
        }
    }
}


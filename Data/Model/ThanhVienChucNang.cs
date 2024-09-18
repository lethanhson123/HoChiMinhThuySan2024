namespace Data.Model
{
    public partial class ThanhVienChucNang : BaseModel
    {
        public long? DanhMucChucNangID { get; set; }
        public long? DanhMucThanhVienID { get; set; }
        
        public ThanhVienChucNang()
        {
        }
    }
}


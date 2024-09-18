namespace Data.Model
{
    public partial class ThanhVienToken : BaseModel
    {
        public DateTime? BatDau { get; set; }
        public DateTime? KetThuc { get; set; }
        public string? Token { get; set; }

        public ThanhVienToken()
        {
        }
    }
}


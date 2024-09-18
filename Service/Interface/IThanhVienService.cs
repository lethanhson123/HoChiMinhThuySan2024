namespace Service.Interface
{
    public interface IThanhVienService : IBaseService<ThanhVien>
    {
        Task<int> Update001Async(ThanhVien model);
        Task<ThanhVien> SaveSyncAsync(ThanhVien model);
        Task<ThanhVien> ChangePasswordAsync(ThanhVien model, string password01, string password02, string password03);
        Task<ThanhVien> AuthenticationAsync(ThanhVien thanhVien);
        Task<ThanhVien> AuthenticationMobileAsync(string username, string password);      
        Task<ThanhVien> GetByDienThoaiAsync(string DienThoai);
        Task<ThanhVien> GetByCCCDAsync(string CCCD);
        Task<List<ThanhVien>> GetFromThanhVienThongBaoByDanhMucUngDungIDAndActiveAsync(long DanhMucUngDungID, bool Active);
        Task<int> SyncFromToChucAsync();
    }
}


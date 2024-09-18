namespace Service.Interface
{
    public interface IDanhMucChucNangService : IBaseService<DanhMucChucNang>
    {
        Task<List<DanhMucChucNang>> GetSQLByThanhVienID_ActiveToListAsync(long thanhVienID, bool active);
    }
}


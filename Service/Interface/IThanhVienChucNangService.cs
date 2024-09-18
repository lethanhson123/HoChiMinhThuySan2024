namespace Service.Interface
{
    public interface IThanhVienChucNangService : IBaseService<ThanhVienChucNang>
    {
        Task<List<ThanhVienChucNang>> GetSQLByParentIDToListAsync(long parentID);
        Task<List<ThanhVienChucNang>> GetSQLByDanhMucThanhVienIDToListAsync(long danhMucThanhVienID);
        Task<List<ThanhVienChucNang>> GetByDanhMucChucNangIDAndEmptyToListAsync(long DanhMucChucNangID);
    }
}


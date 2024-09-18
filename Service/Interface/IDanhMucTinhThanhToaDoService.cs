namespace Service.Interface
{
    public interface IDanhMucTinhThanhToaDoService : IBaseService<DanhMucTinhThanhToaDo>
    {
        Task<List<DanhMucTinhThanhToaDo>> GetSQLDanhMucQuanHuyenByParentIDToListAsync(long ParentID);
        Task<List<DanhMucTinhThanhToaDo>> GetSQLDanhMucXaPhuongByParentIDToListAsync(long ParentID);
        Task<List<DanhMucTinhThanhToaDo>> GetSQLByParentIDToListAsync(long ParentID);
    }
}


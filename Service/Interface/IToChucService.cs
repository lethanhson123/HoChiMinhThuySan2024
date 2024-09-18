namespace Service.Interface
{
    public interface IToChucService : IBaseService<ToChuc>
    {
        Task<List<ToChuc>> GetByParentIDAndSearchString_DanhMucQuanHuyenID_DanhMucXaPhuongIDAsync(long ParentID, string SearchString, long DanhMucQuanHuyenID, long DanhMucXaPhuongID);
        Task<List<ToChuc>> GetSQLByParentID_ActiveToListAsync(long ParentID, bool Active);
        Task<List<ToChuc>> GetSQLByParentID_Active_SearchStringToListAsync(long ParentID, bool Active, string SearchString);
        Task<List<ToChuc>> GetSQLByParentID_Active_SearchString_DanhMucQuanHuyenID_DanhMucXaPhuongIDToListAsync(long ParentID, bool Active, string SearchString, long DanhMucQuanHuyenID, long DanhMucXaPhuongID);
        Task<List<ToChuc>> GetSQLByDanhMucGiongIDToListAsync(long DanhMucGiongID);
        Task<List<ToChuc>> GetSQLByDanhMucGiongID_ActiveToListAsync(long DanhMucGiongID, bool Active);

    }
}


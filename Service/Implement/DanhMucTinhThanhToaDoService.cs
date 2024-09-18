namespace Service.Implement
{
    public class DanhMucTinhThanhToaDoService : BaseService<DanhMucTinhThanhToaDo, IDanhMucTinhThanhToaDoRepository>
    , IDanhMucTinhThanhToaDoService
    {
        private readonly IDanhMucTinhThanhToaDoRepository _DanhMucTinhThanhToaDoRepository;
        public DanhMucTinhThanhToaDoService(IDanhMucTinhThanhToaDoRepository DanhMucTinhThanhToaDoRepository) : base(DanhMucTinhThanhToaDoRepository)
        {
            _DanhMucTinhThanhToaDoRepository = DanhMucTinhThanhToaDoRepository;
        }
        public virtual async Task<List<DanhMucTinhThanhToaDo>> GetSQLDanhMucQuanHuyenByParentIDToListAsync(long ParentID)
        {
            List<DanhMucTinhThanhToaDo> result = new List<DanhMucTinhThanhToaDo>();
            if (ParentID > 0)
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@ParentID",ParentID),
                };
                result = await GetByStoredProcedureToListAsync("sp_DanhMucTinhThanhToaDoSelectDanhMucQuanHuyenItemsByParentID", parameters);
            }
            if (result == null)
            {
                result = new List<DanhMucTinhThanhToaDo>();
            }
            return result;
        }
        public virtual async Task<List<DanhMucTinhThanhToaDo>> GetSQLDanhMucXaPhuongByParentIDToListAsync(long ParentID)
        {
            List<DanhMucTinhThanhToaDo> result = new List<DanhMucTinhThanhToaDo>();
            if (ParentID > 0)
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@ParentID",ParentID),
                };
                result = await GetByStoredProcedureToListAsync("sp_DanhMucTinhThanhToaDoSelectDanhMucXaPhuongItemsByParentID", parameters);
            }
            if (result == null)
            {
                result = new List<DanhMucTinhThanhToaDo>();
            }
            return result;
        }
        public virtual async Task<List<DanhMucTinhThanhToaDo>> GetSQLByParentIDToListAsync(long ParentID)
        {
            List<DanhMucTinhThanhToaDo> result = new List<DanhMucTinhThanhToaDo>();
            if (ParentID > 0)
            {
                result = await GetSQLDanhMucXaPhuongByParentIDToListAsync(ParentID);
            }
            else
            {
                result = await GetSQLDanhMucQuanHuyenByParentIDToListAsync(GlobalHelper.DanhMucTinhThanhID);
            }
            if (result == null)
            {
                result = new List<DanhMucTinhThanhToaDo>();
            }
            return result;
        }
    }
}


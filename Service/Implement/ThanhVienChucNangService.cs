using Service.Interface;

namespace Service.Implement
{
    public class ThanhVienChucNangService : BaseService<ThanhVienChucNang, IThanhVienChucNangRepository>
    , IThanhVienChucNangService
    {
        private readonly IThanhVienChucNangRepository _ThanhVienChucNangRepository;

        private readonly IDanhMucChucNangService _DanhMucChucNangService;
        public ThanhVienChucNangService(IThanhVienChucNangRepository ThanhVienChucNangRepository

            , IDanhMucChucNangService DanhMucChucNangService
            
            ) : base(ThanhVienChucNangRepository)
        {
            _ThanhVienChucNangRepository = ThanhVienChucNangRepository;

            _DanhMucChucNangService = DanhMucChucNangService;
        }
        public override void Initialization(ThanhVienChucNang model)
        {
            if (model.DanhMucChucNangID > 0)
            {
                model.Name = _DanhMucChucNangService.GetByID(model.DanhMucChucNangID.Value).Name;
            }
        }
        public virtual async Task<List<ThanhVienChucNang>> GetSQLByParentIDToListAsync(long parentID)
        {
            List<ThanhVienChucNang> result = new List<ThanhVienChucNang>();
            SqlParameter[] parameters =
            {
                    new SqlParameter("@ParentID",parentID),
            };
            result = await GetByStoredProcedureToListAsync("sp_ThanhVienChucNangSelectItemsByParentID", parameters);
            return result;
        }
        public virtual async Task<List<ThanhVienChucNang>> GetSQLByDanhMucThanhVienIDToListAsync(long danhMucThanhVienID)
        {
            List<ThanhVienChucNang> result = new List<ThanhVienChucNang>();
            SqlParameter[] parameters =
            {
                    new SqlParameter("@DanhMucThanhVienID",danhMucThanhVienID),
            };
            result = await GetByStoredProcedureToListAsync("sp_ThanhVienChucNangSelectItemsByDanhMucThanhVienID", parameters);
            return result;
        }
        public virtual async Task<List<ThanhVienChucNang>> GetByDanhMucChucNangIDAndEmptyToListAsync(long DanhMucChucNangID)
        {
            List<ThanhVienChucNang> result = new List<ThanhVienChucNang>();
            ThanhVienChucNang empty = new ThanhVienChucNang();
            result.Add(empty);
            if (DanhMucChucNangID > 0)
            {
                result.AddRange(await GetByCondition(item => item.DanhMucChucNangID == DanhMucChucNangID && item.DanhMucThanhVienID > 0).ToListAsync());
            }
            return result;
        }

    }
}


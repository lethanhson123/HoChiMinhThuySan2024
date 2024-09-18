namespace Service.Implement
{
    public class DanhMucChucNangService : BaseService<DanhMucChucNang, IDanhMucChucNangRepository>
    , IDanhMucChucNangService
    {
        private readonly IDanhMucChucNangRepository _DanhMucChucNangRepository;
        public DanhMucChucNangService(IDanhMucChucNangRepository DanhMucChucNangRepository) : base(DanhMucChucNangRepository)
        {
            _DanhMucChucNangRepository = DanhMucChucNangRepository;
        }
        public override void Initialization(DanhMucChucNang model)
        {
            BaseInitialization(model);
            if (string.IsNullOrEmpty(model.Code))
            {
                model.Code = "#";
            }
        }
        public virtual async Task<List<DanhMucChucNang>> GetSQLByThanhVienID_ActiveToListAsync(long thanhVienID, bool active)
        {
            List<DanhMucChucNang> result = new List<DanhMucChucNang>();
            SqlParameter[] parameters =
            {
                    new SqlParameter("@ThanhVienID",thanhVienID),
                    new SqlParameter("@Active",active),
            };
            result = await GetByStoredProcedureToListAsync("sp_DanhMucChucNangSelectItemsByThanhVienID_Active", parameters);
            return result;
        }
    }
}


namespace Service.Implement
{
    public class ThanhVienLichSuTruyCapService : BaseService<ThanhVienLichSuTruyCap, IThanhVienLichSuTruyCapRepository>
    , IThanhVienLichSuTruyCapService
    {
        private readonly IThanhVienLichSuTruyCapRepository _ThanhVienLichSuTruyCapRepository;
        public ThanhVienLichSuTruyCapService(IThanhVienLichSuTruyCapRepository ThanhVienLichSuTruyCapRepository) : base(ThanhVienLichSuTruyCapRepository)
        {
            _ThanhVienLichSuTruyCapRepository = ThanhVienLichSuTruyCapRepository;
        }
        public override void Initialization(ThanhVienLichSuTruyCap model)
        {
            BaseInitialization(model);
            if (model.NgayGhiNhan == null)
            {
                model.NgayGhiNhan = GlobalHelper.InitializationDateTime;
            }
        }        
        public override async Task<List<ThanhVienLichSuTruyCap>> GetBySearchStringToListAsync(string searchString)
        {
            List<ThanhVienLichSuTruyCap> result = new List<ThanhVienLichSuTruyCap>();
            if (!string.IsNullOrEmpty(searchString))
            {
                result = await GetByCondition(item => item.ID.ToString().Contains(searchString)).ToListAsync();
                if (result.Count == 0)
                {
                    result = await GetByCondition(item => item.Name.ToLower().Contains(searchString)).ToListAsync();
                }
                if (result.Count == 0)
                {
                    result = await GetByCondition(item => item.Code.ToLower().Contains(searchString)).ToListAsync();
                }
                if (result.Count == 0)
                {
                    result = await GetByCondition(item => item.URL.ToLower().Contains(searchString)).ToListAsync();
                }
                if (result.Count == 0)
                {
                    result = await GetByCondition(item => item.Token.ToLower().Contains(searchString)).ToListAsync();
                }
                if (result.Count == 0)
                {
                    result = await GetByCondition(item => item.Description.ToLower().Contains(searchString)).ToListAsync();
                }
                result = result.OrderByDescending(item => item.NgayGhiNhan).ToList();
            }
            return result;
        }
        public virtual async Task<List<ThanhVienLichSuTruyCap>> GetByBatDau_KetThucToListAsync(DateTime batDau, DateTime ketThuc)
        {
            List<ThanhVienLichSuTruyCap> result = new List<ThanhVienLichSuTruyCap>();
            batDau = new DateTime(batDau.Year, batDau.Month, batDau.Day, 0, 0, 0);
            ketThuc = new DateTime(ketThuc.Year, ketThuc.Month, ketThuc.Day, 23, 59, 59);
            result = await GetByCondition(item => item.NgayGhiNhan >= batDau && item.NgayGhiNhan <= ketThuc).ToListAsync();
            result = result.OrderByDescending(item => item.NgayGhiNhan).ToList();
            return result;
        }
        public virtual async Task<List<ThanhVienLichSuTruyCap>> GetBySearchString_BatDau_KetThucToListAsync(string searchString, DateTime batDau, DateTime ketThuc)
        {
            List<ThanhVienLichSuTruyCap> result = new List<ThanhVienLichSuTruyCap>();
            if (!string.IsNullOrEmpty(searchString))
            {
                result = await GetBySearchStringToListAsync(searchString);
            }
            else
            {
                result = await GetByBatDau_KetThucToListAsync(batDau, ketThuc);
            }
            result = result.OrderByDescending(item => item.NgayGhiNhan).ToList();
            return result;
        }
    }
}


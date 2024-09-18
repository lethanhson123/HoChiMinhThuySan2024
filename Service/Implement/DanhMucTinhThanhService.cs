namespace Service.Implement
{
    public class DanhMucTinhThanhService : BaseService<DanhMucTinhThanh, IDanhMucTinhThanhRepository>
    , IDanhMucTinhThanhService
    {
        private readonly IDanhMucTinhThanhRepository _DanhMucTinhThanhRepository;
        public DanhMucTinhThanhService(IDanhMucTinhThanhRepository DanhMucTinhThanhRepository) : base(DanhMucTinhThanhRepository)
        {
            _DanhMucTinhThanhRepository = DanhMucTinhThanhRepository;
        }
    }
}


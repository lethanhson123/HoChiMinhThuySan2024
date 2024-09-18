namespace Service.Implement
{
    public class DanhMucQuanHuyenService : BaseService<DanhMucQuanHuyen, IDanhMucQuanHuyenRepository>
    , IDanhMucQuanHuyenService
    {
        private readonly IDanhMucQuanHuyenRepository _DanhMucQuanHuyenRepository;
        public DanhMucQuanHuyenService(IDanhMucQuanHuyenRepository DanhMucQuanHuyenRepository) : base(DanhMucQuanHuyenRepository)
        {
            _DanhMucQuanHuyenRepository = DanhMucQuanHuyenRepository;
        }
    }
}


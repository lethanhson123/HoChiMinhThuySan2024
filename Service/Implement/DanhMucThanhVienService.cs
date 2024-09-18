namespace Service.Implement
{
    public class DanhMucThanhVienService : BaseService<DanhMucThanhVien, IDanhMucThanhVienRepository>
    , IDanhMucThanhVienService
    {
    private readonly IDanhMucThanhVienRepository _DanhMucThanhVienRepository;
    public DanhMucThanhVienService(IDanhMucThanhVienRepository DanhMucThanhVienRepository) : base(DanhMucThanhVienRepository)
    {
    _DanhMucThanhVienRepository = DanhMucThanhVienRepository;
    }
    }
    }


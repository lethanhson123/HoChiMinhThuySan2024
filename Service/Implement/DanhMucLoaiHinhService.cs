namespace Service.Implement
{
    public class DanhMucLoaiHinhService : BaseService<DanhMucLoaiHinh, IDanhMucLoaiHinhRepository>
    , IDanhMucLoaiHinhService
    {
    private readonly IDanhMucLoaiHinhRepository _DanhMucLoaiHinhRepository;
    public DanhMucLoaiHinhService(IDanhMucLoaiHinhRepository DanhMucLoaiHinhRepository) : base(DanhMucLoaiHinhRepository)
    {
    _DanhMucLoaiHinhRepository = DanhMucLoaiHinhRepository;
    }
    }
    }


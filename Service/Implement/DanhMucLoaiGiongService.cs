namespace Service.Implement
{
    public class DanhMucLoaiGiongService : BaseService<DanhMucLoaiGiong, IDanhMucLoaiGiongRepository>
    , IDanhMucLoaiGiongService
    {
    private readonly IDanhMucLoaiGiongRepository _DanhMucLoaiGiongRepository;
    public DanhMucLoaiGiongService(IDanhMucLoaiGiongRepository DanhMucLoaiGiongRepository) : base(DanhMucLoaiGiongRepository)
    {
    _DanhMucLoaiGiongRepository = DanhMucLoaiGiongRepository;
    }
    }
    }


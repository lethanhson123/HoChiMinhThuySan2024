namespace Service.Implement
{
    public class DanhMucGiongService : BaseService<DanhMucGiong, IDanhMucGiongRepository>
    , IDanhMucGiongService
    {
    private readonly IDanhMucGiongRepository _DanhMucGiongRepository;
    public DanhMucGiongService(IDanhMucGiongRepository DanhMucGiongRepository) : base(DanhMucGiongRepository)
    {
    _DanhMucGiongRepository = DanhMucGiongRepository;
    }
    }
    }


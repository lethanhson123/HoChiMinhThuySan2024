namespace Service.Implement
{
    public class DanhMucAPIService : BaseService<DanhMucAPI, IDanhMucAPIRepository>
    , IDanhMucAPIService
    {
    private readonly IDanhMucAPIRepository _DanhMucAPIRepository;
    public DanhMucAPIService(IDanhMucAPIRepository DanhMucAPIRepository) : base(DanhMucAPIRepository)
    {
    _DanhMucAPIRepository = DanhMucAPIRepository;
    }
    }
    }


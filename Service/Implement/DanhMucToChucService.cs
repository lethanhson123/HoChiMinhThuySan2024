namespace Service.Implement
{
    public class DanhMucToChucService : BaseService<DanhMucToChuc, IDanhMucToChucRepository>
    , IDanhMucToChucService
    {
    private readonly IDanhMucToChucRepository _DanhMucToChucRepository;
    public DanhMucToChucService(IDanhMucToChucRepository DanhMucToChucRepository) : base(DanhMucToChucRepository)
    {
    _DanhMucToChucRepository = DanhMucToChucRepository;
    }
    }
    }


namespace Service.Implement
{
    public class DanhMucNganhNgheService : BaseService<DanhMucNganhNghe, IDanhMucNganhNgheRepository>
    , IDanhMucNganhNgheService
    {
    private readonly IDanhMucNganhNgheRepository _DanhMucNganhNgheRepository;
    public DanhMucNganhNgheService(IDanhMucNganhNgheRepository DanhMucNganhNgheRepository) : base(DanhMucNganhNgheRepository)
    {
    _DanhMucNganhNgheRepository = DanhMucNganhNgheRepository;
    }
    }
    }


namespace Service.Implement
{
    public class DanhMucHieuMayService : BaseService<DanhMucHieuMay, IDanhMucHieuMayRepository>
    , IDanhMucHieuMayService
    {
    private readonly IDanhMucHieuMayRepository _DanhMucHieuMayRepository;
    public DanhMucHieuMayService(IDanhMucHieuMayRepository DanhMucHieuMayRepository) : base(DanhMucHieuMayRepository)
    {
    _DanhMucHieuMayRepository = DanhMucHieuMayRepository;
    }
    }
    }


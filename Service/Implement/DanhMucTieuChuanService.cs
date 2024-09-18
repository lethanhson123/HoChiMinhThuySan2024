namespace Service.Implement
{
    public class DanhMucTieuChuanService : BaseService<DanhMucTieuChuan, IDanhMucTieuChuanRepository>
    , IDanhMucTieuChuanService
    {
    private readonly IDanhMucTieuChuanRepository _DanhMucTieuChuanRepository;
    public DanhMucTieuChuanService(IDanhMucTieuChuanRepository DanhMucTieuChuanRepository) : base(DanhMucTieuChuanRepository)
    {
    _DanhMucTieuChuanRepository = DanhMucTieuChuanRepository;
    }
    }
    }


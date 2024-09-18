namespace Service.Implement
{
    public class DanhMucCuaHangService : BaseService<DanhMucCuaHang, IDanhMucCuaHangRepository>
    , IDanhMucCuaHangService
    {
    private readonly IDanhMucCuaHangRepository _DanhMucCuaHangRepository;
    public DanhMucCuaHangService(IDanhMucCuaHangRepository DanhMucCuaHangRepository) : base(DanhMucCuaHangRepository)
    {
    _DanhMucCuaHangRepository = DanhMucCuaHangRepository;
    }
    }
    }


namespace Repository.Implement
{
    public class DanhMucCuaHangRepository : BaseRepository<DanhMucCuaHang>
    , IDanhMucCuaHangRepository
    {
    private readonly Data.Context.Context _context;
    public DanhMucCuaHangRepository(Data.Context.Context context) : base(context)
    {
    _context = context;
    }
    }
    }


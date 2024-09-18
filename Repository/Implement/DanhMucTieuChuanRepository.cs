namespace Repository.Implement
{
    public class DanhMucTieuChuanRepository : BaseRepository<DanhMucTieuChuan>
    , IDanhMucTieuChuanRepository
    {
    private readonly Data.Context.Context _context;
    public DanhMucTieuChuanRepository(Data.Context.Context context) : base(context)
    {
    _context = context;
    }
    }
    }


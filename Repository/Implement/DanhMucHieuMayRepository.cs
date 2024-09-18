namespace Repository.Implement
{
    public class DanhMucHieuMayRepository : BaseRepository<DanhMucHieuMay>
    , IDanhMucHieuMayRepository
    {
    private readonly Data.Context.Context _context;
    public DanhMucHieuMayRepository(Data.Context.Context context) : base(context)
    {
    _context = context;
    }
    }
    }


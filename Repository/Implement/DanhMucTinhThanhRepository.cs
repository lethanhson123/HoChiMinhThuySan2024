namespace Repository.Implement
{
    public class DanhMucTinhThanhRepository : BaseRepository<DanhMucTinhThanh>
    , IDanhMucTinhThanhRepository
    {
    private readonly Data.Context.Context _context;
    public DanhMucTinhThanhRepository(Data.Context.Context context) : base(context)
    {
    _context = context;
    }
    }
    }


namespace Repository.Implement
{
    public class DanhMucTinhThanhToaDoRepository : BaseRepository<DanhMucTinhThanhToaDo>
    , IDanhMucTinhThanhToaDoRepository
    {
    private readonly Data.Context.Context _context;
    public DanhMucTinhThanhToaDoRepository(Data.Context.Context context) : base(context)
    {
    _context = context;
    }
    }
    }


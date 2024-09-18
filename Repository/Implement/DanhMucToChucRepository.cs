namespace Repository.Implement
{
    public class DanhMucToChucRepository : BaseRepository<DanhMucToChuc>
    , IDanhMucToChucRepository
    {
    private readonly Data.Context.Context _context;
    public DanhMucToChucRepository(Data.Context.Context context) : base(context)
    {
    _context = context;
    }
    }
    }


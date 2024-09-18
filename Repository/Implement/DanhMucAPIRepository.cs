namespace Repository.Implement
{
    public class DanhMucAPIRepository : BaseRepository<DanhMucAPI>
    , IDanhMucAPIRepository
    {
    private readonly Data.Context.Context _context;
    public DanhMucAPIRepository(Data.Context.Context context) : base(context)
    {
    _context = context;
    }
    }
    }


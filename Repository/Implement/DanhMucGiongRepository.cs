namespace Repository.Implement
{
    public class DanhMucGiongRepository : BaseRepository<DanhMucGiong>
    , IDanhMucGiongRepository
    {
    private readonly Data.Context.Context _context;
    public DanhMucGiongRepository(Data.Context.Context context) : base(context)
    {
    _context = context;
    }
    }
    }


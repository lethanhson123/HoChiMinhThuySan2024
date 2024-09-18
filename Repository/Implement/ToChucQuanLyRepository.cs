namespace Repository.Implement
{
    public class ToChucQuanLyRepository : BaseRepository<ToChucQuanLy>
    , IToChucQuanLyRepository
    {
    private readonly Data.Context.Context _context;
    public ToChucQuanLyRepository(Data.Context.Context context) : base(context)
    {
    _context = context;
    }
    }
    }


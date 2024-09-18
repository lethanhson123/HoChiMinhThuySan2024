namespace Repository.Implement
{
    public class ToChucGiongRepository : BaseRepository<ToChucGiong>
    , IToChucGiongRepository
    {
    private readonly Data.Context.Context _context;
    public ToChucGiongRepository(Data.Context.Context context) : base(context)
    {
    _context = context;
    }
    }
    }


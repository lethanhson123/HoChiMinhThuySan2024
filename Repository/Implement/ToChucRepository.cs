namespace Repository.Implement
{
    public class ToChucRepository : BaseRepository<ToChuc>
    , IToChucRepository
    {
    private readonly Data.Context.Context _context;
    public ToChucRepository(Data.Context.Context context) : base(context)
    {
    _context = context;
    }
    }
    }


namespace Repository.Implement
{
    public class ToChucToaDoRepository : BaseRepository<ToChucToaDo>
    , IToChucToaDoRepository
    {
    private readonly Data.Context.Context _context;
    public ToChucToaDoRepository(Data.Context.Context context) : base(context)
    {
    _context = context;
    }
    }
    }


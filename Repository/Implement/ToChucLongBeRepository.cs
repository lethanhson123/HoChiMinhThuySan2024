namespace Repository.Implement
{
    public class ToChucLongBeRepository : BaseRepository<ToChucLongBe>
    , IToChucLongBeRepository
    {
    private readonly Data.Context.Context _context;
    public ToChucLongBeRepository(Data.Context.Context context) : base(context)
    {
    _context = context;
    }
    }
    }


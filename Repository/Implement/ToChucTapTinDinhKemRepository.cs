namespace Repository.Implement
{
    public class ToChucTapTinDinhKemRepository : BaseRepository<ToChucTapTinDinhKem>
    , IToChucTapTinDinhKemRepository
    {
    private readonly Data.Context.Context _context;
    public ToChucTapTinDinhKemRepository(Data.Context.Context context) : base(context)
    {
    _context = context;
    }
    }
    }


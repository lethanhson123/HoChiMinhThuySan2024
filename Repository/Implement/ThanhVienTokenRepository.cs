namespace Repository.Implement
{
    public class ThanhVienTokenRepository : BaseRepository<ThanhVienToken>
    , IThanhVienTokenRepository
    {
    private readonly Data.Context.Context _context;
    public ThanhVienTokenRepository(Data.Context.Context context) : base(context)
    {
    _context = context;
    }
    }
    }


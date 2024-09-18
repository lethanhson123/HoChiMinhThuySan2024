namespace Repository.Implement
{
    public class ThongBaoRepository : BaseRepository<ThongBao>
    , IThongBaoRepository
    {
    private readonly Data.Context.Context _context;
    public ThongBaoRepository(Data.Context.Context context) : base(context)
    {
    _context = context;
    }
    }
    }


namespace Repository.Implement
{
    public class ToChucTieuChuanRepository : BaseRepository<ToChucTieuChuan>
    , IToChucTieuChuanRepository
    {
    private readonly Data.Context.Context _context;
    public ToChucTieuChuanRepository(Data.Context.Context context) : base(context)
    {
    _context = context;
    }
    }
    }


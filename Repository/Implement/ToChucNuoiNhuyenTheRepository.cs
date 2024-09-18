namespace Repository.Implement
{
    public class ToChucNuoiNhuyenTheRepository : BaseRepository<ToChucNuoiNhuyenThe>
    , IToChucNuoiNhuyenTheRepository
    {
    private readonly Data.Context.Context _context;
    public ToChucNuoiNhuyenTheRepository(Data.Context.Context context) : base(context)
    {
    _context = context;
    }
    }
    }


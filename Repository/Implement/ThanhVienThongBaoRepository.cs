namespace Repository.Implement
{
    public class ThanhVienThongBaoRepository : BaseRepository<ThanhVienThongBao>
    , IThanhVienThongBaoRepository
    {
    private readonly Data.Context.Context _context;
    public ThanhVienThongBaoRepository(Data.Context.Context context) : base(context)
    {
    _context = context;
    }
    }
    }


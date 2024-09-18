namespace Repository.Implement
{
    public class ThongBaoThanhVienRepository : BaseRepository<ThongBaoThanhVien>
    , IThongBaoThanhVienRepository
    {
    private readonly Data.Context.Context _context;
    public ThongBaoThanhVienRepository(Data.Context.Context context) : base(context)
    {
    _context = context;
    }
    }
    }


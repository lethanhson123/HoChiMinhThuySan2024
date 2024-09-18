namespace Repository.Implement
{
    public class ThanhVienRepository : BaseRepository<ThanhVien>
    , IThanhVienRepository
    {
    private readonly Data.Context.Context _context;
    public ThanhVienRepository(Data.Context.Context context) : base(context)
    {
    _context = context;
    }
    }
    }


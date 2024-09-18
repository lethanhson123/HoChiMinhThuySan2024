namespace Repository.Implement
{
    public class DanhMucNgonNguRepository : BaseRepository<DanhMucNgonNgu>
    , IDanhMucNgonNguRepository
    {
    private readonly Data.Context.Context _context;
    public DanhMucNgonNguRepository(Data.Context.Context context) : base(context)
    {
    _context = context;
    }
    }
    }


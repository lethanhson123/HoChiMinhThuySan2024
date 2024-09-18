namespace Repository.Implement
{
    public class DanhMucNganhNgheRepository : BaseRepository<DanhMucNganhNghe>
    , IDanhMucNganhNgheRepository
    {
    private readonly Data.Context.Context _context;
    public DanhMucNganhNgheRepository(Data.Context.Context context) : base(context)
    {
    _context = context;
    }
    }
    }


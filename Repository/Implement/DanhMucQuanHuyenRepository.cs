namespace Repository.Implement
{
    public class DanhMucQuanHuyenRepository : BaseRepository<DanhMucQuanHuyen>
    , IDanhMucQuanHuyenRepository
    {
    private readonly Data.Context.Context _context;
    public DanhMucQuanHuyenRepository(Data.Context.Context context) : base(context)
    {
    _context = context;
    }
    }
    }


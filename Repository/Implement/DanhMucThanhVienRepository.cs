namespace Repository.Implement
{
    public class DanhMucThanhVienRepository : BaseRepository<DanhMucThanhVien>
    , IDanhMucThanhVienRepository
    {
    private readonly Data.Context.Context _context;
    public DanhMucThanhVienRepository(Data.Context.Context context) : base(context)
    {
    _context = context;
    }
    }
    }


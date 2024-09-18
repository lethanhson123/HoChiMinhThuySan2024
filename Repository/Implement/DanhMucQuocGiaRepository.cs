namespace Repository.Implement
{
    public class DanhMucQuocGiaRepository : BaseRepository<DanhMucQuocGia>
    , IDanhMucQuocGiaRepository
    {
    private readonly Data.Context.Context _context;
    public DanhMucQuocGiaRepository(Data.Context.Context context) : base(context)
    {
    _context = context;
    }
    }
    }


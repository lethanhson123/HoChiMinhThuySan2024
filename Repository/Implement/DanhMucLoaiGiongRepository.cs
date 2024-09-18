namespace Repository.Implement
{
    public class DanhMucLoaiGiongRepository : BaseRepository<DanhMucLoaiGiong>
    , IDanhMucLoaiGiongRepository
    {
    private readonly Data.Context.Context _context;
    public DanhMucLoaiGiongRepository(Data.Context.Context context) : base(context)
    {
    _context = context;
    }
    }
    }


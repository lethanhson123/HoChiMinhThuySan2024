namespace Repository.Implement
{
    public class DanhMucLoaiHinhRepository : BaseRepository<DanhMucLoaiHinh>
    , IDanhMucLoaiHinhRepository
    {
    private readonly Data.Context.Context _context;
    public DanhMucLoaiHinhRepository(Data.Context.Context context) : base(context)
    {
    _context = context;
    }
    }
    }


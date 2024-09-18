namespace Repository.Implement
{
    public class DanhMucNguyenVatLieuRepository : BaseRepository<DanhMucNguyenVatLieu>
    , IDanhMucNguyenVatLieuRepository
    {
    private readonly Data.Context.Context _context;
    public DanhMucNguyenVatLieuRepository(Data.Context.Context context) : base(context)
    {
    _context = context;
    }
    }
    }


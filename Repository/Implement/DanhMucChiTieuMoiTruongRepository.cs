namespace Repository.Implement
{
    public class DanhMucChiTieuMoiTruongRepository : BaseRepository<DanhMucChiTieuMoiTruong>
    , IDanhMucChiTieuMoiTruongRepository
    {
    private readonly Data.Context.Context _context;
    public DanhMucChiTieuMoiTruongRepository(Data.Context.Context context) : base(context)
    {
    _context = context;
    }
    }
    }


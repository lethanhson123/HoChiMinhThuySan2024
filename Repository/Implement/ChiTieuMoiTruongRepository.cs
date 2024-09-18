namespace Repository.Implement
{
    public class ChiTieuMoiTruongRepository : BaseRepository<ChiTieuMoiTruong>
    , IChiTieuMoiTruongRepository
    {
    private readonly Data.Context.Context _context;
    public ChiTieuMoiTruongRepository(Data.Context.Context context) : base(context)
    {
    _context = context;
    }
    }
    }


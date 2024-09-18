namespace Service.Implement
{
    public class DanhMucNgonNguService : BaseService<DanhMucNgonNgu, IDanhMucNgonNguRepository>
    , IDanhMucNgonNguService
    {
    private readonly IDanhMucNgonNguRepository _DanhMucNgonNguRepository;
    public DanhMucNgonNguService(IDanhMucNgonNguRepository DanhMucNgonNguRepository) : base(DanhMucNgonNguRepository)
    {
    _DanhMucNgonNguRepository = DanhMucNgonNguRepository;
    }
    }
    }


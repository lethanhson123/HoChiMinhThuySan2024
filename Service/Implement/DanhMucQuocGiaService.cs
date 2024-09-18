namespace Service.Implement
{
    public class DanhMucQuocGiaService : BaseService<DanhMucQuocGia, IDanhMucQuocGiaRepository>
    , IDanhMucQuocGiaService
    {
    private readonly IDanhMucQuocGiaRepository _DanhMucQuocGiaRepository;
    public DanhMucQuocGiaService(IDanhMucQuocGiaRepository DanhMucQuocGiaRepository) : base(DanhMucQuocGiaRepository)
    {
    _DanhMucQuocGiaRepository = DanhMucQuocGiaRepository;
    }
    }
    }

